using MediatR;

namespace WebappAPI.Data.Persons
{
    public class IntListQuery : IRequest<int>
    {
        public List<int> IntList = new List<int> { 1,2,3,4,5,6,7,8,9,10};
        
    }
}
