namespace NOEN.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Diagnostics;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Model.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<NOENdbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(NOENdbContext context)
        {
            CreateUser(context);
            CreateProductCategory(context);
            CreatePage(context);
            CreateContactDetail(context);
            CreateProduct(context);
        }

        private void CreateUser(NOENdbContext context)
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new NOENdbContext()));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new NOENdbContext()));

            var user = new ApplicationUser()
            {
                UserName = "tndm00",
                Email = "tedu.international@gmail.com",
                EmailConfirmed = true,
                BirthDay = DateTime.Now,
                FullName = "Technology Education"

            };
            manager.Create(user, "thanhnhan");

        }

        private void CreateProductCategory(NOENdbContext context)
        {
            if (context.ProductCategories.Count() == 0)
            {
                List<ProductCategory> listProductCategory = new List<ProductCategory>()
            {
                new ProductCategory() { Name="Quần Jean Nữ",Alias="quan-jean-nu",Status=true },
                new ProductCategory() { Name="Áo Sơ Mi Nam",Alias="ao-so-mi-nam",Status=true },
                new ProductCategory() { Name="Quần KaKi Nam",Alias="quan-kaki-nam",Status=true },
                new ProductCategory() { Name="Đầm Ren Nữ",Alias="dam-ren-nu",Status=true }
            };
                context.ProductCategories.AddRange(listProductCategory);
                context.SaveChanges();
            }
        }

        private void CreateProduct(NOENdbContext context)
        {
            if (context.Products.Count() == 0)
            {
                List<Product> listProduct = new List<Product>()
            {
                new Product() {
                    Name ="Mắt kình thời trang",
                    Alias ="mat-kinh-thoi-trang",
                    Status =true,
                    CategoryID = 1,
                    Price = 150000,
                    OriginalPrice = 130000},
                new Product() {
                    Name ="Áo thun có cổ",
                    Alias ="ao-thun-co-co",
                    Status =true,
                    CategoryID = 2,
                    Price = 250000,
                    OriginalPrice = 230000},
                new Product() {
                    Name ="Váy hồng",
                    Alias ="vay-hong",
                    Status =true,
                    CategoryID = 3,
                    Price = 350000,
                    OriginalPrice = 330000},
                new Product() {
                    Name ="Giầy Babe",
                    Alias ="giay-babe",
                    Status =true,
                    CategoryID = 4,
                    Price = 450000,
                    OriginalPrice = 430000}
            };
                context.Products.AddRange(listProduct);
                context.SaveChanges();
            }
        }

        private void CreatePage(NOENdbContext context)
        {
            if (context.Pages.Count() == 0)
            {
                try
                {
                    var page = new Page()
                    {
                        Name = "Giới thiệu",
                        Alias = "gioi-thieu",
                        Content = @"Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium ",
                        Status = true

                    };
                    context.Pages.Add(page);
                    context.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var eve in ex.EntityValidationErrors)
                    {
                        Trace.WriteLine($"Entity of type \"{eve.Entry.Entity.GetType().Name}\" in state \"{eve.Entry.State}\" has the following validation error.");
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Trace.WriteLine($"- Property: \"{ve.PropertyName}\", Error: \"{ve.ErrorMessage}\"");
                        }
                    }
                }

            }
        }

        private void CreateContactDetail(NOENdbContext context)
        {
            if (context.ContactDetails.Count() == 0)
            {
                try
                {
                    var contactDetail = new ContactDetail()
                    {
                        Name = "Shop thời trang NOEN",
                        Address = "EHOME 3 HỒ HỌC LÃM",
                        Email = "tthnhanit@gmail.com",
                        Lat = 21.0633645,
                        Lng = 105.8053274,
                        Phone = "01887151377",
                        Website = "http://zing.vn",
                        Orther = "",
                        Status = true

                    };
                    context.ContactDetails.Add(contactDetail);
                    context.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var eve in ex.EntityValidationErrors)
                    {
                        Trace.WriteLine($"Entity of type \"{eve.Entry.Entity.GetType().Name}\" in state \"{eve.Entry.State}\" has the following validation error.");
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Trace.WriteLine($"- Property: \"{ve.PropertyName}\", Error: \"{ve.ErrorMessage}\"");
                        }
                    }
                }

            }
        }
    }
}
