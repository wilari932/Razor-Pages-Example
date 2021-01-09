using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesExample.Web.Dto
{


    public class NoteDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }

        public DateTime? CreatedDate {get;set;}
        public DateTime? UpdateDate { get; set; }
        
    }

}
