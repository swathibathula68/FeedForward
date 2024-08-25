using FeedForwardBusinessEntities.EntityModels;
using FeedForwardRepository.Abstract;
using FeedForwardUtilities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text;
using Newtonsoft.Json;

namespace FeedForward.Controllers
{

    public class UserManagmentController : Controller
    {
        IUserManagmentRepository _repo;
        public UserManagmentController(IUserManagmentRepository repo)
        {
            _repo = repo;
        }
        public IActionResult Home()
        {
           return RedirectToAction("Index", "HomeScreen");
        }
        public IActionResult Aboutus()
        {
            return View();
        }
        public IActionResult Contactus()
        {
            return View();
        }
        [HttpGet]
        public IActionResult RegistrationPage()
        {
            UserDetailViewModel usr = _repo.DropDown();
            return View(usr);
        }
        [HttpPost]
        public async Task<IActionResult> RegistrationPage(UserDetail usr,string btn)
        {
            if (btn == "Submit")
            {
                Random rnd = new Random();
                int pwd = rnd.Next(10000, 99999);
                usr.Password = pwd.ToString();
                string msg = _repo.RegisterUser(usr);
                string MailMsg = "please use this UserID  " + usr.UserID + "and password  " + pwd;
                if (msg == "Registered Successfuly")
                {
                    Utilities.SendEmail("bathuswathi1234@gmail.com", usr.Email, "Greetings of the day ", MailMsg);
                    return RedirectToAction("UserLogin");
                }
                return View();
             
            }
            else
            {
                string apiBaseurl = "https://localhost:7229/";
                string Endpoint = string.Empty;
                UserDetail user = new UserDetail();
                user.DesignationID = usr.DesignationID;
                user.Email = usr.Email;
                user.EmpID = usr.EmpID;
                user.Name=usr.Name;
                user.RoleID = usr.RoleID;
                user.UserID=usr.UserID;
                user.Mobile = usr.Mobile;   
               
                
                using (HttpClient client = new HttpClient())
                {
                    Endpoint = apiBaseurl + "api/APIUserManagement/Registeruser";
                    StringContent content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/Json");
                    var resp = await client.PostAsync(Endpoint, content);
                    UserDetailViewModel usr_det = _repo.DropDown();
                    if (resp.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        
                        ViewBag.Info = "Data Saved successfully";
                        
                        //return RedirectToAction("UserLogin");

                    }
                    else
                    {
                        ViewBag.Info = "Data not saved successfully";
                    }
                    return View(usr_det);

                }
                //return View();
            }
        }
        [HttpGet]
        public IActionResult UserLogin()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UserLogin(UserLoginViewModel usr,string btn)
        {
            if (btn == "Login")
            {
                UserDetail dt = _repo.AuthenticateCurrentUser(usr);

                HttpContext.Session.SetString("UserID", usr.UserID);
                if (dt != null)
                {
                    if (dt.PasswordChangeDate == null || dt.PasswordChangeDate < DateTime.Now.AddDays(-30))
                    {
                        return RedirectToAction("PasswordChangePage");
                    }

                    string[] userroles = new string[] { (dt.RoleID).ToString() };
                    var claims = new List<Claim>();
                    claims.Add(new Claim("username", dt.UserID));

                    foreach (var eachrole in userroles)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, eachrole));

                    }
                    var claimsidentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var claimsprinciple = new ClaimsPrincipal(claimsidentity);
                    await HttpContext.SignInAsync(claimsprinciple);

                    return RedirectToAction("Index", "HomeScreen");
                }
                else
                {
                    ViewBag.Info = "Invalid user ID or password";
                }
                return View(dt);
            }
            else
            {
                string apiBaseurl = "https://localhost:7229/";
                string Endpoint = string.Empty;
                UserLoginViewModel user = new UserLoginViewModel();
                user.Password = usr.Password;
                user.UserID = usr.UserID;
                using (HttpClient client = new HttpClient())
                {
                    Endpoint = apiBaseurl + "api/APIUserManagement/UserLogin";
                    StringContent content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/Json");
                    var resp = await client.PostAsync(Endpoint, content);
                    if (resp.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        //ViewBag.Info = "Data Saved successfully";
                        return RedirectToAction("UserLogin");

                    }
                    else
                    {
                        ViewBag.Info = "Data not saved successfully";
                    }
                    return View();
                }
            }
            return View();
        }
        [HttpGet]
        public IActionResult PasswordChangePage()
        {
            
            string currUserID=HttpContext.Session.GetString("UserID");
            if(!string.IsNullOrEmpty(currUserID))
            {
                ViewBag.CurrentUserID=currUserID;
            }
            return View();
        }
       
        [HttpPost]
        public IActionResult PasswordChangePage(ChangePasswordViewModel chpwd)
        {
            string currUserID = HttpContext.Session.GetString("UserID");
            chpwd.UserID = currUserID;
            string msg = _repo.updatepassword(chpwd);
            if (msg == "Password update succesfully") ;
            {
                ViewBag.msg = "your password is updated succesfully";
            }
            return View();
        }
        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ForgotPassword(ForgotpwdViewModel forpwd,string btn)
        {
            UserDetail usr =_repo.AuthenticateCurrentUser(forpwd.UserID);
            if (btn == "Next")
            {
                
                Random rmd = new Random();
                int otp = rmd.Next(10000, 99999);
                HttpContext.Session.SetString("otp", otp.ToString());
               
                string MailMsg = "Your OTP is  " + otp;
                Utilities.SendEmail("bathuswathi1234@gmail.com",usr.Email,"Greetings of the day", MailMsg);
                return View();
            }
            else if(btn=="Submit")
            {
                string OTP = HttpContext.Session.GetString("otp");
                if(OTP==forpwd.OTP)
                {
                    return View();
                }
                return RedirectToAction("Index", "HomeScreen");
            }
            else
            {
                HttpContext.Session.SetString("CurrentUserID", forpwd.UserID);
                string CurrentUserID = HttpContext.Session.GetString("CurrentUserID");
                if (CurrentUserID!=null)
                {
                    string msg = _repo.forgotPassword(forpwd);
                    if(msg== "Password saved succesfully")
                    {
                        return RedirectToAction("Index", "HomeScreen");
                    }
                   
                }
                return View();

            }
        }
        [HttpGet]
        public IActionResult InsertQuestion()
        {
            Quessearchviewmodel questemp =new Quessearchviewmodel();
            //DesignationLevel deslevel = new DesignationLevel();
            questemp.DesignationList = _repo.QuestionTemplateDropDown();
            //Quessearchviewmodel QuesDet = _repo.GetAllQuestions();
            questemp.questionlist = _repo.GetAllQuestions();

            return View(questemp);
        }
        [HttpPost]
        public IActionResult InsertQuestion(Quessearchviewmodel ques,string btn,SearchClass cls)
        {
            Quessearchviewmodel questemp = new Quessearchviewmodel();
            questemp.DesignationList = _repo.QuestionTemplateDropDown();

            if (btn=="Submit")
            {
                questemp.questionlist = _repo.GetAllQuestions();
               
                string msg = string.Empty;
                msg = _repo.insertquestion(ques);
                if (msg == "question saved succesful")
                {
                    ViewBag.Info = "Question Saved Succesfully";
                }

                
                return View(questemp);
            }
            else if(btn=="Search")
            {
                Quessearchviewmodel quest = _repo.getquestions(cls);
                quest.DesignationList = questemp.DesignationList;
                return View(quest);
            }
            else
            {

                string msg = "Exception";
            }
            return View(questemp);
        }
        
    }
}
