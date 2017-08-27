using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Songs.Domain.DTOs;
using Songs.Data;

namespace Songs.Domain.Object_mappers
{
    public static class SongMapper
    {
        public static SongDTO FromEntity(Song song)
        {
            return new SongDTO()
            {
                Id = song.Id,
                NameAndDuration = song.Name + " " + song.Duration.ToString() + " sekundi"
            };
        }
    }
}
