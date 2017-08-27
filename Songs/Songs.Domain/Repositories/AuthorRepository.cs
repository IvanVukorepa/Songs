using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Songs.Domain.DTOs;
using Songs.Domain.Object_mappers;
using Songs.Data;
using System.Data.Entity;

namespace Songs.Domain.Repositories
{
    public class AuthorRepository
    {
        public List<AuthorDTO> GetAllAuthors()
        {
            using (var context = new SongsContextEntities())
            {
                return context.Author.Select(AuthorMapper.FromEntity).ToList();
            }
        }

        public List<SongDTO> GetAllSongsFromAuthor(string name)
        {
            using (var context = new SongsContextEntities())
            {
                return context.Author.FirstOrDefault(x => x.FullName == name).Song.Select(SongMapper.FromEntity).ToList();
            }
        }

        public AuthorDTO GetAuthorByNameAndPassword(string name, string password)
        {
            using (var context = new SongsContextEntities())
            {
                return context.Author.Include("Song").Where(x => x.FullName == name && x.Password==password).ToList().Select(AuthorMapper.FromEntity).FirstOrDefault();
            }
        }

        public void AddAuthor(string fullName, string password)
        {
            using (var context = new SongsContextEntities())
            {
                context.Author.Add(new Author()
                {
                    FullName = fullName,
                    Password = password
                });
                context.SaveChanges();
            }
        }

        public void RemoveAuthor(string fullName, string password)
        {
            using (var context = new SongsContextEntities())
            {
                var author = context.Author.FirstOrDefault(x => x.FullName == fullName && x.Password == password);
                context.Entry(author).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
