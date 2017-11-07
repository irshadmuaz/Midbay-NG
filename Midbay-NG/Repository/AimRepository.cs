using Midbay_NG.Data;
using Midbay_NG.MyModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Midbay_NG.Repository
{
    public class AimRepository
    {
        EFDBContext context;
        public AimRepository()
        {
            context = new EFDBContext();
        }

        public IEnumerable<Aim> GetAims()
        {
            return context.Aims;
        }
        public Aim GetAim(int Id)
        {
            return context.Aims.Find(Id);
        }
        public void AddAim(Aim aim)
        {
            if (aim != null)
            {
                context.Aims.Add(aim);
            }
            context.SaveChanges();
        }
        public void EditAIm(Aim aim)
        {
            if (aim != null)
            {
                var entity = context.Aims.Find(aim.Id);
                entity.title = aim.title;
                entity.details = aim.details;
            }
            context.SaveChanges();
        }

        public void DeleteAim(int id)
        {
            var entity = context.Aims.Find(id);
            if (entity != null)
            {
                context.Aims.Remove(entity);
            }
            context.SaveChanges();
        }
    }
}