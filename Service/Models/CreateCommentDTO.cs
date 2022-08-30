using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models
{
    public class CreateCommentDTO
    {
        [Required]
        public string Value { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string CommentedBy { get; set; }

        public Guid ArticleId { get; set; }
    }
}
