using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BNP.Domain.Entities
{
    public class UserFile
    {
        [Key]
        public int Id { get; set; }
        public string FileName { get; set; }
        public ICollection<FileHistory> FileHistory { get; set; }

    }
}
