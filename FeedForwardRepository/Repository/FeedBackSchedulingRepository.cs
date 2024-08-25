using FeedForwardBusinessEntities.EntityContext;
using FeedForwardBusinessEntities.EntityModels;
using FeedForwardRepository.Abstract;
using FeedForwardUtilities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FeedForwardRepository.Repository
{
    public class FeedBackSchedulingRepository: IFeedBackSchedulingRepository
    {
        FeedForwardContext _context = new FeedForwardContext();
        public List<LevelDetail> levl()
        {
           
            List<LevelDetail> lvldet = new List<LevelDetail>();
            try
            {
                lvldet = _context.LevelDetailInfo.ToList();
            }
            catch (Exception ex)
            {
                var obj = Utilities.GetInstance();
                obj.LogErrorMessage(ex.Message);
            }

            return lvldet;
        }
        public List<DesignationLevel>  desg(string levelid)
        { 
            
            List<DesignationLevel> feed=new List<DesignationLevel>();
            try
            {
                feed = _context.DesignationLevelInfo.Where(x => x.LevelID == Convert.ToInt32(levelid)).ToList();
            }
            catch (Exception ex)
            {
                var obj = Utilities.GetInstance();
                obj.LogErrorMessage(ex.Message);
            }
            return feed;
        }
        public List<FeedBackCategoryLevel>AllCategory()
        {
            List<FeedBackCategoryLevel> AllCat = new List<FeedBackCategoryLevel>();
            try
            {
                AllCat = _context.FeedBackCategoryLevelInfo.ToList();
            }
            catch (Exception ex)
            {
                var obj = Utilities.GetInstance();
                obj.LogErrorMessage(ex.Message);
            }
            return AllCat;
        }
        public List<FeedBackCategoryLevel> category(string levelid)
        {
            List<FeedBackCategoryLevel> cat = new List<FeedBackCategoryLevel>();
            try
            {
                cat = _context.FeedBackCategoryLevelInfo.Where(x => x.FCLID == Convert.ToInt32(levelid)).ToList();
            }
            catch (Exception ex)
            {
                var obj = Utilities.GetInstance();
                obj.LogErrorMessage(ex.Message);
            }
            return cat;
        }
        public List<UserDetail> UserDetailToList(string levelid, string desid,string currUserID)
        {
            
            List<FeedbackSchedulingDetail> fsd = new List<FeedbackSchedulingDetail>();
            List<UserDetail> usr=new List<UserDetail>();
            FeedbackSchedulingDetail fedbck=new FeedbackSchedulingDetail();
            
            
            try
            {
                usr= _context.UserDetailInfo.Where(x => x.DesignationID ==Convert.ToInt32(desid)&&x.UserID!=currUserID).ToList();
      
            }
            catch (Exception ex)
            {
                var obj = Utilities.GetInstance();
                obj.LogErrorMessage(ex.Message);
            }
            return usr;
        }
        public List<UserDetail> UserDetailByList(string levelid,string desid,int FCLid)
        {
            
            List<UserDetail> usr = new List<UserDetail>();
            List<DesignationLevel> desg= new List<DesignationLevel>();
            int lev;
            int.TryParse(levelid, out lev);
            try
            {
                if (FCLid == 1)
                {
                    lev = lev - 2;
                    
                    desg = _context.DesignationLevelInfo.Where(x => x.LevelID ==Convert.ToInt32(lev)).ToList();
                    foreach(DesignationLevel des in desg)
                    {
                        usr = _context.UserDetailInfo.Where(x => x.DesignationID == des.DesignationID).ToList();
                        
                    }
                    
                }
                else if (FCLid == 2)
                {
                    lev = lev - 1;
                    desg = _context.DesignationLevelInfo.Where(x => x.LevelID == Convert.ToInt32(lev)).ToList();
                    foreach (DesignationLevel des in desg)
                    {
                        usr = _context.UserDetailInfo.Where(x => x.DesignationID == des.DesignationID).ToList();
                        
                    }
                }
                else if (FCLid == 3)
                {
                    desg = _context.DesignationLevelInfo.Where(x => x.LevelID == Convert.ToInt32(lev)).ToList();
                    foreach (DesignationLevel des in desg)
                    {
                        usr = _context.UserDetailInfo.Where(x => x.DesignationID == des.DesignationID).ToList();
                        
                    }
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                var obj = Utilities.GetInstance();
                obj.LogErrorMessage(ex.Message);
            }

            return usr;
        }
        public List<FeedbackSession> GetFeedbackSession()
        {
            List<FeedbackSession> fedses = new List<FeedbackSession>();
            try
            { 
                fedses = _context.FeedbackSessionInfo.ToList();
            }
            catch (Exception ex)
            {
                var obj = Utilities.GetInstance();
                obj.LogErrorMessage(ex.Message);
            }
            return fedses;
        }
        public List<MappingToByDetail> MappingToBY(List<UserDetail> usrto, List<UserDetail> usrby)
        {
            List<FeedBackSchedulingViewModel> feed = new List<FeedBackSchedulingViewModel>();
            FeedbackSchedulingDetail feedbackDetail = new FeedbackSchedulingDetail();
            int i = 0;
            int j = 0;
            List<MappingToByDetail> maptoby = new List<MappingToByDetail>();
            try
            {
                if (usrby.Count >= usrto.Count & usrby != null)
                {

                    foreach (UserDetail usr in usrby)
                    {
                        MappingToByDetail map = new MappingToByDetail();

                        if (usrby.Count > i)
                        {
                            map.FeedbackTo = usrto[i];
                            map.FeedbackBy = usr;
                            maptoby.Add(map);

                        }
                        else
                        {
                            return maptoby;
                        }
                        i++;
                    }

                }
                else if ((usrby.Count < usrto.Count) && (usrto != null))
                {
                    foreach (UserDetail usr in usrto)
                    {
                        MappingToByDetail map = new MappingToByDetail();
                        if (usrby.Count == i)
                        {
                            map.FeedbackBy = usrby[j];
                            map.FeedbackTo = usr;
                            maptoby.Add(map);
                            j++;
                        }
                        else if (usrby.Count < i)
                        {
                            map.FeedbackBy = usrby[j];
                            map.FeedbackTo = usr;
                            maptoby.Add(map);
                            j++;

                        }
                        if ((usrby.Count < i) && (usrby.Count == j))
                        {
                            j = 0;
                        }
                        if (usrby.Count > i)
                        {
                            map.FeedbackBy = usrby[i];
                            map.FeedbackTo = usr;
                            maptoby.Add(map);
                        }
                        i++;
                    }
                }
            }
            catch (Exception ex)
            {
                var obj = Utilities.GetInstance();
                obj.LogErrorMessage(ex.Message);
            }

            return maptoby;
        }
        public string UpdateScheduleData(int fsid,bool fstatus, List<MappingToByDetail> maptoby)
        {
            string msg = string.Empty;
            try
            {
                foreach (var obj in maptoby)
                {
                    FeedbackSchedulingDetail feddet = new FeedbackSchedulingDetail();
                    feddet.FSID = fsid;
                    feddet.Fstatus = fstatus;
                    feddet.FComment = "Submitted";
                    feddet.FeedBackBy = obj.FeedbackBy.Name;
                    feddet.FeedBackTo = obj.FeedbackTo.Name;
                    _context.FeedBackSchedulingDetailInfo.Add(feddet);
                    _context.SaveChanges();
                }
                msg = "Success";
            }
            catch(Exception ex)
            {
                var obj = Utilities.GetInstance();
                obj.LogErrorMessage(ex.Message);
            }

            return msg;
        }
        public List<FeedbackSchedulingDetail> GetScheduledFeedback()
        {
            List<FeedbackSchedulingDetail> fedschedet = new List<FeedbackSchedulingDetail>();
            fedschedet = _context.FeedBackSchedulingDetailInfo.ToList();
            return fedschedet;
        }
    }
}
