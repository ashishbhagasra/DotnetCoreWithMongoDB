using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDBInDotnetCore.Models;

namespace MongoDBInDotnetCore.Controllers
{
    public class TeacherRegistrationController : Controller
    {
        public IActionResult Index()
        {
            MongoDBContext dbContext = new MongoDBContext();

            List<TeacherRegistration> postList = dbContext.TeacherRegistrations.Find(m => true).ToList();

            return View(postList);
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            MongoDBContext dbContext = new MongoDBContext();
            var entity = dbContext.TeacherRegistrations.Find(m => m.Id == id).FirstOrDefault();

            return View(entity);
        }

        [HttpPost]
        public IActionResult Edit(TeacherRegistration entity)
        {
            MongoDBContext dbContext = new MongoDBContext();

            //you can use the UpdateOne to get higher performance if you need.
            dbContext.TeacherRegistrations.ReplaceOne(m => m.Id == entity.Id, entity);

            return View(entity);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(TeacherRegistration entity)
        {
            MongoDBContext dbContext = new MongoDBContext();

            entity.Id = Guid.NewGuid();

            dbContext.TeacherRegistrations.InsertOne(entity);

            return Redirect("/");
        }

        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            MongoDBContext dbContext = new MongoDBContext();

            dbContext.TeacherRegistrations.DeleteOne(m => m.Id == id);

            return Redirect("/");
        }
    }
}