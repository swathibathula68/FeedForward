using FeedForwardBusinessEntities.EntityModels;
using FeedForwardRepository.Abstract;
using FeedForwardRepository.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Net;

namespace FeedForward.Controllers
{
    
    public class FeedBackSchedulingController : Controller
    {
        static public List<MappingToByDetail> maptoby = new List<MappingToByDetail>();
        static public List<UserDetail> usrto=new List<UserDetail>();
        static public List<UserDetail> usrby = new List<UserDetail>();
        IFeedBackSchedulingRepository _repo; 
        public FeedBackSchedulingController(IFeedBackSchedulingRepository repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public IActionResult level()
        {
            string a = "0", b = "0", d = "0";
            int c = 0;
            FeedBackSchedulingViewModel feed = new FeedBackSchedulingViewModel();
            List<LevelDetail> lst = _repo.levl();
            List<UserDetail> usr = _repo.UserDetailToList(a,b,d);
            List<UserDetail> userby = _repo.UserDetailByList(a, b,c);
           //List<MappingToByDetail> maptoby = _repo.MappingToBY(null,null);
            List<FeedBackCategoryLevel> AllCat= _repo.AllCategory();
            List<FeedbackSession> fedses = _repo.GetFeedbackSession();
            feed.FeedbackCategory = AllCat;
            feed.userdetailtolst = usr;
            feed.userdetailBylst= userby;
            feed.ToByList = null;
            feed.feedbacksessionlist = fedses;



            List<SelectListItem> levelList = new List<SelectListItem>();
            foreach (LevelDetail eachlevel in lst)
            {
                SelectListItem obj = new SelectListItem();
                obj.Text = eachlevel.LevelDescription;
                obj.Value = eachlevel.LevelID.ToString();
                levelList.Add(obj);
            }

            ViewData["LevelList"] = levelList;
            return View(feed);
           
        }
        [HttpGet]
        public JsonResult GetDesignation(string id)
        {
            List<DesignationLevel> deslvl = _repo.desg(id);
           
            List<SelectListItem> desgList = new List<SelectListItem>();
            foreach(DesignationLevel eachlevel in deslvl)
            {
                SelectListItem obj = new SelectListItem();
                obj.Text = eachlevel.Designation;
                obj.Value = eachlevel.DesignationID.ToString();
                desgList.Add(obj);
            }
            return Json(desgList);
            

        }
        [HttpPost]
        public IActionResult level(string LevelDetail, int FCLid,string DesignationLevel,string btn,int FSID)
        {
                
                FeedBackSchedulingViewModel feed = new FeedBackSchedulingViewModel();
                List<LevelDetail> lst = _repo.levl();
            List<FeedBackCategoryLevel> AllCat = _repo.AllCategory();
            List<FeedbackSession> fedses = _repo.GetFeedbackSession();


            string currUserID = HttpContext.Session.GetString("UserID");
            if (btn == "Schedule")
            {
                 usrto = _repo.UserDetailToList(LevelDetail, DesignationLevel, currUserID);
                 usrby = _repo.UserDetailByList(LevelDetail, DesignationLevel, FCLid);
                feed.userdetailtolst = usrto;
                feed.userdetailBylst = usrby;
                maptoby = _repo.MappingToBY(feed.userdetailtolst, feed.userdetailBylst);
                //List<FeedBackCategoryLevel> AllCat = _repo.AllCategory();
                //List<FeedbackSession> fedses = _repo.GetFeedbackSession();
                //List<SelectListItem> levelList = new List<SelectListItem>();
                //foreach (LevelDetail eachlevel in lst)
                //{
                //    SelectListItem obj = new SelectListItem();
                //    obj.Text = eachlevel.LevelDescription;
                //    obj.Value = eachlevel.LevelID.ToString();
                //    levelList.Add(obj);
                //}

                //ViewData["LevelList"] = levelList;
                ////return View(feed);

                //feed.FeedbackCategory = AllCat;
                //feed.feedbacksessionlist = fedses;
                //feed.ToByList = maptoby;

                //return View(feed);
            }
            
            else if (btn == "Submit")
            {
                string msg = string.Empty;
                bool Feedstatus = false;
                
               
                msg = _repo.UpdateScheduleData(FSID,Feedstatus,maptoby);
                if(msg=="Success")
                {
                    ViewBag.msg = "Feedback Scheduled Succesfully";
                    
                }
                else
                {
                    ViewBag.msg = "Feedback Not Scheduled";
                }

            }
            List<SelectListItem> levelList = new List<SelectListItem>();
            foreach (LevelDetail eachlevel in lst)
            {
                SelectListItem obj = new SelectListItem();
                obj.Text = eachlevel.LevelDescription;
                obj.Value = eachlevel.LevelID.ToString();
                levelList.Add(obj);
            }

            ViewData["LevelList"] = levelList;
            feed.userdetailtolst = usrto;
            feed.userdetailBylst = usrby;
            feed.FeedbackCategory = AllCat;
            feed.feedbacksessionlist = fedses;
            feed.ToByList = maptoby;
            return View(feed);
        }
        [HttpGet]
        public IActionResult ScheduledFeedback()
        {
            List<FeedbackSchedulingDetail> fedscheddet = _repo.GetScheduledFeedback();
            
            return View(fedscheddet);
        }
        
    }
}
