using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoreProjeUI.Controllers
{
    public class Experience2Controller : Controller
    {
        ExperienceManager experienceManager = new ExperienceManager(new EfExperience());

        public IActionResult Index()
        {
            return View();
        }

        //Burada ajax kullanacağımız için göndereceğimiz türleri json türüne convert ediyoruz
        //Listeleme işlemlerinde serialize kullanıyoruz
        //Bir şeyler gönderirken deserialize kullanıcaz (apilerde sık karşılaşıcaz) 
        public IActionResult ListExperience()
        {
            var values = JsonConvert.SerializeObject(experienceManager.GetList());
            return Json(values);
        }

        [HttpPost]
        public IActionResult AddExperience(Experience p)
        {
        
            experienceManager.TAdd(p);
            var values = JsonConvert.SerializeObject(p);
            return Json(values);
        }

        public IActionResult GetById(int ExperienceId)
        {
            var val = experienceManager.TGetById(ExperienceId);
            var values = JsonConvert.SerializeObject(val);
            return Json(values);
        }

        [HttpPost]
        public IActionResult DeleteExperience(int id)
        {
            var vls = experienceManager.TGetById(id);
            experienceManager.TDelete(vls);
            return NoContent();
        }

        [HttpPost]
        public IActionResult UpdateExperience(int id)
        {
            var vl = experienceManager.TGetById(id);
            experienceManager.TUpdate(vl);
            var vlues = JsonConvert.SerializeObject(vl);
            return Json(vlues);

        }
    }
}

