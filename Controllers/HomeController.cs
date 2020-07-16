using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using port.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace port.Controllers
{
    
    public class HomeController : Controller
    {
        private MyContext _context { get; set; }
        public User GetUser()
        {
            return _context.Users.FirstOrDefault(u => u.UserId ==HttpContext.Session.GetInt32("userId"));
        }
        public HomeController (MyContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("home")]
        public IActionResult Home()
        {
            return View("Index");
        }
        [HttpGet("about")]
        public IActionResult About()
        {
            return View();
        }
        [HttpGet("projects")]
        public IActionResult Projects()
        {
            return View();
        }
        [HttpGet("contact")]
        public IActionResult Contact()
        {
            return View();
        }
        [HttpGet("skills")]
        public IActionResult Skills()
        {
            return View();
        }
        [HttpPost("contact/info")]
        public IActionResult ContactInfo(User Msg)
        {
            User current = GetUser();
            if(ModelState.IsValid)
            {
                Msg.UserId = Msg.UserId;
                _context.Users.Add(Msg);
                _context.SaveChanges();
                return RedirectToAction("Home");
            }
            return View("Contact");
        }


        
    }
}
