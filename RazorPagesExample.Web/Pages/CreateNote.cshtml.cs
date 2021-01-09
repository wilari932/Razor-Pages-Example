using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesExample.Web.Dto;
using RazorPagesExample.Web.DataAccesss;

namespace RazorPagesExample.Web.Pages
{
    public class NoteModel : PageModel
    {
        private readonly DataContex _con;
        public NoteModel(DataContex con)
        {
            _con = con;
        }
        [BindProperty]
        public NoteDto NoteDto { get; set; }
        public void OnGet()
        {

        }

        public async  Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            NoteDto.CreatedDate = DateTime.Now;
            NoteDto.UpdateDate = DateTime.Now;
            await _con.CreateNoteAsync(NoteDto);
            return Redirect("/index");
        }

    }
}
