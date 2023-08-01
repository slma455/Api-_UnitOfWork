using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoPatternUnitOfWork.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Required,MaxLength(250)]
        public string? Title { get; set; }
        public Auther Auther { get; set; }
        public int AutherId { get; set; }

    }
}
