using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedForwardBusinessEntities.EntityModels
{
    [Table("LevelDetails")]
    public class LevelDetail
    {
        [Key]
        [Column(TypeName = "int")]
        public int LevelID { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string LevelDescription { get; set; }
        [Column(TypeName = "DateTime")]
        public DateTime? CreatedDate { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string? CreatedBy { get; set; }
        [Column(TypeName = "DateTime")]
        public DateTime? ModifiedDate { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string? ModifiedBy { get; set; }

    }
}
