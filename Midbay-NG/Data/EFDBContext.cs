using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Midbay_NG.MyModels;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Midbay_NG.Data
{
    public class EFDBContext:DbContext
    {
        //public EFDBContext():base("Midbay")
        //{

        //} This is how you instruct EF to point to your desired database connectionstring
        //with connection name :"Midbay"
        public DbSet<Gallery> Gallerys { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Consultant> Consultants { get; set; }
        public DbSet<Aim> Aims { get; set; }
        
    }
}