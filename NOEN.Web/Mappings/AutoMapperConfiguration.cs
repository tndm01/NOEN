using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using NOEN.Model.Models;
using NOEN.Web.Models;

namespace NOEN.Web.Mappings
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.CreateMap<Product, ProductViewModel>();
            Mapper.CreateMap<ProductCategory, ProductCategoryViewModel>();
            Mapper.CreateMap<Product, ExportProductViewModel>();
            //Mapper.CreateMap<ProductTag, ProductTagViewModel>();
            //Mapper.CreateMap<Tag, TagViewModel>();
            //Mapper.CreateMap<Page, PageViewModel>();
            //Mapper.CreateMap<ContactDetail, ContactViewModel>();

            //Mapper.CreateMap<ApplicationGroup, ApplicationGroupViewModel>();
            //Mapper.CreateMap<ApplicationRole, ApplicationRoleViewModel>();
            //Mapper.CreateMap<ApplicationUser, ApplicationUserViewModel>();
        }
    }
}