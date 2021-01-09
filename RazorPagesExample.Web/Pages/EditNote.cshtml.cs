using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesExample.Web.DataAccesss;
using RazorPagesExample.Web.Dto;

namespace RazorPagesExample.Web.Pages
{
    public class EditNoteModel : PageModel
    {


        private readonly DataContex _con;
        public EditNoteModel(DataContex con)
        {
            _con = con;
        }

        [BindProperty(SupportsGet =false)]
        public NoteDto NoteDto { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? Id { get; set; }
        public async Task<IActionResult> OnGet()
        {
            if (Id != null)
            {
                NoteDto = await _con.GetNoteByIdAsync(Id.Value);
            }
           
            return Page();
        }



        public async Task<IActionResult> OnPost()
        {

            if (!ModelState.IsValid)
                return Page();
                 
            if (Id != null)
            {
                if (Id.Equals(NoteDto.Id))
                {
                    var fromdb = await _con.GetNoteByIdAsync(Id.Value);

                    if (fromdb != null)
                    {
                        NoteDto.UpdateDate = DateTime.Now;
                        await _con.UpdateNoteByIdAsync(NoteDto);
                        return Page();
                    }
                }
                
            }
            NoteDto = null;
            return Page();
        }
    }
}
