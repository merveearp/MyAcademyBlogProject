namespace Blogy.Business.Services.AIServices.CommentDecisionService
{
    public class AIDecisionCommentService : IAIDecisionCommentService
    {
        public Task<bool> DecisionAsync(double score)
        {
            // OpenAI Moderation mapping:
            // 0.0  => clean (yayınlanabilir)
            // >=1.0 => toxic (engellenecek)

            if (score <= 0.0)
                return Task.FromResult(true);

            return Task.FromResult(false);
        }
    }
}


//private const double TOXICITY_THRESHOLD = 0.7;

//public Task<bool> DecisionAsync(double score)
//{
//    // true  -> yayınlanabilir
//    // false -> engellenecek
//    var isAllowed = score < TOXICITY_THRESHOLD;

//    return Task.FromResult(isAllowed);
//}