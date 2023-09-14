using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBanMyPham.Commons
{
    [Serializable]
    public class UserLogin
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FuName { get; set; }
    }
}