using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_mailSystem.Services;
using E_mailSystem.Models;
using E_mailSystem.Data;

using E_mailSystem.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace E_mailSystem.Controllers
{
    public class EmailController : Controller
    {
        private readonly ApplicationDbContext _context;
        

        public EmailController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            try
            {
                var UserP = _context.Users.FirstOrDefault(uid => uid.UserName == User.Identity.Name);
                var Plan = _context.Plans.FirstOrDefault(pid => pid.Id == UserP.PlanId) as Plan;

                var Info = new PlanInfoVM()
                {
                    PlanName = Plan.PlanName,
                    MessagesLeft = Plan.Messages - UserP.MessagesSent

                };

                ViewData["PlanInfoVm"] = Info;
            }
            catch(Exception err)
            {

            }
           
            return View();
        }

        public IActionResult MessageSended()
        {
            return View();
        }

        public async Task<IActionResult> SendMessage1(string to, string subject, string body )
        {
            
            EmailService emailService = new EmailService();
            await emailService.SendEmailAsync(to, subject, body);
            

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult SendMessage(MessageModel model)
        {
            if (ModelState.IsValid)
            {
                SendMessage1(model.ToEmail, model.Subject, model.Body);
                //var ThisUser =  _context.Users
                //.FirstOrDefault(m => m.UserName == User.Identity.Name);
                
                
                //_context.Users.Update(ThisUser);
                //_context.SaveChanges();
                
            }

            return View("MessageSended", model);
        }
    }
}
