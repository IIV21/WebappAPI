using WebappAPI.Data.Genders;

namespace WebappAPI.Data.Genders
{
    public static class Data
    {
        public static IEnumerable<Gender> GetData()
        {
            return new[]
            {
                new Gender(1){Name="Male"},
                new Gender(2){Name="Female"}
            };
        }
    }
}
