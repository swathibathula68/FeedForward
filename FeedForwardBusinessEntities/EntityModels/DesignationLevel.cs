using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedForwardBusinessEntities.EntityModels
{
    [Table("DesignationLevels")]
    public class DesignationLevel
    {
        [Key]
        [Column(TypeName = "int")]
        public int DesignationID { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Designation { get; set; }
        [Column(TypeName = "int")]
        public int LevelID { get; set; }
        [Column(TypeName = "varchar(500)")]
        public string? Description { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string? CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate{ get; set; }
        [Column(TypeName = "varchar(50)")]
        public string? ModifiedBy { get; set; }

    }
}
