using MediatR;

namespace WebappAPI.Data.Persons
{
    public class SumIntListController : IRequestHandler<IntListQuery,int>
    {
        public async Task<int> Handle(IntListQuery request, CancellationToken cancellationToken)
        {
            var result = request.IntList.Sum();
            return result;
        }
    }
}
