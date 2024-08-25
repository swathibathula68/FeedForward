using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedForwardBusinessEntities.EntityModels
{
    public class SubmittingFeedbackViewModel
    {
        public int FCID { get; set; }
        public long SchID { get; set; }
        public int QID { get; set; }
        public string Question { get; set; }
        public List<FeedBackCaption> fedcap { get; set; }
        public List<QuestionDetail> questionDetailList { get; set; }

    }
}
