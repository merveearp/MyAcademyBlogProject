using Blogy.Entity.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.Entity.Entities
{
    public class ContactMessage :BaseEntity
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }

        public int WriterId { get; set; }
        public virtual AppUser? Writer { get; set; }
    }
}
