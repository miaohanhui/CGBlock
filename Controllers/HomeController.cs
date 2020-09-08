using CGBlcok.Common;
using CGBlcok.DAL;
using CGBlcok.MongoDAL.Model;
using MongoDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CGBlcok.Controllers
{
    public class HomeController : Controller
    {
        MongoDBHelper mongohelper = new MongoDBHelper();
        BlockContext context = new BlockContext();
        public ActionResult Index()
        {
            using (var redisClient = RedisManager.GetClient())
            {
                string UserId = redisClient.Get<string>("UserId");
                if (string.IsNullOrEmpty(UserId)) //初始化缓存
                {
                    //TODO 从数据库中获取数据，并写入缓存
                    UserId = context.Users.FirstOrDefault().LoginName;
                    redisClient.Set<string>("UserId", UserId, DateTime.Now.AddSeconds(30));
                    ViewBag.LoginUserName = UserId;

                    //redisClient.IncrementValue("norediscount");
                }
                else
                {
                    ViewBag.LoginUserName = UserId;
                }
            }

            List<Article> articleList = mongohelper.GetList<Article>().OrderBy(c=>c.orderId).ToList();
            return View(articleList);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public JsonResult Like()
        {
            string _id = Request["_id"];
            _id = "article:" + _id;
            string likes = "0";
            using (var redisClient = RedisManager.GetClient())
            {
                redisClient.IncrementValue(_id);
                likes = redisClient.Get<string>(_id);
            }
            return Json(likes);
        }
    }
}