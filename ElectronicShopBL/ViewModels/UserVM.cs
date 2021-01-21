using ElectronicShopBL.Helper;
using ElectronicShopBL.IBL;
using ElectronicShopModel;
using ElectronicShopRepository;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ElectronicShopBL.ViewModels
{
   public class UserVM
    {
        public int id { get; set; }
        [Required]
        public string userName { get; set; }
        [Required]
        public string password { get; set; }
        public int? role { get; set; }
        public static implicit operator User(UserVM userVM)
        {

            var model = new User();
            model.id = userVM.id;
            model.userName = userVM.userName;
            model.password = userVM.password;
            model.role = userVM.role;
            return model;
        }


        public static implicit operator UserVM(User user)
        {
            var modelVM = new UserVM();
            modelVM.id = user.id;
            modelVM.userName = user.userName;
            modelVM.password = user.password;
            modelVM.role = user.role;

            return modelVM;
        }
        public static bool RegisterUser(IUnitOfWork unitOfWork, UserVM userVM)
        {
            var checkExistUser = unitOfWork.UserRepository.Find(u => u.userName == userVM.userName);
            if (checkExistUser.Count==0)
            {
                try
                {
                    User user = userVM;
                    user.password = helper.GetMD5(user.password);
                    unitOfWork.UserRepository.Add(user);
                    unitOfWork.Complete();
                }
                catch (Exception)
                {

                    return false;
                }
            
            }
            else
            {
                return false;
            }
            return true;
        }
        public static User LoginUser(IUnitOfWork unitOfWork, UserVM userVM)
        {
            var f_password = helper.GetMD5( userVM.password);
            var data = unitOfWork.UserRepository.GetWithInclude(u => u.userName == userVM.userName && u.password == f_password);
            if (data.Count>0)
            {
                return data[0];
            }
            else
            {
                return null;
            }
                

        } 


    }
}
