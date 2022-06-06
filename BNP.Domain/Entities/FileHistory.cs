using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BNP.Domain.Entities
{
    public class FileHistory
    {
        public int Id { get; set; }
        public StaticType Type { get; set; }
        public DateTime Date { get; set; }

        public int UserFileId { get; set; }
        public UserFile UserFile { get; set; }
    }
}
