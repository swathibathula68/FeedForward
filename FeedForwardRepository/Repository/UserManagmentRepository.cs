using FeedForwardBusinessEntities.EntityContext;
using FeedForwardBusinessEntities.EntityModels;
using FeedForwardRepository.Abstract;
using FeedForwardUtilities;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FeedForwardRepository.Repository
{
    
    public class UserManagmentRepository : IUserManagmentRepository
    {
        FeedForwardContext _context = new FeedForwardContext();
        public UserDetailViewModel DropDown()
        {
            UserDetailViewModel usr = new UserDetailViewModel();
            try
            {
                List<RoleDetail> roleList = new List<RoleDetail>();
                roleList = _context.RoleDetailInfo.ToList();

                List<DesignationLevel> designationList = new List<DesignationLevel>();
                designationList=_context.DesignationLevelInfo.ToList();
                usr.RoleList = roleList;
                usr.DesignationList = designationList;
            }
            catch(Exception ex)
            {
                var obj = Utilities.GetInstance();
                obj.LogErrorMessage(ex.Message);
            }
            return usr;
        }
        public string RegisterUser(UserDetail userdet)
        {
            string msg = string.Empty;
            
            try
            {
                userdet.CreatedDate = DateTime.Now;
                _context.Add(userdet);
                _context.SaveChanges();
                msg = "Registered Successfuly";
            }
            catch(Exception ex)
            {
                var obj = Utilities.GetInstance();
                obj.LogErrorMessage(ex.Message);
            }
            return msg;
        }
        public UserDetail AuthenticateCurrentUser(UserLoginViewModel user)
        {
            UserDetail usr= new UserDetail();
            try
            {
                usr = _context.UserDetailInfo.FirstOrDefault(x => x.UserID ==user.UserID && x.Password==user.Password);
            }
            catch (Exception ex)
            {
                var obj = Utilities.GetInstance();
                obj.LogErrorMessage(ex.Message);
            }
            return usr;
        }
        public UserDetail AuthenticateCurrentUser(string UserID)
        {
            UserDetail user = new UserDetail();
            try
            {
                user = _context.UserDetailInfo.FirstOrDefault(x => x.UserID == UserID);
            }
            catch (Exception ex)
            {
                var obj = Utilities.GetInstance();
                obj.LogErrorMessage(ex.Message);
            }
            return user;
        }
        public string updatepassword(ChangePasswordViewModel chpwd)
        {
            string msg = string.Empty;
            UserDetail usr = new UserDetail();
            try
            {
                usr = _context.UserDetailInfo.FirstOrDefault(x => x.UserID == chpwd.UserID);
                if (usr.Password == chpwd.OldPassword)
                {
                    string newpwd= chpwd.NewPassword;
                    usr.Password= newpwd;
                    string connewpwd = chpwd.ConfirmNewPassword;
                    usr.PasswordChangeDate = DateTime.Now;
                    if(newpwd==connewpwd)
                    {
                        _context.SaveChanges();
                        msg = "Password updated succesfully";
                    }
                }
               
            }
            catch(Exception ex)
            {
                var obj = Utilities.GetInstance();
                obj.LogErrorMessage(ex.Message);
            }
            return msg;
        }
        public string forgotPassword(ForgotpwdViewModel forpwd)
        {
            string msg = string.Empty;
            UserDetail user = new UserDetail();
            try
            {
                user=_context.UserDetailInfo.FirstOrDefault(user => user.UserID == forpwd.UserID);

                user.Password = forpwd.NewPassword;
                user.PasswordChangeDate= DateTime.Now;
                
                _context.SaveChanges();
                msg = "Password saved succesfully";
            }
            catch(Exception ex)
            {
                var obj = Utilities.GetInstance();
                obj.LogErrorMessage(ex.Message);
            }
            return msg;

        }
        public List<DesignationLevel> QuestionTemplateDropDown()
        {
            Quessearchviewmodel questemp = new Quessearchviewmodel();
            List<DesignationLevel> lvlID = new List<DesignationLevel>();
            try
            {
                
                
                lvlID= _context.DesignationLevelInfo.ToList();
               

            }
            catch (Exception ex)
            {
                var obj = Utilities.GetInstance();
                obj.LogErrorMessage(ex.Message);
            }
            return lvlID;
        }
        public string insertquestion(Quessearchviewmodel quesdet)
        {
            QuestionDetail ques=new QuestionDetail();
            string msg = string.Empty;
            try
            {
                ques.CreatedDate = DateTime.Now;
                ques.CreatedBy = "swathi";
                ques.Question=quesdet.Question;
                _context.Add(ques);
                _context.SaveChanges();
                msg = "question saved succesful";
            }
            catch(Exception ex)
            {
                var obj = Utilities.GetInstance();
                obj.LogErrorMessage(ex.Message);
            }
            return msg;
        }
        public Quessearchviewmodel getquestions(SearchClass cls)
        {
            Quessearchviewmodel questemp = new Quessearchviewmodel();
            
            List<QuestionDetail> QuesLst = new List<QuestionDetail>();
            try
            {
                
                QuesLst=_context.QuestionDetailInfo.Where(x=>x.Question.Contains(cls.Search)).ToList();
                questemp.questionlist= QuesLst;
               
            }
            catch(Exception ex)
            {
                var obj = Utilities.GetInstance();
                obj.LogErrorMessage(ex.Message);
            }
            return questemp;
        }
        public List<QuestionDetail> GetAllQuestions()
        {
            Quessearchviewmodel quessearch = new Quessearchviewmodel();
            List<QuestionDetail> QuesLst = new List<QuestionDetail>();
            QuesLst = _context.QuestionDetailInfo.ToList();
            //quessearch.questionlist= QuesLst;   
            return QuesLst;
        }
    }
}
