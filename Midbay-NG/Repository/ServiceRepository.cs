using Midbay_NG.Data;
using Midbay_NG.MyModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Midbay_NG.Repository
{
    public class ServiceRepository
    {
        EFDBContext context;
        public ServiceRepository()
        {
            context = new EFDBContext();
        }

        public IEnumerable<Service> GetServices()
        {
            return context.Services;
        }
        public Service GetService(int Id)
        {
            return context.Services.Find(Id);
        }
        public void AddService(Service Service)
        {
            if(Service != null)
            {
                context.Services.Add(Service);
            }
            context.SaveChanges();
        }
        public void EditService(Service Service)
        {
            if (Service != null)
            {
               var entity = context.Services.Find(Service.Id);
                entity.Title = Service.Title;
                entity.Detail = Service.Detail;
            }
            context.SaveChanges();
        }

        public void DeleteService(int id)
        {
            var entity = context.Services.Find(id);
            if (entity != null)
            {
                context.Services.Remove(entity);
            }
            context.SaveChanges();
        }
    }
}