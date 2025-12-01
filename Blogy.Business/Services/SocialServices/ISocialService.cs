using Blogy.Business.DTOs.SocialDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.Business.Services.SocialServices
{
    public interface ISocialService: IGenericService<ResultSocialDto,UpdateSocialDto,CreateSocialDto>
    {
        
    }
}
