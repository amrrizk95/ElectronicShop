using ElectronicShopModel;
using ElectronicShopRepository;
using System;
using System.Collections.Generic;
using System.Text;
using static ElectronicShopBL.Helper.helper;

namespace ElectronicShopBL.ViewModels
{
   public class OrderVM
    {
        public int id { get; set; }
        public int productId { get; set; }
        public string productName { get; set; }
        public string categoryName { get; set; }
        public string customerName { get; set; }
        public int customerId { get; set; }
        public int quntity { get; set; } = 1;
        public double totalCost { get; set; }
        public double productPrice { get; set; }
        public DateTime createdDate { get; set; }

        public static implicit operator Order(OrderVM productVM)
        {

            var model = new Order();
            model.id = productVM.id;
            model.productId = productVM.productId;
            model.customerId = productVM.customerId;
            model.createdDate = productVM.createdDate;
            model.totalCost = productVM.totalCost;
            model.createdDate = productVM.createdDate;
            model.qty = productVM.quntity;

            return model;
        }

        public static List<OrderVM> getUserOrders(IUnitOfWork unitOfWork, int? userId, int? role)
        {
            var ordersVM = new List<OrderVM>();
            if (role== (int)Roles.Admin)
            {
                var orders = unitOfWork.OrderRepository.GetAllWithInclude("customer", "product.category");
                foreach (var item in orders)
                {
                    OrderVM vm = item;
                    vm.productName = item.product.nameAr;
                    vm.categoryName = item.product.category.nameAr;

                    vm.customerName = item.customer.name;
                    vm.productPrice = item.product.price;
                    ordersVM.Add(vm);
                }
               
            }
            if (role==(int)Roles.Customer)
            {
                var orders = unitOfWork.OrderRepository.GetAllWithInclude(o=>o.customerId==userId,"customer", "product.category");
                foreach (var item in orders)
                {
                    OrderVM vm = item;
                    vm.productName = item.product.nameAr;
                    vm.categoryName = item.product.category.nameAr;
                    vm.customerName = item.customer.name;
                    vm.productPrice = item.product.price;
                    ordersVM.Add(vm);
                }
            }
                return ordersVM;
        }

        public static implicit operator OrderVM(Order order)
        {
            var modelVM = new OrderVM();
            modelVM.id = order.id;
            modelVM.productId = order.productId;
            modelVM.customerId = order.customerId;
            modelVM.createdDate = order.createdDate;
            modelVM.totalCost = order.totalCost;
            modelVM.quntity = order.qty;
            return modelVM;
        }
        public static Order addOrder(IUnitOfWork unitOfWork, OrderVM orderVM,int? customerId)
        {
        
            // place order
            Order order = orderVM;
            order.totalCost = orderVM.productPrice * orderVM.quntity;
            order.createdDate = DateTime.Now;
            order.customerId = customerId.Value;
            try
            {
                unitOfWork.OrderRepository.Add(order);
                unitOfWork.Complete();
            }
            catch (Exception e)
            {

                return null;
            }
            return order;
        } 
        public static OrderVM getOrderVM(IUnitOfWork unitOfWork,int  productId)
        {
            var product = unitOfWork.ProductRepository.GetAllWithInclude(p=>p.id==productId,"category");
            var OrderVM = new OrderVM();
            OrderVM.productPrice = product[0].price;
            OrderVM.productId = productId;
            OrderVM.productName = product[0].nameAr;
            OrderVM.categoryName = product[0].category.nameAr;
            return OrderVM;

        }
    }
}
