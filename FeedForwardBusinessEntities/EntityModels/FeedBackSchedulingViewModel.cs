using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedForwardBusinessEntities.EntityModels
{
    public class FeedBackSchedulingViewModel
    {
        public int LevelID { get; set; }
        public long SchID { get; set; }
        public int DesignationID { get; set; }
        public int FCLID { get; set; }
        public int FSID { get; set; }
        public List<LevelDetail> lvldetlist { get; set; }
        public List<DesignationLevel> desglvlList { get; set; }
        
        public List<FeedBackCategoryLevel> FeedbackCategory { get; set; }
        public List<UserDetail> userdetailtolst { get; set; }
        public List<UserDetail> userdetailBylst { get; set; }
        public List<FeedbackSession> feedbacksessionlist { get; set; }
        public List<MappingToByDetail> ToByList { get; set; }
        
    }
}
