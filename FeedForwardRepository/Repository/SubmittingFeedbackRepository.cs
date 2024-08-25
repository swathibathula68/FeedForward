using FeedForwardBusinessEntities.EntityContext;
using FeedForwardBusinessEntities.EntityModels;
using FeedForwardRepository.Abstract;
using FeedForwardUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedForwardRepository.Repository
{
    
    public class SubmittingFeedbackRepository:ISubmittingFeedbackRepository
    {
        FeedForwardContext _context = new FeedForwardContext();
        public List<FeedBackCaption> GetAllCaption()
        {
            List<FeedBackCaption> fedcap = new List<FeedBackCaption>();
            try
            {
                fedcap = _context.FeedbackInfo.ToList();
            }
            catch (Exception ex)
            {
                var obj = Utilities.GetInstance();
                obj.LogErrorMessage(ex.Message);
            }
            return fedcap;

            
        }
        public List<QuestionDetail> GetAllQuestion()
        {
            List<QuestionDetail> lstques=new List<QuestionDetail>();
            try
            {
                lstques = _context.QuestionDetailInfo.ToList();
            }
            catch (Exception ex)
            {
                var obj = Utilities.GetInstance();
                obj.LogErrorMessage(ex.Message);
            }
            return lstques;
        }
        public string UpdateFeedBackStatus(bool status, int SchID)
        {
            string msg = string.Empty;
            FeedbackSchedulingDetail fedsche=new FeedbackSchedulingDetail();
            try
            {
                fedsche = _context.FeedBackSchedulingDetailInfo.FirstOrDefault(x => x.SchID == SchID);
                fedsche.Fstatus = status;
                _context.SaveChanges();
                msg = "success";
            }
            catch(Exception ex)
            {
                var obj = Utilities.GetInstance();
                obj.LogErrorMessage(ex.Message);

            }
            return msg;
        }
    }
}
