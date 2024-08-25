using FeedForwardBusinessEntities.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedForwardRepository.Abstract
{
    public interface IUserManagmentRepository
    {
        UserDetailViewModel DropDown();
        string RegisterUser(UserDetail userdet);
        UserDetail AuthenticateCurrentUser(UserLoginViewModel user);
        UserDetail AuthenticateCurrentUser(string UserID);
        string forgotPassword(ForgotpwdViewModel forpwd);
       
        string updatepassword(ChangePasswordViewModel chpwd);
        List<DesignationLevel> QuestionTemplateDropDown();
        string insertquestion(Quessearchviewmodel quesdet);
        Quessearchviewmodel getquestions(SearchClass cls);
        List<QuestionDetail> GetAllQuestions();
    }
}
