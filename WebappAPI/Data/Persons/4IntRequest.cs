using MediatR;

namespace WebappAPI.Data.Persons
{
    public class _4IntRequest : IRequest<_2IntResult>
    {
        public int val1 { get; set; }
        public int val2 { get; set; }
        public int val3 { get; set; }
        public int val4 { get; set; }

        public _4IntRequest(int v1,int v2, int v3, int v4)
        {
            val1 = v1;
            val2 = v2;
            val3 = v3;
            val4 = v4;
        }
    }
}
