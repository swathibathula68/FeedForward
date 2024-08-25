using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedForwardBusinessEntities.EntityModels
{
    public class UserLoginViewModel
    {
        public string UserID { get; set; }
    
        public string Password { get; set; }
    }
}
