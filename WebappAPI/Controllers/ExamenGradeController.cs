using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebappAPI.Data;
using WebappAPI.Data.Grades;

namespace WebappAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ExamenGradeController : ControllerBase
    {
        private UniversityDbContext _dbContext;

        public ExamenGradeController(UniversityDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllGrades()
        {
            var gradeList = new List<GetAllGradesResult>();
            foreach(var grade in _dbContext.ExamenGrade)
            {
                var gradeResult = new GetAllGradesResult();
                gradeResult.Grade = grade.Grade;
                gradeResult.Id = grade.Id;
                gradeResult.CourseId = grade.CourseId;
                gradeResult.PersonId = grade.PersonId;
                gradeList.Add(gradeResult);
            }
            return Ok(gradeList);
        }
        [HttpGet("{id}")]
        public IActionResult GetGradeById(int id)
        {
            var gradeResult = _dbContext.ExamenGrade.FirstOrDefault(x=>x.Id == id);
            var gradeCopy = gradeResult;
            if(gradeResult != null)
                return Ok(gradeCopy);
            else
                return NotFound();
        }

        [HttpPost]
        public IActionResult Post([FromBody] PostGradeRequest pgr)
        {
            var gradeRequest = new ExamenGrade();
            gradeRequest.Grade = pgr.Grade;
            gradeRequest.CourseId = pgr.CourseId;
            gradeRequest.PersonId = pgr.PersonId;
            _dbContext.ExamenGrade.Add(gradeRequest);
            _dbContext.SaveChanges();

            var gradeResult = new PostGradeResult();
            gradeResult.Id = gradeRequest.Id;
            gradeResult.Grade = gradeRequest.Grade;
            gradeResult.CourseId= gradeRequest.CourseId;
            gradeResult.PersonId= gradeRequest.PersonId;
            return Ok(gradeResult);
        }

        [HttpPut("{id}")]
        public IActionResult Put (int id, [FromBody] UpdateCourseRequest ucr)
        {
            var examenGrade = _dbContext.ExamenGrade.FirstOrDefault(x => x.Id == id);
            if (examenGrade == null)
                return NotFound();
            else
            {
                examenGrade.CourseId = ucr.CourseId;
                examenGrade.PersonId = ucr.PersonId;
                examenGrade.Grade = ucr.Grade;

                UpdateCourseResult updateCourseResult = new UpdateCourseResult();
                updateCourseResult.Id = examenGrade.Id;
                updateCourseResult.CourseId = examenGrade.CourseId;
                updateCourseResult.PersonId = examenGrade.PersonId;
                updateCourseResult.Grade = examenGrade.Grade;
                return Ok(updateCourseResult);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var examenGrade = _dbContext.ExamenGrade.FirstOrDefault(x=>x.Id == id);
            if(examenGrade != null)
            {
                _dbContext.ExamenGrade.Remove(examenGrade);
                _dbContext.SaveChanges();
                return Ok("Deleted Item");
            }
            else
                return NotFound();
        }

        [HttpGet]
        public IActionResult GetEverythingWithStrig(string s)
        {
            var itemList = new List<GetEverythingWithStringResult>();
            var items = _dbContext.ExamenGrade.Include(x => x.Person).Include(x => x.Course)
                         .Where(x => x.Person.Name.Contains(s) || x.Person.Surname.Contains(s));
            if (!items.Any())
                return NotFound();
            else
            foreach(var item in items)
            {
                var getValue = new GetEverythingWithStringResult();
                getValue.Name = item.Person.Name;
                getValue.Surname = item.Person.Surname;
                getValue.Grade = item.Grade;
                getValue.Course = item.Course.Name;
                itemList.Add(getValue);
            }
            return (Ok(itemList));
        }
    }
}
