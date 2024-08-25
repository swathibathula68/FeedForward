using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedForwardBusinessEntities.EntityModels
{
    public class UserDetailViewModel
    {
        [Required(ErrorMessage="UserID is mandatory")]
        public string UserID { get; set; }
        public string Password { get; set; }
        public string? Name { get; set; }
        public int RoleID { get; set; }
        [RegularExpression(@"a-zA-Z]+",ErrorMessage ="Invalid EmailID")]
        public string? Email { get; set; }
        public string? Mobile { get; set; }
        public string? EmpID { get; set; }
        public int DesignationID { get; set; }
        public List<RoleDetail> RoleList { get; set; }
        public List<DesignationLevel> DesignationList { get; set; }

    }
}
