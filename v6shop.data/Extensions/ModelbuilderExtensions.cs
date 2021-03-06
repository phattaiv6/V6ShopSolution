using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using V6Shop.Data.EF;
using V6Shop.Data.Entities;

namespace V6Shop.Data.Extensions
{
   public static class ModelbuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
         modelBuilder.Entity<AppConfig>().HasData(
                new AppConfig() {
                    Key = "HomePage", 
                    Value = "This is home page of V6ShopSolution" },
                new AppConfig() { 
                    Key = "HomeTitle", 
                    Value = "This is home title of V6ShopSolution" },
                new AppConfig() { 
                    Key = "HomeDescription",
                    Value = "This is home Description of V6ShopSolution" });

         
         modelBuilder.Entity<Language>().HasData(
                new Language() {
                    Id = "vi-VN",Name = "Tiếng Việt" , 
                    IsDefault = true},
                new Language() { 
                    Id = "en-US", Name = "English",
                    IsDefault = false }
                );
            
            
         modelBuilder.Entity<Category>().HasData(
                new Category() { 
                    Id = 1,
                    IsShowOnHome = true, 
                    ParentID = null ,
                    SortOrder = 1 , 
                    Status = EF.Enums.Status.Active ,

             
              
              },
                
                new Category()
                {
                    Id = 2,
                    IsShowOnHome = true,
                    ParentID = null,
                    SortOrder = 2,
                    Status = EF.Enums.Status.Active,


                }
                
                );
            modelBuilder.Entity<CategoryTranslation>().HasData(
                  new CategoryTranslation()
                  {
                      Id = 1,
                      CategoryId = 1,
                      Name = "Áo Nam",
                      LanguageId = "vi-VN",
                      SeoAlias = "ao-nam",
                      SeoDescription = "Sản phẩm áo thời trang nam",
                      SeoTitle = "Sản phẩm áo thời trang nam"
                  },
                new CategoryTranslation()
                {
                    Id = 2,
                    CategoryId= 1,
                    Name = "Men Shirt",
                    LanguageId = "en-US",
                    SeoAlias = "men-shirt",
                    SeoDescription = "the shirt product for men ",
                    SeoTitle = "the shirt product for men"
                },
                 new CategoryTranslation()
                 {
                     Id =3,
                     CategoryId = 2,
                     Name = "Áo Nữ",
                     LanguageId = "vi-VN",
                     SeoAlias = "ao-nu",
                     SeoDescription = "Sản phẩm áo thời trang nữ",
                     SeoTitle = "Sản phẩm áo thời trang nữ"
                 },
                new CategoryTranslation()
                {
                    Id =4,
                    CategoryId = 2,
                    Name = "Women Shirt",
                    LanguageId = "en-US",
                    SeoAlias = "women-shirt",
                    SeoDescription = "the shirt product for women ",
                    SeoTitle = "the shirt product for women"
                }
                );
            
         modelBuilder.Entity<Product>().HasData(
              new Product()
              {
                  
                  ID = 1,
                  DateCreated = DateTime.Now,
                  OriginalPrice = 100000,
                  Price = 200000,
                  Stock = 0,
                  ViewCount = 0 ,
                 
               
                 
              }
             
              );
            modelBuilder.Entity<ProductTranslation>().HasData(
                  new ProductTranslation()
                  {
                      Id =1,
                      ProductId = 1,
                      Name = "Áo thun nam con mèo",
                      LanguageId = "vi-VN",
                      SeoAlias = "ao-thun-nam-con-meo",
                      SeoDescription = "Áo thun nam con mèo",
                      SeoTitle = "Áo thun nam con mèo",
                      Description = "áo thun nam con mèo",
                      Details = "áo thun nam con mèo"
                  },
               new ProductTranslation()
               {
                   Id = 2,
                   ProductId = 1,
                   Name = "Cat Men Shirt",
                   LanguageId = "en-US",
                   SeoAlias = "cat-men-shirt",
                   SeoDescription = "cat men shirt ",
                   SeoTitle = "cat men shirtn",
                   Description = "cat men shirt",
                   Details = "cat men shirt"
               });
            modelBuilder.Entity<ProductInCategory>().HasData(
                new ProductInCategory () {ProductId = 1, CategoryId =1 }

                );
            var roleId = new Guid("08DD6EA8-55A5-4E5E-8D86-6C145B3C6D55");
            var adminId = new Guid("69BD714F-9576-45BA-B5B7-F00649BE00DE");
            modelBuilder.Entity<AppRole>().HasData(new AppRole
            {
                Id = roleId,
                Name = "admin",
                NormalizedName = "admin",
                Description = "Administrator role"
            });

            var hasher = new PasswordHasher<AppUser>();
            modelBuilder.Entity<AppUser>().HasData(new AppUser
            {
                Id = adminId,
                UserName = "admin",
                NormalizedUserName = "admin",
                Email = "luonghuynhphattai@gmail.com",
                NormalizedEmail = "luonghuynhphattai@gmail.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Abcd1234$"),
                SecurityStamp = string.Empty,
                FirstName = "Tai",
                LastName = "Phat",
                Dob = new DateTime(2021, 01, 15)
            });
            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = roleId,
                UserId = adminId
            });
        }
    }
}
