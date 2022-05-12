using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebappAPI.Data;
using WebappAPI.Data.Persons;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebappAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IMapper _mapper;

        private readonly IMediator _mediator;

        private UniversityDbContext _dbContext;

        public PersonController(IMediator mediator,IMapper mapper,UniversityDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
            _mediator = mediator;
        }

        // GET: api/<PersonController>
        [HttpGet]
        public async Task<IActionResult> GetAllPersons()
        {

            var persons= await _mediator.Send(new GetAllPersonsQuery());
            return Ok(persons);
            /*  // var results = _dbContext.Persons.Include(p => p.Gender);
            var getPersonResultListx = _dbContext.Persons.Include(p => p.Gender);
            var getallpersonsresults = _mapper.Map<List<GetAllPersonsResult>>(getPersonResultListx);
            *//*foreach (var person in _dbContext.Persons.Include(p=>p.Gender))
            {
                var personResult = new GetAllPersonsResult();
                personResult.Id = person.Id;
                personResult.Name = person.Name;
                personResult.Surname = person.Surname;
                personResult.GenderId = person.GenderId;
                personResult.GenderName = person.Gender.Name;
                getallpersonsresults.Add(personResult);
            *//*
            return Ok(getallpersonsresults);*/
        }



        // GET api/<PersonController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var personFilterQuery = new GetPersonFilterQuery(id);
            var response = await _mediator.Send(personFilterQuery);
            return Ok(response);
        }

        // POST api/<PersonController>
        [HttpPost]
        public IActionResult Post(string personName, string personSurname,  int genderID)
        {
            var person = new PostPersonCommand(personName, personSurname, genderID);
            return Ok(_mediator.Send(person)); // aici trebuie facuta o clasa care intoarce efectiv datele necesare, nu toate de la persoana.
        }



        // PUT api/<PersonController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdatePersonRequest persoana)
        {
            var person = _dbContext.Persons.FirstOrDefault(x => x.Id == id);
            if (person == null)
                return NotFound();
            else
            {
                person.Name = persoana.Name;
                person.Surname = persoana.Surname;
                person.GenderId = persoana.GenderId;

                _dbContext.SaveChanges();

                UpdatePersonResult updatepersonresult = new UpdatePersonResult();
                updatepersonresult.Name = persoana.Name;
                updatepersonresult.Surname = persoana.Surname;
                updatepersonresult.GenderId = person.GenderId;

                return Ok(updatepersonresult);
            }

        }

        // DELETE api/<PersonController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var person = _dbContext.Persons.FirstOrDefault(x => x.Id == id);
            if (person == null)
                return NotFound();
            else
            {
                _dbContext.Persons.Remove(person);
                _dbContext.SaveChanges();
                return Ok("Person deleted");
            }

        }

        [HttpGet]
        public async Task<IActionResult> Get(string Name, string Surname, int varsta)
        {
            var personRequest = new GetPersonStringQuery(Name, Surname, varsta);
            var personResult =  _mediator.Send(personRequest).Result;
            return Ok(personResult);
        }

        [HttpPost]
        public async Task<IActionResult> Get4Ints(_4IntRequest get)
        {
            var request = get;
            var result = _mediator.Send(request).Result;
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> SumIntList()
        {
            var List = new IntListQuery();
           var result = _mediator.Send(List).Result;
            return Ok(result);
        }
    }
}
