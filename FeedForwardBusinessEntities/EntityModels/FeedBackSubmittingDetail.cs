using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedForwardBusinessEntities.EntityModels
{
    public class FeedBackSubmittingDetail
    {
        public int FRespID { get; set; }
        public string Ffrom { get; set; }
        public string Fto { get; set; }
        public int QID { get; set; }
        public int FCID { get; set; }
        public int SChID { get; set; }

    }
}
