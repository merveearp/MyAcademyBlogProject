using Blogy.DataAccess.Context;
using Blogy.DataAccess.Repositories.GenericRepositories;
using Blogy.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.DataAccess.Repositories.ContactInfoRepositories
{
    public interface IContactInfoRespository 
    {
        Task <ContactInfo> GetAsync();
        Task UpdateAsync(ContactInfo entity);

    }
}
