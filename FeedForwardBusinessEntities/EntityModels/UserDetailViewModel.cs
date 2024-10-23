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
        [Required(ErrorMessage = "Roll ID is mandatory")]
        public int RoleID { get; set; }
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage ="Invalid EmailID")]
        public string? Email { get; set; }
        public string? Mobile { get; set; }
        public string? EmpID { get; set; }
        public int DesignationID { get; set; }
        [Required(ErrorMessage = "Please select Role")]
        public List<RoleDetail> RoleList { get; set; }
        [Required(ErrorMessage = "Please Select Designation")]
        public List<DesignationLevel> DesignationList { get; set; }

    }
}
