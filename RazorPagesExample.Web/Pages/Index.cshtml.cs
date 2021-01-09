using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using RazorPagesExample.Web.DataAccesss;
using RazorPagesExample.Web.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesExample.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly DataContex _con;
        [BindProperty]
        public List<NoteDto> NoteDtos { get; set; }
        public IndexModel(DataContex con)
        {
            _con = con;
        }

        public async Task<IActionResult> OnGet()
        {
            NoteDtos = await _con.GetAllNotesAsync();
            return Page();
        }
    }
}
