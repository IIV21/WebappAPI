using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebappAPI.Data;
using WebappAPI.Data.Cursuri;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebappAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CursController : ControllerBase
    {

        private UniversityDbContext _dbContext;

        public CursController(UniversityDbContext dbContext)
        {
            _dbContext = dbContext;
        }



        // GET: api/<CursController>
        [HttpGet]
        public IActionResult GetAllCurses()
        {
            var coursesList = new List<GetAllCoursesResult>();
            foreach (var course in _dbContext.Courses)
            {
                var courseResult = new GetAllCoursesResult();
                courseResult.Id = course.Id;
                courseResult.Name = course.Name;
                courseResult.Active = course.Active;
                coursesList.Add(courseResult);
            }
            return Ok(coursesList);
        }

        // GET api/<CursController>/5
        [HttpGet("{id}")]
        public IActionResult GetCourseId(int id)
        {
            var course = _dbContext.Courses.FirstOrDefault(x => x.Id == id);
            var courseCopy = course;
            if (course == null)
                return NotFound();
            else
                return Ok(courseCopy);

        }

        // POST api/<CursController>
        [HttpPost]
        public IActionResult Post([FromBody] UpdateCoursesRequest course)
        {
            var courseRequest = new Curs();
            courseRequest.Name = course.Name;
            courseRequest.Active = course.Active;
            _dbContext.Courses.Add(courseRequest);
            _dbContext.SaveChanges();
            CreateCourseResult createCourseResult = new CreateCourseResult();
            createCourseResult.Name = courseRequest.Name;
            createCourseResult.Active = courseRequest.Active;

            return (Ok(createCourseResult));
        }

        // PUT api/<CursController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateCoursesRequest course)
        {
            var curs = _dbContext.Courses.FirstOrDefault(x => x.Id == id);
            if (curs == null)
                return NotFound();
            else
            {
                curs.Name = course.Name;
                curs.Active = course.Active;
                _dbContext.SaveChanges();

                UpdateCoursesRequest updatecoursesresult = new UpdateCoursesRequest();
                updatecoursesresult.Name = course.Name;
                updatecoursesresult.Active = course.Active;

                return Ok(updatecoursesresult);
            }

        }

        // DELETE api/<CursController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var curs = _dbContext.Courses.FirstOrDefault(x => x.Id == id);
            if (curs == null)
                return NotFound();
            else
            {
                _dbContext.Courses.Remove(curs);
                _dbContext.SaveChanges();
                return Ok("deleted");
            }
        }

        [HttpPost]
        public IActionResult AddByID([FromBody] InsertCoursePerson ics)
        {
            var cursPersoana = new CoursePerson();

            cursPersoana.CourseId = ics.CourseId;
            cursPersoana.PersonId = ics.PersonId;

            _dbContext.CoursePerson.Add(cursPersoana);
            _dbContext.SaveChanges();
            var cursResult = new InserCoursePersonResult();
            cursResult.CourseId = ics.CourseId;
            cursResult.PersonId = ics.PersonId;
            return (Ok(cursResult));
        }

        [HttpDelete]
        public IActionResult DeleteById(int idCurs, int idPersoana)
        {
            var course = _dbContext.CoursePerson.FirstOrDefault(x => x.CourseId == idCurs && x.PersonId == idPersoana);
            if (course == null)
                return NotFound();
            else
            {
                _dbContext.CoursePerson.Remove(course);
                _dbContext.SaveChanges();
                return Ok("deleted");
            }
        }
        [HttpGet]
        public IActionResult GetAllById(int idCurs)
        {
            var courseList = new List<CoursePersonResult>();
            var items = _dbContext.CoursePerson.Where(p => p.CourseId == idCurs).Include(p => p.Person).ThenInclude(p => p.Gender).Include(p => p.Course);
            foreach (var person in items)
            {
                var courseResult = new CoursePersonResult();
                courseResult.CourseId = person.CourseId.GetValueOrDefault();
                courseResult.PersonId = person.PersonId.GetValueOrDefault();
                courseResult.PersonName = person.Person.Name;
                courseResult.PersonSurname = person.Person.Surname;
                courseResult.GenderName = person.Person.Gender.Name;
                courseResult.CourseName = person.Course.Name;
                courseList.Add(courseResult);
            }
            return Ok(courseList);
        }
    }
}
