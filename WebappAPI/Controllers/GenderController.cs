using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebappAPI.Data;

namespace WebappAPI.Controllers
{
    public class GenderController : ControllerBase
    {
        private UniversityDbContext _dbContext;
        public GenderController(UniversityDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
    }
}
