using FeedForwardBusinessEntities.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedForwardRepository.Abstract
{
    public interface IFeedBackSchedulingRepository
    {
        List<LevelDetail> levl();
        List<DesignationLevel> desg(string levelid);
        public List<FeedBackCategoryLevel> category(string levelid);
        List<FeedBackCategoryLevel> AllCategory();
        List<UserDetail> UserDetailToList(string levelid, string desid, string currUserID);
        List<UserDetail> UserDetailByList(string levelid, string desid, int FCLid);
        List<FeedbackSession> GetFeedbackSession();
        List<MappingToByDetail> MappingToBY(List<UserDetail> usrto, List<UserDetail> usrby);
        string UpdateScheduleData(int fsid,bool fstatus, List<MappingToByDetail> maptoby);
        List<FeedbackSchedulingDetail> GetScheduledFeedback();
    }
}
