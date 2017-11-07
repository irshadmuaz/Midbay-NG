using Midbay_NG.MyModels;
using Midbay_NG.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;

namespace Midbay_NG.Controllers
{

    public class AdminController : Controller
    {
        public GalleryRepository repo;
        public ProjectRepository prepo;
        public ServiceRepository srepo;
        public ConsultantRepository crepo;
        public AdminController()
        {
            repo = new GalleryRepository();
            prepo = new ProjectRepository();
            srepo = new ServiceRepository();
            crepo = new ConsultantRepository();
        }
       
        public ActionResult Gallery()
        {
            var x = repo.GetGallery;
            return View(repo.GetGallery);
        }
        public ActionResult AddGallery()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddGallery(Gallery gallery, HttpPostedFileBase image)
        {
            if(image !=null)
            {
                string documentname =  Guid.NewGuid().ToString() + image.FileName.Substring(image.FileName.Count() - 4);
                string filename = repo.path+ "\\"+ documentname ;
                if(!Directory.Exists(repo.path))
                {
                    Directory.CreateDirectory(repo.path);
                }
                image.SaveAs(filename);
                gallery.image = filename;
                gallery.filename = documentname;
                

            }
            gallery.date = DateTime.Now;
            repo.AddGallery(gallery);
            return RedirectToAction("Gallery");
        }

        public ActionResult DeleteGallery(int Id)
        {
            repo.DeleteGallery(Id);
            return RedirectToAction("Gallery");
        }
        public ActionResult EditGallery(int Id)
        {
            return View(repo.GetGallery.Where(p=>p.Id == Id).SingleOrDefault());
        }
        [HttpPost]
        public ActionResult EditGallery(Gallery gallery, HttpPostedFileBase image)
        {
            if (image != null)
            { 

                string documentname = "\\" + Guid.NewGuid().ToString() + image.FileName.Substring(image.FileName.Length - 4);
                string filename = repo.path + documentname;
                if (!Directory.Exists(repo.path))
                {
                    Directory.CreateDirectory(repo.path);
                }
                image.SaveAs(filename);
                gallery.image = filename;
                gallery.filename = documentname;


            }
            gallery.date = DateTime.Now;
            repo.EditGallery(gallery);
            return RedirectToAction("Gallery");
        }

        public ActionResult Projects()
        {
            
            return View(prepo.GetProjects);
        }

        public ActionResult AddProject()
        {
           ViewBag.categories= prepo.GetCategories();
            return View();
        }
        [HttpPost]
        public ActionResult AddProject(Project project,IEnumerable<HttpPostedFileBase> files)
        {
            if (ModelState.IsValid && files !=null)
            {
                var compressed = repo.CompressedPath;
                var path = repo.ProjectImages;

              
                    project.Images = prepo.SaveProjectImage(files, path, compressed);
                //prepo.CompressImage(repo.CompressedPath, project.Images);
                
                prepo.AddProject(project);
               
                TempData["status"] = "Success";
            }
            else
            {
                ViewBag.categories = prepo.GetCategories();
                ModelState.AddModelError(string.Empty, "Error");
                return View(project);
            }

            return RedirectToAction("Projects");
        }
        public ActionResult EditProject(int Id)
        {
            ViewBag.categories = prepo.GetCategories();
            return View(prepo.GetProject(Id));
        }
        [HttpPost]
        public ActionResult EditProject(Project project, IEnumerable<HttpPostedFileBase> files)
        {
            if (ModelState.IsValid)
            {
                string images = prepo.GetProject(project.Id).Images;
                var compressed = repo.CompressedPath;
                var path = repo.ProjectImages;


                project.Images = prepo.EditProjectImage(files, path, images);
                //prepo.CompressImage(repo.CompressedPath, project.Images);

                prepo.EditProject(project);

                TempData["status"] = "Success";
            }
            else
            {
                ViewBag.categories = prepo.GetCategories();
                ModelState.AddModelError(string.Empty,"Error");
                return View(prepo.GetProject(project.Id));
            }

            return RedirectToAction("Projects");
        }
        public ActionResult DeleteProject(int Id)
        {
            prepo.DeleteProject(Id);
            return RedirectToAction("Projects");
        }
        [Authorize]
        public ActionResult Services()
        {
            var x = Request.IsAuthenticated;
            return View(srepo.GetServices());
        }
        public ActionResult AddService()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddService(Service ser)
        {
            if(ModelState.IsValid)
            {
                srepo.AddService(ser);
                return RedirectToAction("Services");
            }
            else
            {
                return View(ser);
            }
           
        }
        public ActionResult EditService(int Id)
        {
            return View(srepo.GetService(Id));
        }
        [HttpPost]
        public ActionResult EditService(Service ser)
        {
            if (ModelState.IsValid)
            {
                srepo.EditService(ser);
                return RedirectToAction("Services");
            }
            else
            {
                return View(ser);
            }

        }
        public ActionResult DeleteService(int Id)
        {
            srepo.DeleteService(Id);
            return RedirectToAction("Services");
        }

        //consultants

        public ActionResult Consultants()
        {
            return View(crepo.GetConsultants());
        }
        public ActionResult AddConsultant()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddConsultant(Consultant ser, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                if(image !=null)
                ser.Image =  crepo.SaveImage(image);
                crepo.AddConsultant(ser);
                return RedirectToAction("Consultants");
            }
            else
            {
                return View(ser);
            }

        }
        public ActionResult EditConsultant(int Id)
        {
            return View(crepo.GetConsultant(Id));
        }
        [HttpPost]
        public ActionResult EditConsultant(Consultant ser,HttpPostedFileBase imageE)
        {
            if (ModelState.IsValid)
            {
                if (imageE != null)
                     ser.Image = crepo.SaveImage(imageE);
                crepo.EditConsultant(ser);
                return RedirectToAction("Consultants");
            }
            else
            {
                return View(ser);
            }

        }
        public ActionResult DeleteConsultant(int Id)
        {
            crepo.DeleteConsultant(Id);
            return RedirectToAction("Consultants");
        }
        public ActionResult DeletePI(string image, int Id)
        {
            prepo.DeleteDBI(image, Id);
           
             
          
            return PartialView();
        }
        


    }
}