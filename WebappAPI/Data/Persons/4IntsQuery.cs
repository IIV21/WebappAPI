using AutoMapper;
using MediatR;

namespace WebappAPI.Data.Persons
{
    public class _4IntsQuery:IRequestHandler <_4IntRequest,_2IntResult>
    {
     

        public async Task<_2IntResult> Handle(_4IntRequest request, CancellationToken cancellationToken)
        {
            var result = new _2IntResult();
            result.result1 = (request.val1 + request.val2).ToString();
            result.result2 = (request.val3 + request.val4).ToString();
            return result;
        }
    }
}
