using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF06_TPH
{
    class Program
    {
        static void Main(string[] args)
        {
            Initialize();

            using (var context = new CompanyDbContext())
            {
                Console.WriteLine("Camera Property: Lens = {0}", 
                    context.Products.OfType<Camera>().First().Lens);
                Console.WriteLine("SingleReflexCamera Property: LensMount = {0}", 
                    context.Products.OfType<SingleReflexCamera>().First().LensMount);
                Console.WriteLine("Lens Property: FocalLength = {0}", 
                    context.Products.OfType<Lens>().First().FocalLength);
                Console.WriteLine("Lens Property: MaxAperture = {0}", 
                    context.Products.OfType<Lens>().First().MaxAperture);
            }

            Console.Read();
        }

        static void Initialize()
        {
            using (var context = new CompanyDbContext())
            {
                if (context.Products.Count() == 0)
                {
                    context.Products.Add(new Camera()
                    {
                        Id = 1,
                        Caption = "PowerShot G1 X Mark II",
                        Manufacturer = "Canon",
                        TypeNumber = "PowerShot G1 X Mark II",
                        Lens = "12.5mm (W) - 62.5mm (T)"
                    });

                    context.Products.Add(new SingleReflexCamera()
                     {
                         Id = 2,
                         Caption = "EOS-1D X",
                         Manufacturer = "Canon",
                         TypeNumber = "EOS-1D X",
                         LensMount = "Canon EF mount"
                     });

                    context.Products.Add(new Lens()
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

        public virtual DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .ToTable("Products") // 解決因 EF Database Creation 機制導致產生兩個表格的問題。
                .Map<Camera>(m =>
                    m.MapInheritedProperties()
                    .ToTable("Products")
                    .Requires("Discriminator")
                    .HasValue("Camera")
                )
                .Map<SingleReflexCamera>(m =>
                    m.MapInheritedProperties()
                    .ToTable("Products")
                    .Requires("Discriminator")
                    .HasValue("SingleReflexCamera")
                    )
                .Map<Lens>(m => 
                    m.MapInheritedProperties()
                    .ToTable("Products")
                    .Requires("Discriminator")
                    .HasValue("Lens")
                    );
            
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
