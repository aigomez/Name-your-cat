using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using API.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatController : ControllerBase
    {
        private IMongoCollection<Cat> Cats;

        public CatController(IMongoClient client)
        {
            var db = client.GetDatabase("Cats");
            Cats = db.GetCollection<Cat>("Cats");
        }

        // GET api/Cat
        [HttpGet]
        public List<Cat> Get()
        {
            return Cats.Find(s => true).ToList();
        }

        // GET api/Cat/{gender}
        [HttpGet("{gender}")]
        public List<Cat> Get(char gender)
        {   
            switch (gender)
            {
                case 'M':
                    return Cats.Find(cat => cat.Gender == "M").ToList();

                case 'F':
                    return Cats.Find(cat => cat.Gender == "F").ToList();

                default:
                    return new List<Cat>(); // it returns an empty list
            }
        }

        // POST api/Cat/
        [HttpPost]
        public Cat Post(Cat cat)
        {
            Cats.InsertOne(cat);
            return cat;
        }

        // PUT api/Cat/
        [HttpPut]
        public string Put(Cat catOrigin)
        {
            Cat CatTarget = Cats.Find(cat => cat.Id == catOrigin.Id).First();
            CatTarget.UpdateCat(CatTarget, catOrigin);
            Cats.ReplaceOne(cat => cat.Id == catOrigin.Id, CatTarget);
            return "Cat has been updated";
        }

        // DELETE api/Cat/
        [HttpDelete]
        public string Delete(Cat catObj)
        {
            Cats.DeleteOne(cat => cat.Id == catObj.Id);
            return "Cat has been deleted";
        }
    }
}
