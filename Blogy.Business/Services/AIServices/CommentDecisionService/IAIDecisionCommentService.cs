using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.Business.Services.AIServices.CommentDecisionService
{
    public interface IAIDecisionCommentService
    {
        Task<bool> DecisionAsync(double score) ;
    }
}
