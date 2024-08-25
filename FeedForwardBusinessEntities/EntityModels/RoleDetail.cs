﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedForwardBusinessEntities.EntityModels
{
    [Table("RoleDetails")]
    public class RoleDetail
    {
        [Key]
        [Column(TypeName ="int")]
        public int RoleID { get; set; }
        [Column(TypeName ="varchar(50)")]
        public string RoleDescription { get; set; }
        [Column(TypeName ="datetime")]
        public DateTime? CreatedDate { get; set; }
        [Column(TypeName ="varchar(50)")]
        public string? CreatedBy { get; set; }
        [Column(TypeName ="datetime")]
        public DateTime? ModifiedDate { get; set; }
        [Column(TypeName ="varchar(50)")]
        public string? ModifiedBy { get; set; }

    }
}
