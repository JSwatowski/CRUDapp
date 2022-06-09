using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDapp.Data
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }

        [Required]
        [MaxLength(12)]
        public string UserName { get; set; } = string.Empty;

        [Required]
        [MaxLength(150)]
        public string Text { get; set; } = string.Empty;
    }
}
