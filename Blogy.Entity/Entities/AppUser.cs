using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Blogy.Entity.Entities
{
    public class AppUser :IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Title { get; set; }
        public string? ImageUrl { get; set; }
        public IList<Blog> Blogs { get; set; }
        public IList<Comment> Comments { get; set; }

    }
}
