using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedForwardBusinessEntities.EntityModels
{
    [Table("FeedbackScheduingDetails")]
    public class FeedbackSchedulingDetail
    {
        [Key]
        [Column(TypeName ="bigint")]
        public long SchID { get; set; }
        [Column(TypeName ="varchar(50)")]
        public string FeedBackBy { get; set; }
        [Column(TypeName ="varchar(50)")]
        public string FeedBackTo { get; set; }
        [Column(TypeName ="int")]
        public int FSID { get; set; }
        [Column(TypeName ="bit")]
        public bool Fstatus { get; set; }
        [Column(TypeName="varchar(5000)")]
        public string FComment { get; set; }

    }
}
