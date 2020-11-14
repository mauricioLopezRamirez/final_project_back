using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace net_api_swagger.Domain
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Author Author { get; set; }
        public Guid AuthorId { get; set; }
        public Genre Genre { get; set; }
        public Guid GenreId { get; set; }
    }
}
