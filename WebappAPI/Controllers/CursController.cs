using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebappAPI.Data;
using WebappAPI.Data.Cursuri;
using WebappAPI.Data.Persons;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebappAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CursController : ControllerBase
    {
        private readonly IMapper _mapper;
        private UniversityDbContext _dbContext;

        public CursController(IMapper mapper, UniversityDbContext dbContext)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }



        // GET: api/<CursController>
        [HttpGet]
        public IActionResult GetAllCurses() 
        {
            var coursesList =  _dbContext.Courses;
            var courseListResult = _mapper.Map<List<GetAllCoursesResult>>(coursesList);
            return Ok(courseListResult);
        }

        // GET api/<CursController>/5
        [HttpGet("{id}")]
        public IActionResult GetCourseId(int id)
        {
            var course = _dbContext.Courses.FirstOrDefault(x => x.Id == id);
            if (course == null)
                return NotFound();
            else
            {
                var courseCopy = _mapper.Map<GetCourseResult>(course);
                return Ok(courseCopy);
            }

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

                var updatecoursesresult = _mapper.Map<Curs>(curs);


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
            var cursPersoana = _mapper.Map<CoursePerson>(ics);

            _dbContext.CoursePerson.Add(cursPersoana);
            _dbContext.SaveChanges();
            var cursResult = _mapper.Map<InserCoursePersonResult>(ics);
            return (Ok(cursResult));
        }
        [HttpPost]
        public IActionResult AddByName([FromBody] AddByCoursePerson abcp)
        {
            
            var verifyPerson = _dbContext.Persons.FirstOrDefault(x => x.Name == abcp.Name && abcp.Surname == x.Surname);
            if (verifyPerson == null)
            {
                var insertPerson = new Person();
                insertPerson.Name = abcp.Name;
                insertPerson.Surname = abcp.Surname;
                insertPerson.Gender = _dbContext.Genders.FirstOrDefault(x => x.Name == "Male");
                _dbContext.Persons.Add(insertPerson);
                _dbContext.SaveChanges();
                var personResult = new CoursePerson();
                personResult.CourseId = abcp.CourseId;
                personResult.PersonId = insertPerson.Id;

                _dbContext.CoursePerson.Add(personResult);
                _dbContext.SaveChanges();

                var insertPersonResult = new CreatePersonResult();
                insertPersonResult.Name = abcp.Name;
                insertPersonResult.Surname = abcp.Surname;
                insertPersonResult.GenderId = insertPerson.GenderId;
                return (Ok(insertPersonResult));
            }
            else
            {
                var item = _dbContext.CoursePerson.FirstOrDefault(x => x.CourseId == abcp.CourseId && x.PersonId == verifyPerson.Id);
                if (item == null)
                {
                    var personResult = new CoursePerson();
                    personResult.CourseId = abcp.CourseId;
                    personResult.PersonId = verifyPerson.Id;

                    _dbContext.CoursePerson.Add(personResult);
                    _dbContext.SaveChanges();

                    var result = new AddByCoursePersonResult();
                    result.CourseId = abcp.CourseId;
                    result.PersonId = verifyPerson.Id;
                    return Ok(result);
                }   
                else
                    return BadRequest("person already at this course");
            }
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
