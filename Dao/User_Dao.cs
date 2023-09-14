using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBanMyPham.Models;


namespace WebBanMyPham.Dao
{
    public class User_Dao
    {
        WebBanMyPhamEntities db = null;
        public User_Dao()
        {
            db = new WebBanMyPhamEntities();
        }
        public User getItem(string email)
        {
            return db.Users.FirstOrDefault(x => x.Email == email);
        }
        public List<User> getList()
        {
            return db.Users.ToList();
        }
        public User Add(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
            return user;
        }
        public User Update(User user)
        {
            var us = db.Users.FirstOrDefault(x=>x.ID== user.ID);
            us.Password = user.Password;
            us.FullName = user.FullName;
            us.Email = user.Email;
            us.Phone = user.Phone;
            us.Address = user.Address;
            us.UpdatedBy = user.UpdatedBy;
            us.UpdatedDate = user.UpdatedDate;
            db.SaveChanges();
            return us;
        }
        public int Login(string email, string pass)
        {
            var user = db.Users.FirstOrDefault(x =>x.Email==email);
            if(user == null)
            {
                return -2;//email không tồn tại
            }
            else
            {
                if (user.Status == false)
                {
                    return 0;// user chưa được kích hoạt
                }
                else
                {
                    if(user.Password == pass)
                    {
                        return 1;// đăng nhập thành công
                    }
                    else
                    {
                        return -1;// sai mật khẩu
                    }
                }
            }
        }
    }
}