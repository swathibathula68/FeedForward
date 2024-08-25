using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedForwardBusinessEntities.EntityModels
{
    [Table("FeedbackSessions")]
    public class FeedbackSession
    {
        [Key]
        [Column(TypeName ="int")]
        public int FSID { get; set; }
        [Column(TypeName ="varchar(50)")]
        public string FSDescription{get;set;}
        [Column(TypeName ="datetime")]
        public DateTime? CreatedDate { get; set; }
        [Column(TypeName ="varchar(50)")]
        public string? CreatedBy { get; set; }
        [Column(TypeName ="datetime")]
        public DateTime? ModifiedDate { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string? ModifiedBy { get; set; }


    }
}
