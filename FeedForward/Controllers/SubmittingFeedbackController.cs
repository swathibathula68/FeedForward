using FeedForwardBusinessEntities.EntityModels;
using FeedForwardRepository.Abstract;
using FeedForwardRepository.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FeedForward.Controllers
{
    public class SubmittingFeedbackController : Controller
    {
        ISubmittingFeedbackRepository _repo;
        //List<QuestionDetail> lstques = new List<QuestionDetail>();
        public SubmittingFeedbackController(ISubmittingFeedbackRepository repo)
        {
            _repo = repo;
        }
        static public int i = 0;
        [HttpGet]
        public IActionResult SubmitFeedBack(string SchID,string FTo)
        {
            string currUserID = HttpContext.Session.GetString("UserID");
            if(currUserID==null)
            {
                return RedirectToAction("UserLogin", "UserManagment");
            }
            List<FeedBackCaption> lst = _repo.GetAllCaption();
            List<QuestionDetail> lstques = _repo.GetAllQuestion();
            SubmittingFeedbackViewModel subfed = new SubmittingFeedbackViewModel();
            subfed.fedcap = lst;
            subfed.QID = lstques[i].QID;
            subfed.Question = lstques[i].Question;

            return View(subfed);

        }
        
        [HttpPost]
        public IActionResult SubmitFeedBack(int FCID, bool FStatus, int SchID, string btn)
        {
            string currUserID = HttpContext.Session.GetString("UserID");
            string msg = string.Empty;
            ViewBag.UID = currUserID;
            SubmittingFeedbackViewModel subfed = new SubmittingFeedbackViewModel();
            List<QuestionDetail> lstques = new List<QuestionDetail>();
            lstques = _repo.GetAllQuestion();
            FeedBackSubmittingDetail subdet=new FeedBackSubmittingDetail();
            subfed.fedcap = _repo.GetAllCaption();
            if (FStatus == true)
            {
                ViewBag.Quescompleted = true;
                ViewBag.Question = "Feedback  already submitted for this Schedule ID";
            }
            else
            {
                if (btn.Equals("Next"))
                {
                    if (FCID <= 0)
                    {
                        ViewBag.Question = "Select any one caption";
                        return View(subfed);
                    }
                    if (i < lstques.Count)
                    {
                        subdet.FCID = FCID;
                        subdet.QID = lstques[i].QID;
                        subdet.Ffrom = currUserID;
                        subfed.SchID = SchID;
                        i++;

                    }
                    if(i!=lstques.Count)
                    {
                        subfed.QID = lstques[i].QID;
                        subfed.Question= lstques[i].Question;
                    }
                    else
                    {
                        msg = _repo.UpdateFeedBackStatus(true, SchID);
                        if(msg=="success")
                        {
                            ViewBag.Info = "All Questions Saved Succesfully";
                        }
                        else
                        {
                            ViewBag.Info = "Try Again";
                        }
                        subfed.Question = null;
                        subfed.QID = 0;
                        ViewBag.Finish = true;
                    }

                    return View(subfed);
                    
                }
                i++;
            }
            if(btn=="Button")
            {

            }
            subfed.FCID = 0;
            return View(subfed);
        }
        //public IActionResult FeedbackSubmittedPage(string btn, int FCID, int SchID, bool FStatus)
        //{
        //    //List<QuestionDetail> lstquestions = new List<QuestionDetail>();
        //    lstquestions = _repo.GetAllQuestionList();
        //    string msg = string.Empty;
        //    string currUID = HttpContext.Session.GetString("MyUID");

        //    ViewBag.UID = currUID;
        //    FeedbackSubmittedViewModel FBSubmitVM = new FeedbackSubmittedViewModel();

        //    ViewBag.Touser = staticFeedbackTo;
        //    FeedbackSubmittingDetail obj = new FeedbackSubmittingDetail();
        //    // FeedbackSchedulingDetail objusersch= _repo2.GetFeedbackSchedulingDetailsonSchID(SchID);
        //    // string FeedbackTo = _repo2.GetFeedbackSchedulingDetailsonSchID(SchID);
        //    FBSubmitVM.lstobjFBC = _repo.GetAllFeedbackCaptionsList();



        //    if (FStatus == true)
        //    {
        //        ViewBag.Qfinished = true;
        //        ViewBag.Question = "Feedback  already submitted for this Schedule ID";
        //    }
        //    else
        //    {


        //        if (btn.Equals("Next"))
        //        {
        //            if (FCID <= 0)
        //            {
        //                ViewBag.Question = "Select any one caption";
        //                return View(staticFBSubmitVM);
        //            }
        //            if (i < lstquestions.Count)
        //            {
        //                obj.FCID = FCID;
        //                obj.QID = lstquestions[i].QID;
        //                obj.Ffrom = currUID;

        //                obj.SchID = SchID;
        //                //get user details of Fto from Feedbackscheduling  matching with Feedbackscheduling.SchID=SchID
        //                obj.Fto = staticFeedbackTo;
        //                //lstFBsubmitDetails.Add(obj);
        //                _context.FeedbackSubmittingDetailInfo.Add(obj);
        //                _context.SaveChanges();

        //                i++;


        //                if (i != lstquestions.Count)
        //                {
        //                    FBSubmitVM.QSiNo = lstquestions[i].QSiNo;
        //                    FBSubmitVM.Question = lstquestions[i].Question;
        //                }

        //                else
        //                {

        //                    //SET FEEDBACK STATUS IN FBTSCHTABLE TO TRUE
        //                    //ObjfeedschedulingDetail.FStatus = true;
        //                    msg = _repo2.UpdateFeedbackSchedulingstatus(true, SchID);
        //                    if (msg.Equals("success"))
        //                    {


        //                        ViewBag.Question = "Thank you for your feedback,All feedback Questions successfully submitted";
        //                    }
        //                    else
        //                        ViewBag.Question = "Thank you for your feedback,All feedback Questions successfully submitted but status not saved";


        //                    FBSubmitVM.Question = null;
        //                    FBSubmitVM.QSiNo = 0;

        //                    ViewBag.Qfinished = true;
        //                    return View(FBSubmitVM);
        //                }
        //            }

        //        }
        //        //FBSubmitVM.Question = "Thank you";
        //        //ViewBag.Question = "Thank you for your feedback,All feedback Questions successfully submitted ";
        //    }

        //    FBSubmitVM.FCID = 0;
        //    return View(FBSubmitVM);

        //}

    }
}
