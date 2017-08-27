using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Songs.Domain.DTOs;
using Songs.Data;

namespace Songs.Domain.Object_mappers
{
    public static class AuthorMapper
    {
        public static AuthorDTO FromEntity(Author author)
        {
            return new AuthorDTO()
            {
                Id = author.Id,
                FullName = author.FullName,
                Songs = author.Song.Select(song => SongMapper.FromEntity(song)).ToList()
            };
        }
    }
}
