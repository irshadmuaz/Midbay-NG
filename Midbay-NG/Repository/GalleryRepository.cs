using Midbay_NG.Data;
using Midbay_NG.MyModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace Midbay_NG.Repository
{
    public class GalleryRepository
    {
        private EFDBContext context = new EFDBContext();
       

        public IQueryable<Gallery> GetGallery
        {
            get { return context.Gallerys; }
        }
        public void AddGallery(Gallery gallery)
        {
            if(gallery!=null)
            {
                context.Gallerys.Add(gallery);
            }
            context.SaveChanges();
        }
         public void EditGallery(Gallery gallery)
        {
            var g = context.Gallerys.Find(gallery.Id);
            if (g!=null)
            {
                g.name = gallery.name;
                g.date = gallery.date;
               if(gallery.image!=null)
                {
                    try
                    {
                        File.Delete(g.image);
                        
                    }
                    catch(Exception e)
                    {
                        
                    }
                    g.image = gallery.image;
                    g.filename = gallery.filename;

                }
            }
            context.SaveChanges();
        }

        public string path
        {
            get { return HostingEnvironment.MapPath("/Uploads/Images"); }
        }
        public string ProjectImages
        {
            get { return HostingEnvironment.MapPath("/Uploads/ProjectImages/"); }

        }
        public string CompressedPath
        {
            get { return HostingEnvironment.MapPath("/Uploads/CompressedProjectImages/"); }

        }
        public string ConsultantImages
        {
            get { return HostingEnvironment.MapPath("/Consultants/"); }
        }

        public void DeleteGallery(int id)
        {
           
           var gal = context.Gallerys.Find(id);
            if(gal !=null)
            {
                context.Gallerys.Remove(gal);
                if(gal.image!=null)
                {
                    if(File.Exists(gal.image))
                    {
                        File.Delete(gal.image);
                    }
                }
            }
            context.SaveChanges();
        }
    }
}