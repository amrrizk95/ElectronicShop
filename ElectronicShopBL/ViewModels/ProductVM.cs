using ElectronicShopBL.IBL;
using ElectronicShopModel;
using ElectronicShopRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElectronicShopBL.ViewModels
{
   public class ProductVM
    {
        public int id { get; set; }
        public string nameAr { get; set; }
        public string nameEn { get; set; }
        public string description { get; set; }
        public double price { get; set; }
        public DateTime createdDate { get; set; }
        public int categoryId { get; set; }
        public string categoryNameAr { get; set; }
        public string categoryNameEn { get; set; }

        public static implicit operator Product(ProductVM productVM)
        {

            var model = new Product();
            model.id = productVM.id;
            model.nameAr = productVM.nameAr;
            model.nameEn = productVM.nameEn;
            model.categoryId = productVM.categoryId;
            model.price = productVM.price; 
            model.createdDate = productVM.createdDate; 
            model.description = productVM.description; 

            return model;
        }
        public static implicit operator ProductVM(Product product)
        {
            var modelVM = new ProductVM();
            modelVM.id = product.id;
            modelVM.nameAr = product.nameAr;
            modelVM.nameEn = product.nameEn;
            modelVM.categoryId = product.categoryId;
            modelVM.price = product.price;
            modelVM.createdDate = product.createdDate;
            modelVM.description = product.description;
            modelVM.categoryNameAr = product.category.nameAr;
            modelVM.categoryNameEn = product.category.nameAr;
            return modelVM;
        }
        public static Product addProduct(IBussinseContext bussinseContext, ProductVM productVM)
        {
            // add product
            Product product = productVM;
            product.createdDate = DateTime.Now;
            try
            {
                bussinseContext.ProductBL.AddNew(product);
            }
            catch (Exception e)
            {

                return null;
            }
            return product;
        }
        public static List<ProductVM> getProducts(IBussinseContext bussinseContext)
        {
            var data=    bussinseContext.ProductBL.GetAll("category");
            var VMs = new List<ProductVM>();
            foreach (var item in data)
            {
                ProductVM productVM = item;
                VMs.Add(productVM);
            }
            return VMs;
        }
        public static Product getProduct(IBussinseContext bussinseContext, int id)
        {
            return bussinseContext.ProductBL.Get(id);
        }
    }
}
