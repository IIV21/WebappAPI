﻿using Microsoft.AspNetCore.Mvc;
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

        private UniversityDbContext _dbContext;

        public PersonController(UniversityDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/<PersonController>
        [HttpGet]
        public IActionResult GetAllPersons()
        {
           // var results = _dbContext.Persons.Include(p => p.Gender);

            var getallpersonsresults = new List<GetAllPersonsResult>();
            foreach (var person in _dbContext.Persons.Include(p=>p.Gender))
            {
                var personResult = new GetAllPersonsResult();
                personResult.Id = person.Id;
                personResult.Name = person.Name;
                personResult.Surname = person.Surname;
                personResult.GenderId = person.GenderId.GetValueOrDefault();
                personResult.GenderName = person.Gender.Name;
                getallpersonsresults.Add(personResult);
            }
            return Ok(getallpersonsresults);
        }



        // GET api/<PersonController>/5
        [HttpGet("{id}")]
        public IActionResult GetPersonId(int id)
        {
            var person = _dbContext.Persons.FirstOrDefault(x => x.Id == id);
            var personCopy = person;
            if (person == null)
                return NotFound();
            else
                return Ok(personCopy);

        }

        // POST api/<PersonController>
        [HttpPost]
        public IActionResult Post([FromBody] CreatePersonRequest persoana)
        {
            var pers = new Person();
            pers.Name = persoana.Name;
            pers.Surname = persoana.Surname;
            pers.GenderId = persoana.GenderId;
            _dbContext.Persons.Add(pers);
            _dbContext.SaveChanges();

            CreatePersonResult createpersonresult = new CreatePersonResult();
            createpersonresult.Name = persoana.Name;
            createpersonresult.Surname = persoana.Surname;
            createpersonresult.GenderId = persoana.GenderId;
            return(Ok(createpersonresult));
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
                updatepersonresult.GenderId = person.GenderId.GetValueOrDefault();

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
    }
}
