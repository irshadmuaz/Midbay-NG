using Midbay_NG.MyModels;
using Midbay_NG.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Midbay_NG.Controllers
{
    public class ContentController : Controller
    {
        public GalleryRepository repo;
        public ProjectRepository prepo;
        public ServiceRepository srepo;
        public ConsultantRepository crepo;
        public AimRepository arepo;
        public ContentController()
        {
            repo = new GalleryRepository();
            prepo = new ProjectRepository();
            srepo = new ServiceRepository();
            crepo = new ConsultantRepository();
            arepo = new AimRepository();
        }
        public ActionResult Aims()
        {
            return View(arepo.GetAims());
        }
        public ActionResult AddAim()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAim(Aim aim)
        {
            if(ModelState.IsValid)
            {
                arepo.AddAim(aim);
                return RedirectToAction("Aims");
            }
            ModelState.AddModelError(string.Empty, "Error");
            return View(aim);
        }
        public ActionResult EditAim(int Id)
        {
           
            return View(arepo.GetAim(Id));
        }
        [HttpPost]
        public ActionResult EditAim(Aim aim)
        {

            if (ModelState.IsValid)
            {
                arepo.EditAIm(aim);
                return RedirectToAction("Aims");
            }
            ModelState.AddModelError(string.Empty, "Error");
            return View(aim);
        }
        public ActionResult DeleteAim(int Id)
        {
            arepo.DeleteAim(Id);
            return RedirectToAction("Aims");
        }


    }
}