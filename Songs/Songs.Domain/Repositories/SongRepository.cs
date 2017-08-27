using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Songs.Domain.DTOs;
using Songs.Data;
using Songs.Domain.Object_mappers;

namespace Songs.Domain.Repositories
{
    public class SongRepository
    {
        public List<SongDTO> GetAllSongs()
        {
            using (var context = new SongsContextEntities())
            {
                return context.Song.Select(SongMapper.FromEntity).ToList();
            }
        }

        public void AddSong(string name, int duration, Author author)
        {
            using (var context = new SongsContextEntities())
            {
                context.Song.Add(new Song()
                {
                    Name = name,
                    Duration = duration,
                    Author = author,
                    AuthorId = author.Id
                    
                });
                context.SaveChanges();
            }
        }
    }
}
