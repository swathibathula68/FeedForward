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
    [Table("FeedBackCategoryLevels")]
    
    public class FeedBackCategoryLevel
    {
        [Key]
        [Column(TypeName ="int")]
        public int FCLID { get; set; }
        [Column(TypeName ="varchar(500)")]
        public string FCLDescription { get; set; }
        [Column(TypeName ="DateTime")]
        public DateTime? CreatedDate { get; set; }
        [Column(TypeName = "varchar(500)")]
        public string? CreadtedBy { get; set; }
        [Column(TypeName = "DateTime")]
        public DateTime? ModifiedDate { get; set; }
        [Column(TypeName = "varchar(500)")]
        public string? ModifiedBy { get; set; }

    }
}
