using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using System.Data;
using RazorPagesExample.Web.Dto;

namespace RazorPagesExample.Web.DataAccesss
{
    public class DataContex: IDisposable
    {
        protected readonly IDbConnection _con;
        public DataContex(IDbConnection con)
        {
            this._con = con;
        }


        public async  Task<int> CreateNoteAsync(NoteDto noteDto )
        {
           
                var sql = $"INSERT INTO Note ({nameof(noteDto.Name)},{nameof(noteDto.Description)},{nameof(noteDto.CreatedDate)},{nameof(noteDto.UpdateDate)}) VALUES " +
                    $"(@{nameof(noteDto.Name)},@{nameof(noteDto.Description)},@{nameof(noteDto.CreatedDate)},@{nameof(noteDto.UpdateDate)})";

                return await  _con.ExecuteAsync(sql, noteDto);
        
        }

        public void Dispose()
        {
            if (_con.State == ConnectionState.Open)
                _con.Close();

            _con.Dispose();
        }

        public async Task<List<NoteDto>> GetAllNotesAsync()
        {
           
                var sql = "SELECT * FROM [Note]";

                return (await _con.QueryAsync<NoteDto>(sql)).ToList();
           
        }


        public async Task<NoteDto> GetNoteByIdAsync(int id)
        {

                var sql = "SELECT TOP (1) * FROM [Note] WHERE Id = @Id ";

                return (await _con.QueryAsync<NoteDto>(sql,new {@Id= id })).FirstOrDefault();
           
        }


        public async Task<NoteDto> UpdateNoteByIdAsync(NoteDto noteDto)
        {
          
                var sql = $"UPDATE  Note SET {nameof(noteDto.Name)} = @{nameof(noteDto.Name)}," +
                    $"{nameof(noteDto.Description)} = @{nameof(noteDto.Description)}," +
                    $"{nameof(noteDto.UpdateDate)}=@{nameof(noteDto.UpdateDate)} WHERE Id = @Id;";

                 await _con.ExecuteAsync(sql, noteDto);

                return await GetNoteByIdAsync(noteDto.Id);
            
        }

    }
}
