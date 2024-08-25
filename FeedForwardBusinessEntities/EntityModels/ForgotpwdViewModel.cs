using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedForwardBusinessEntities.EntityModels
{
    public class ForgotpwdViewModel
    {
        public string UserID{get;set;}
        public string OTP { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmNewPassword { get; set; }


    }
}
