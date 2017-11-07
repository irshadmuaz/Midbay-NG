using Midbay_NG.Data;
using Midbay_NG.MyModels;
using Midbay_NG.Operators;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Hosting;

namespace Midbay_NG.Repository
{
    public class ProjectRepository
    {
        private EFDBContext context = new EFDBContext();
        public IEnumerable<Project> GetProjects
        {
           get
            {
               
                    return context.Projects;
                
            }

        }

        public Project GetProject(int Id)
        {
            
                return context.Projects.Find(Id);
            
        }
        public void EditProject(Project project)
        {
            if(project!=null)
            {
                   
                  var entity =  context.Projects.Find(project.Id);
                entity.Name = project.Name;
                entity.Date = project.Date;
                entity.Location = project.Location;
                entity.Client = project.Client;
                entity.Description = project.Description;
                entity.category = project.category;
                entity.featured = project.featured;
                entity.Images = project.Images;
                
            }
            context.SaveChanges();
        }
        public IEnumerable<string> GetCategories()
        {
           
            List<string> cats = new List<string>();
           foreach(var t in context.Projects)
            {
                cats.Add(t.category);
              
            }
            return cats.Distinct();
            
        }
        public string SaveProjectImage(IEnumerable<HttpPostedFileBase> file,string path,string compressed)
        {
            string location="";
            string imagelocation = "";
            
            if (file!=null)
            {
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                foreach (var t in file)
                {
                    if(t!=null)
                    {                     
                      string  location1 =  Guid.NewGuid() + t.FileName.Substring(t.FileName.Length - 4);
                        location = path + location1;                     
                        t.SaveAs(location);
                        imagelocation += location + ",";
                        
                    }                
                }
            }
            imagelocation= imagelocation.Substring(0,imagelocation.Length - 1);
            return imagelocation;
        }
        public string EditProjectImage(IEnumerable<HttpPostedFileBase> file, string path, string images)
        {
            string location = "";
            string imagelocation = images +",";

            if (file != null)
            {
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                foreach (var t in file)
                {
                    if (t != null)
                    {
                        string location1 = Guid.NewGuid() + t.FileName.Substring(t.FileName.Length - 4);
                        location = path + location1;
                        t.SaveAs(location);
                        imagelocation += location + ",";

                    }
                }
            }
            imagelocation = imagelocation.Substring(0, imagelocation.Length - 1);
            return imagelocation;
        }

        public void AddProject(Project project)
        {
            if(project !=null)
            {
                context.Projects.Add(project);
            }
            context.SaveChanges();
        }

        public void DeleteProject(int id)
        {
          
            var entity = context.Projects.Find(id);
            DeleteProjectImage(entity.Images);
            context.Projects.Remove(entity);
            context.SaveChanges();
        }
        public void DeleteProjectImage(string locations)
        {
           var Images= locations.Split(',');
            foreach(var t in Images)
            {
                if (File.Exists(t))
                    File.Delete(t);
            }
        }

        //public void CompressImage(string saveLocation,string imageLocation)
        //{
        //    foreach (var t in imageLocation.Split(','))
        //    {
        //        if (!Directory.Exists(saveLocation))
        //        {
        //            Directory.CreateDirectory(saveLocation);
        //        }
        //        string filename = t.Substring(t.LastIndexOf('\\') + 1);
        //       var newImage = ImageCompression.CreateThumbnail(t, 300, 150);
        //        newImage.Save(saveLocation + filename);
        //    }


           
        //}
        public void DeleteDBI(string image,int Id)
        {
            var item = context.Projects.Find(Id);
            if(item.Images.Contains("," + image))
            {
                item.Images = item.Images.Replace("," + image, "");
            }
            else if(item.Images.Contains(image + ","))
            {
                item.Images = item.Images.Replace(image + ",", "");
            } 
            else
            {
                item.Images = item.Images.Replace(image, "");
            }
            context.SaveChanges();

            File.Delete(image);
            
           
        }

    }
}