using CGBlcok.Common;
using CGBlcok.DAL;
using CGBlcok.DAL.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CGBlcok.Controllers
{
    public class ManagerController : Controller
    {
        BlockContext context = new BlockContext();
        // GET: Manager
        public ActionResult Index()
        {
            List<User> uList = context.Users.ToList();
            return View(uList);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            user.Roles = new List<Role> { new Role { RoleName = "普通用户", RoleLevel = "1" }, new Role { RoleName = "成大事", RoleLevel = "2" } };

            user.CreateTime = DateTime.Now;
            context.Users.Add(user);
            context.SaveChanges();

            using (var redisClient = RedisManager.GetClient())
            {              
                redisClient.Set<string>(user.LoginName, user.LoginName, DateTime.Now.AddSeconds(60));         
            }
            return RedirectToAction("Index");
        }


        public ActionResult Details()
        {
            int id = int.Parse(Request["uid"]);
            User user = context.Users.Where(u => u.Id == id).FirstOrDefault();
            //User user = context.Users.Include("Roles").Where(u => u.Id == id).FirstOrDefault();
            return View(user);
        }

        public ActionResult Delete()
        {
            int id = int.Parse(Request["uid"]);
            User user = context.Users.Where(u => u.Id == id).FirstOrDefault();
            if (user != null)
            {
                context.Users.Remove(user);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit()
        {
            int id = int.Parse(Request["uid"]);
            User user = context.Users.Where(u => u.Id == id).FirstOrDefault();
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(User user)
        {
            context.Entry<User>(user).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Details", new { uid = user.Id });
        }
    }
}