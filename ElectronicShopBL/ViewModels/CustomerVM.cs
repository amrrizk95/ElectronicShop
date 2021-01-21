using ElectronicShopBL.Helper;
using ElectronicShopBL.IBL;
using ElectronicShopModel;
using ElectronicShopRepository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static ElectronicShopBL.Helper.helper;

namespace ElectronicShopBL.ViewModels
{
   public class CustomerVM
    {
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public string address { get; set; }
        [Required]
        public string phone { get; set; }
        [Required]
        public DateTime birthdate { get; set; }
        public static implicit operator Customer(CustomerVM customerVM)
        {
           
            var model = new Customer();
            model.id = customerVM.id;
            model.name = customerVM.name;
            model.email = customerVM.email;
            model.address = customerVM.address;
            model.birthdate = customerVM.birthdate;
            model.phone = customerVM.phone;

            return model;
        }


        public static implicit operator CustomerVM(Customer customer)
        {
            var modelVM = new CustomerVM();
            modelVM.id = customer.id;
            modelVM.name = customer.name;
            modelVM.email = customer.email;
            modelVM.address = customer.address;
            modelVM.birthdate = customer.birthdate;
            modelVM.phone = customer.phone;
            return modelVM;
        } 

        public static User  addCustomer(IUnitOfWork unitOfWork, CustomerVM customerVM)
        {
            //var checkExistUser = bussinseContext.UserBL.Check(u => u.userName == customerVM.email);
            var checkExistUser = unitOfWork.UserRepository.Find(u => u.userName == customerVM.email);
            if (checkExistUser.Count == 0)
            {
            // add customer
            Customer customer = customerVM;
            unitOfWork.CustomerRepository.Add(customer);
            unitOfWork.Complete();
                // add user
            UserVM user = new UserVM();
            user.userName = customerVM.email;
            user.password = customerVM.password;
            user.role = (int)Roles.Customer;
                // register user
            var  isRegister=UserVM.RegisterUser( unitOfWork, user);
                if (isRegister==true)
                {
                    // login user
                    var result = UserVM.LoginUser(unitOfWork, user);
                    if (result!=null)
                    {
                        user.id = result.id;
                    }
                }
           
                return user;

            }
            else
            {
                return null;
            }
        }
        public static List<CustomerVM> getCustomers(IUnitOfWork unitOfWork)
        {
            var data = unitOfWork.CustomerRepository.GetAll();
            var VMs = new List<CustomerVM>();
            foreach (var item in data)
            {
                CustomerVM customerVM = item;
                VMs.Add(customerVM);
            }
            return VMs;
        }
    }
}
