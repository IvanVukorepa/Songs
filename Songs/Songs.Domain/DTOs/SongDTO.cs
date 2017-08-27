using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Songs.Domain.DTOs
{
    public class SongDTO
    {
        public int Id { get; set; }
        public string NameAndDuration { get; set; }
    }
}
