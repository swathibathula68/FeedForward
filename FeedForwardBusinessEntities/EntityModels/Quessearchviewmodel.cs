using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedForwardBusinessEntities.EntityModels
{
    public class Quessearchviewmodel
    {
        public int QID { get; set; }

        public int LevelID { get; set; }
        public int Search { get; set; }
        public List<QuestionDetail> questionlist { get; set; }
        public List<DesignationLevel> DesignationList { get; set; }
        public string Question { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }

    }
}
