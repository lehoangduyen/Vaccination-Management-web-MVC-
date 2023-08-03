using Covid19_Vaccination_Infogate_MVC.Models;
using Covid19_Vaccination_Infogate_MVC.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using Oracle.ManagedDataAccess.Client;
using System.Net.Mail;
using System.Net;
using System;
using System.Web.Helpers;
using System.Data;

namespace Covid19_Vaccination_Infogate_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            string message = "";
            var conn = new OracleConnection();
            conn.ConnectionString = "User Id=covid19_vaccination_infogate;Password=covid19_vaccination_infogate;Data Source=localhost/orcl";
            conn.Open();
            Account account = new Account();

            if (conn.State == System.Data.ConnectionState.Open)
            {
                string query = "select * from ACCOUNT where Username = :username";
                var command = new OracleCommand(query, conn);
                command.Parameters.Add(new OracleParameter("username", username));
                var reader = command.ExecuteReader();

                if (reader.HasRows == false)
                {
                    message = "NoAccount";
                    return Content(message, "text/html");
                }

                // account existed,
                while (reader.Read())
                {
                    // check password
                    if (password == (string)reader["PASSWORD"])
                    {   
                        switch (reader.GetInt32(reader.GetOrdinal("ROLE")))
                        {
                            case 0:
                            case 1:
                                query = "select * from ORGANIZATION where ID = :id";    //check exist profile
                                break;
                            case 2:
                                query = "select * from CITIZEN where Phone = :id";    //check exist profile
                                break;
                        }

                        command = new OracleCommand(query, conn);
                        command.Parameters.Add(new OracleParameter("id", username));
                        var reader2 = command.ExecuteReader();

                        if (reader2.HasRows == false)
                        {
                            message = "NoProfile";   //no profile existed
                            return Content(message, "text/html");
                        }

                        account = new Account();
                        account.Username = username;
                        account.Role = reader.GetInt32(reader.GetOrdinal("ROLE"));
                        account.Status = reader.GetInt32(reader.GetOrdinal("STATUS"));
                        
                        SessionHelper.SetObjectAsJson(HttpContext.Session, "AccountInfo", account);
                    }
                    else
                    {    //wrong password;
                        message = "incorrect password";
                        return Content(message, "text/html");
                    }
                }
            }
            else
            {
                message = "ERROR: Connection Fail!";
                return Content(message, "text/html");
            }
                

            conn.Close();
            message = "Login";
            return Content(message, "text/html");
        }

        public IActionResult Statistic()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



        public void SendEmail(string SenderName, string ReceiverMail, string ReceiverName, string subject, string content)
        {
            string message = "";
            try
            {
                if (ModelState.IsValid)
                {
                    var senderEmail = new MailAddress("20520418@gm.uit.edu.vn", SenderName);
                    var receiverEmail = new MailAddress(ReceiverMail, ReceiverName);
                    var password = "Cuong214789";
                    var sub = subject;
                    var body = content;
                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = true,
                        Credentials = new NetworkCredential(senderEmail.Address, password)
                    };
                    using (var mess = new MailMessage(senderEmail, receiverEmail)
                    {
                        Subject = subject,
                        Body = body
                    })
                    {
                        smtp.Send(mess);
                    }
                }
            }
            catch (Exception)
            {
                /*return "ORA-*****: Error in sending verification email!";*/
            }
        }

        [HttpPost]
        public IActionResult RegisterCheckExist(string username)
        {
            string message = "";

            var conn = new OracleConnection();
            conn.ConnectionString = "User Id=covid19_vaccination_infogate;Password=covid19_vaccination_infogate;Data Source=localhost/orcl";
            conn.Open();

            string query = "select * from ACCOUNT where Username = :username";
            var command = new OracleCommand(query, conn);
            command.Parameters.Add(new OracleParameter("username", username));
            var reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                message = "Account Existed!";
                return Content(message, "text/html");
            }

            return Content(message, "text/html");
        }

        [HttpPost]
        public IActionResult RegisterAccount(string username, string password)
        {
            string message = "";

            var conn = new OracleConnection();
            conn.ConnectionString = "User Id=covid19_vaccination_infogate;Password=covid19_vaccination_infogate;Data Source=localhost/orcl";
            conn.Open();

            var command = new OracleCommand("ACC_INSERT_RECORD", conn);
            command.Parameters.Add("par_Username", OracleDbType.Varchar2).Value = username;
            command.Parameters.Add("par_Password", OracleDbType.Varchar2).Value = password;
            command.Parameters.Add("par_Role", OracleDbType.Int16).Value = 2;
            command.Parameters.Add("par_Status", OracleDbType.Int16).Value = 0;
            try
            {
                var reader = command.ExecuteNonQuery();
            }
            catch (OracleException e)
            {
                message = "Account Existed!";
                return Content(message, "text/html");
            }

            HttpContext.Session.SetString("username", username);

            message = "Account Created!";
            return Content(message, "text/html");
        }

        [HttpPost]
        public IActionResult RegisterProfile(string lastname, string firstname, int gender, string id, string birthday, string hometown, string province, string district, string town, string street, string email)
        {
            string message = "";
            var conn = new OracleConnection();
            conn.ConnectionString = "User Id=covid19_vaccination_infogate;Password=covid19_vaccination_infogate;Data Source=localhost/orcl";

            string username = HttpContext.Session.GetString("username");
            conn.Open();
            var command = new OracleCommand("CITIZEN_INSERT_RECORD", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("par_ID", OracleDbType.Varchar2).Value = id;
            command.Parameters.Add("par_LastName", OracleDbType.Varchar2).Value = lastname;
            command.Parameters.Add("par_FirstName", OracleDbType.Varchar2).Value = firstname;
            command.Parameters.Add("par_Birthday", OracleDbType.Varchar2).Value = birthday;
            command.Parameters.Add("par_Gender", OracleDbType.Int16).Value = gender;
            command.Parameters.Add("par_HomeTown", OracleDbType.Varchar2).Value = hometown;
            command.Parameters.Add("par_ProvinceName", OracleDbType.Varchar2).Value = province;
            command.Parameters.Add("par_DistrictName", OracleDbType.Varchar2).Value = district;
            command.Parameters.Add("par_TownName", OracleDbType.Varchar2).Value = town;
            command.Parameters.Add("par_Street", OracleDbType.Varchar2).Value = street;
            command.Parameters.Add("par_Phone", OracleDbType.Varchar2).Value = username;
            command.Parameters.Add("par_Email", OracleDbType.Varchar2).Value = email;
            try
            {
                command.ExecuteNonQuery();
            }
            catch (OracleException e)
            {
                message = e.Message;
                return Content(message, "text/html");
            };
            conn.Close();

            message += "UpdateProfile";
            return Content(message, "text/html");
        }

        [HttpPost]
        public IActionResult ResetPassword(string email)
        {
            string message = "";
            string new_password = "";

            var conn = new OracleConnection();
            conn.ConnectionString = "User Id=covid19_vaccination_infogate;Password=covid19_vaccination_infogate;Data Source=localhost/orcl";
            conn.Open();

            string query = "select FirstName, Phone from CITIZEN where Email = :email";
            var command = new OracleCommand(query, conn);
            command.Parameters.Add(new OracleParameter("userName", email));
            var reader = command.ExecuteReader();

            if (reader.HasRows == false)
            {
                message = "NoAccount";
                return Content(message, "text/html");
            }

            string username = "";
            string ReceiverName = "";
            // account existed,
            while (reader.Read())
            {
                username = reader["Phone"] as string;
                ReceiverName = reader["FirstName"] as string;
            }

            Random rnd = new Random();
            for (int i = 0; i < 3; i++)
            {
                int unicode = rnd.Next(97, 122);
                char character = (char)unicode;
                new_password += character.ToString();
            }
            for (int i = 0; i < 6; i++)
            {
                int num = rnd.Next(0, 9);
                new_password += num.ToString();
            }
            for (int i = 0; i < 3; i++)
            {
                int unicode = rnd.Next(65, 90);
                char character = (char)unicode;
                new_password += character.ToString();
            }

            query = "update ACCOUNT set Password = :password where Username = :username";
            command = new OracleCommand(query, conn);
            command.Parameters.Add(new OracleParameter("password", new_password));
            command.Parameters.Add(new OracleParameter("username", username));
            try
            {
                command.ExecuteNonQuery();
            } catch(OracleException e)
            {
                message = e.Message;
                return Content(message, "text/html");

            }

            string content = "Mật khẩu mới của tài khoản " + username + " là: " + new_password 
                            + ".\nVui lòng bảo mật thông tin tài khoản cá nhân!\nXin cảm ơn.";

            SendEmail("Dịch vụ cấp lại mật khẩu Cổng thông tin tiêm chủng vaccine Covid19", email, ReceiverName,
                "CẤP LẠI MẬT KHẨU CHO TÀI KHOẢN TRÊN CỔNG THÔNG TIN TIÊM CHỦNG VACCINE COVID19", content);

            message = "ResetPassword";
            return Content(message, "text/html");
        }

        /*[HttpPost]*/
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return Json(new { message = "Logout" });
        }
    }
}
