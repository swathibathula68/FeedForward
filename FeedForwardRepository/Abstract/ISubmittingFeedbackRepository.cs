using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FeedForwardBusinessEntities.EntityModels;

namespace FeedForwardRepository.Abstract
{
    public interface ISubmittingFeedbackRepository
    {
        List<FeedBackCaption> GetAllCaption();
        List<QuestionDetail> GetAllQuestion();
        string UpdateFeedBackStatus(bool status, int SchID);


    }
}
