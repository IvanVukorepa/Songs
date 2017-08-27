using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Songs.Domain.Repositories;

namespace Songs.Presentation
{
    class Program
    {
        static void Main(string[] args)
        {
            var authorRepository = new AuthorRepository();
            var songRepository = new SongRepository();
            while (true)
            {
                Console.WriteLine("Options:\n1) View all songs\n2) View all songs by an author\n3) Add an author\n5) Remove an author");

                int optionChosen = int.Parse(Console.ReadLine());

                switch (optionChosen)
                {
                    case 1:
                        songRepository.GetAllSongs().ToList().ForEach(x => Console.WriteLine(x.NameAndDuration));
                        break;
                    case 2:
                        Console.WriteLine("Name: ");
                        string name = Console.ReadLine();
                        authorRepository.GetAllSongsFromAuthor(name).ToList().ForEach(x => Console.WriteLine(x.NameAndDuration));
                        break;
                    case 3:
                        string name1, password1;
                        do
                        {
                            Console.WriteLine("Name: ");
                            name1 = Console.ReadLine();
                            Console.WriteLine("Password: ");
                            password1 = Console.ReadLine();
                        }
                        while (authorRepository.GetAuthorByNameAndPassword(name1, password1) != null);

                        authorRepository.AddAuthor(name1, password1);
                        break;
                    case 4:
                        string name2, password2;
                        do
                        {
                            Console.WriteLine("Name: ");
                            name2 = Console.ReadLine();
                            Console.WriteLine("Password: ");
                            password2 = Console.ReadLine();
                        }
                        while (authorRepository.GetAuthorByNameAndPassword(name2, password2) == null);

                        authorRepository.RemoveAuthor(name2, password2);
                        break;
                }
            }
        }
    }
}
