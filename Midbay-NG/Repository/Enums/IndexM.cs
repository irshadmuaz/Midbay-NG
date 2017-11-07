using Midbay_NG.MyModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Midbay_NG.Repository.Enums
{
    public class IndexM
    {
        //public IEnumerable<Aim> Aims
        //{
           
        //    get {
        //        List<Aim> aims = new List<Aim>();
        //        var x = new AimRepository().GetAims();
        //        if(x.Count() < 3)
        //        {
                   
        //            for(int i =x.Count(); i<3;i++)
        //            {
        //                aims.Add(new Aim { Id = 0 });
        //            }
        //        }
        //        return aims;
        //        }
        //}
        public IEnumerable<Project> Projects
        {
            get { return new ProjectRepository().GetProjects.Take(6); }
        }
    }
   
}