using Midbay_NG.Data;
using Midbay_NG.MyModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Midbay_NG.Repository
{
    public class ConsultantRepository
    {
        EFDBContext context;
        public ConsultantRepository()
        {
            context = new EFDBContext();
        }

        public IEnumerable<Consultant> GetConsultants()
        {
            return context.Consultants;
        }
        public Consultant GetConsultant(int Id)
        {
            return context.Consultants.Find(Id);
        }
        public void AddConsultant(Consultant Service)
        {
            if (Service != null)
            {
                context.Consultants.Add(Service);
            }
            context.SaveChanges();
        }
        public void EditConsultant(Consultant Service)
        {
            if (Service != null)
            {
                var entity = context.Consultants.Find(Service.Id);
                entity.Name = Service.Name;
                entity.Description = Service.Description;
                if(Service.Image != null)
                {
                    File.Delete(entity.Image);
                    entity.Image = Service.Image;
                   
                }
               
              
            }
            context.SaveChanges();
        }

        public void DeleteConsultant(int id)
        {
            var entity = context.Consultants.Find(id);
            if (entity != null)
            {
                context.Consultants.Remove(entity);
                if (entity.Image != null)
                {
                    if (File.Exists(entity.Image))
                    {
                        File.Delete(entity.Image);
                    }
                }
            }
            context.SaveChanges();
        }

        public string SaveImage(HttpPostedFileBase image)
        {
            string filename = "";
            if (image != null)
            {
                var path = new GalleryRepository().ConsultantImages;
                string documentname = Guid.NewGuid().ToString() + image.FileName.Substring(image.FileName.Count() - 4);
                filename = path  + documentname;
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                image.SaveAs(filename);
              
            }
            return filename;
        }
    }
}