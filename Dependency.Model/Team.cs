using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dependency.Model
{
    public class Team
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Surname { get; set; }
        public string Image { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
