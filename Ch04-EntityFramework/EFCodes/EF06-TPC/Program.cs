using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF06_TPC
{
    class Program
    {
        static void Main(string[] args)
        {
            Initialize();

            using (var context = new CompanyDbContext())
            {
                context.Cameras.Count();

                Console.WriteLine("Camera Caption = {0}",
                    context.Cameras.OfType<Product>().First().Caption);
                Console.WriteLine("SingleReflexCamera Caption = {0}",
                    context.SingleReflexCameras.OfType<Product>().First().Caption);
                Console.WriteLine("Lens Caption = {0}",
                    context.Lenses.OfType<Product>().First().Caption);
            }

            Console.Read();
        }

        static void Initialize()
        {
            using (var context = new CompanyDbContext())
            {
                if (context.Cameras.Count() == 0)
                {
                    context.Cameras.Add(new Camera()
                    {
                        Id = 1,
                        Caption = "PowerShot G1 X Mark II",
                        Manufacturer = "Canon",
                        TypeNumber = "PowerShot G1 X Mark II",
                        Lens = "12.5mm (W) - 62.5mm (T)"
                    });

                    context.SaveChanges();
                }

                if (context.SingleReflexCameras.Count() == 0)
                {
                    context.SingleReflexCameras.Add(new SingleReflexCamera()
                    {
                        Id = 2,
                        Caption = "EOS-1D X",
                        Manufacturer = "Canon",
                        TypeNumber = "EOS-1D X",
                        LensMount = "Canon EF mount"
                    });

                    context.SaveChanges();
                }

                if (context.Lenses.Count() == 0)
                {
                    context.Lenses.Add(new Lens()
                    {
                        Id = 3,
                        Caption = "EF 16-35mm f/2.8L II USM",
                        Manufacturer = "Canon",
                        TypeNumber = "EF 16-35mm f/2.8L II USM",
                        FocalLength = "16-35mm",
                        MaxAperture = "F2.8"
                    });

                    context.SaveChanges();
                }
            }
        }
    }

    public class CompanyDbContext : DbContext
    {
        public CompanyDbContext() : base("name=CompanyDb") { }

        public virtual DbSet<Camera> Cameras { get; set; }
        public virtual DbSet<SingleReflexCamera> SingleReflexCameras { get; set; }
        public virtual DbSet<Lens> Lenses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>();

            modelBuilder.Entity<Camera>()
                .Map(m => m.MapInheritedProperties().ToTable("Cameras"));
            modelBuilder.Entity<SingleReflexCamera>()
                .Map(m => m.MapInheritedProperties().ToTable("SingleReflexCameras"));
            modelBuilder.Entity<Lens>()
                .Map(m => m.MapInheritedProperties().ToTable("Lenses"));

            base.OnModelCreating(modelBuilder);
        }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Caption { get; set; }
        public string TypeNumber { get; set; }
        public string Manufacturer { get; set; }
    }

    public class Camera : Product
    {
        public string Lens { get; set; }
    }

    public class SingleReflexCamera : Product
    {
        public string LensMount { get; set; }
    }

    public class Lens : Product
    {
        public string FocalLength { get; set; }
        public string MaxAperture { get; set; }
    }
}
