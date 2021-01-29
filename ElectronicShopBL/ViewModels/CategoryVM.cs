using ElectronicShopBL.IBL;
using ElectronicShopModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElectronicShopBL.ViewModels
{
    public class CategoryVM
    {
        public int id { get; set; }
        public string nameAr { get; set; }
        public string nameEn { get; set; }
        public DateTime createdDate { get; set; } 

        public static implicit operator Category(CategoryVM categoryVM)
        {
            var model = new Category();
            model.id = categoryVM.id;
            model.nameAr = categoryVM.nameAr;
            model.nameEn = categoryVM.nameEn;
            model.createdDate = categoryVM.createdDate;
            return model;
        }

        public static implicit operator CategoryVM(Category category)
        {
            var VM = new CategoryVM();
            VM.id = category.id;
            VM.nameAr = category.nameAr;
            VM.nameEn = category.nameEn;
            VM.createdDate = category.createdDate;
            return VM;
        }
        public static List<CategoryVM> getCategories(IBussinseContext bussinseContext)
        {
            var data = bussinseContext.CategoryBL.GetAll();
            var VMs = new List<CategoryVM>();
            foreach (var item in data)
            {
                CategoryVM categoryVM = item;
                VMs.Add(categoryVM);
            }
            return VMs;
        }

        public static object addCategory(IBussinseContext bussinseContext, CategoryVM categoryVM)
        {
            Category category = categoryVM;
            category.createdDate = DateTime.Now;
            try
            {
                bussinseContext.CategoryBL.AddNew(category);
            }
            catch (Exception e)
            {

                return null;
            }
            return category;
        }

    
    }
}
