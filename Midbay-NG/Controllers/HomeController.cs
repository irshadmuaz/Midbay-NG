using Microsoft.AspNet.Identity.Owin;
using Midbay_NG.Repository;
using Midbay_NG.Repository.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Midbay_NG.Controllers
{
    public class HomeController : Controller
    {
        ProjectRepository prepo;
        ConsultantRepository crepo;
        public HomeController()
        {
            prepo = new ProjectRepository();
            crepo = new ConsultantRepository();
        }
        public ActionResult Index()
        {
            ViewBag.Services = new ServiceRepository().GetServices();
            ViewBag.Consultants = new ConsultantRepository().GetConsultants();
            return View(new IndexM());
        }

        public ActionResult About()
        {
            ViewBag.services = new ServiceRepository().GetServices();
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Gallery()
        {
            var repo = new GalleryRepository();
           

                return View(repo.GetGallery);
        }
        public ActionResult ViewGallery(int Id)
        {
            var repo = new GalleryRepository();


            return View(repo.GetGallery.Where(m=>m.Id==Id).SingleOrDefault());
        }

        public ActionResult ViewProject(int Id)
        {
           
            var entity=prepo.GetProject(Id);
            ViewBag.projects = prepo.GetProjects.Where(m => m.category == entity.category);
            return View(entity);
        }
        public ActionResult Projects(string category)
        {
            ViewBag.categories = prepo.GetCategories();
            if (category!=null)
            {
                ViewBag.currentCategory = category;
                return View(prepo.GetProjects.Where(m => m.category == category));
              
            }
            else
            {
               
                return View(prepo.GetProjects);
            }
          
        }
        public ActionResult Affiliates()
        {
            return View(crepo.GetConsultants());
        }
       public ActionResult Login()
        {
            return View();
        }
       
       
    }
}