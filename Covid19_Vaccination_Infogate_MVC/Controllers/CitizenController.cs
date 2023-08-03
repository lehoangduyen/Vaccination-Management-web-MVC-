using Covid19_Vaccination_Infogate_MVC.Models;
using Covid19_Vaccination_Infogate_MVC.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging; 
using System.Diagnostics;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Net.Mail;
using System.Net;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography;
using System.Web.WebPages;

namespace Covid19_Vaccination_Infogate_MVC.Controllers
{
    
    public class CitizenController : Controller
    {
        private readonly ILogger<CitizenController> _logger;

        public CitizenController(ILogger<CitizenController> logger)
        {
            _logger = logger;
        }
        private void LoadCitizenProfile()
        {
            Citizen citizen = new Citizen();
            Account account = SessionHelper.GetObjectFromJson<Account>(HttpContext.Session, "AccountInfo");

            SessionHelper.GetObjectFromJson<Account>(HttpContext.Session, "AccountInfo");
            var conn = new OracleConnection();
            conn.ConnectionString = "User Id=covid19_vaccination_infogate;Password=covid19_vaccination_infogate;Data Source=localhost/orcl";
            conn.Open();

            string query = "select ID, LastName, FirstName, TO_CHAR( Birthday, 'YYYY-MM-DD' ) Birthday, Gender,"
            + "Hometown, ProvinceName, DistrictName, TownName, Street,"
            + "Phone, Email, Guardian, Avatar "
            + "from CITIZEN where Phone= :username";
            var command = new OracleCommand(query, conn);
            command.Parameters.Add(new OracleParameter("username", account.Username));
            try
            {
                var reader = command.ExecuteReader();

                if (reader.HasRows == false)
                    return;

                while (reader.Read())
                {
                    citizen.LastName = reader["LASTNAME"] as string;
                    citizen.FirstName = reader["FIRSTNAME"] as string;
                    citizen.Id = reader["ID"] as string;
                    string date = reader["BIRTHDAY"] as string;
                    citizen.Birthday = reader["BIRTHDAY"] as string;
                    citizen.Gender(reader.GetInt32(reader.GetOrdinal("GENDER")));
                    citizen.HomeTown = reader["HOMETOWN"] as string;
                    citizen.ProvinceName = reader["PROVINCENAME"] as string;
                    citizen.DistrictName = reader["DISTRICTNAME"] as string;
                    citizen.TownName = reader["TOWNNAME"] as string;
                    citizen.Street = reader["STREET"] as string;
                    citizen.Phone = reader["PHONE"] as string;
                    citizen.Email = reader["EMAIL"] as string;
                    citizen.Guadian = reader["GUARDIAN"] as string;
                    /*citizen.Avatar = (byte[])reader["AVATAR"];*/
                }
                conn.Close();

                SessionHelper.SetObjectAsJson(HttpContext.Session, "CitizenProfile", citizen);
            } catch (OracleException e)
            {
            }
            return;
        }

        public IActionResult Index()
        {
            Account account = SessionHelper.GetObjectFromJson<Account>(HttpContext.Session, "AccountInfo");
            if (account != null && account.Role == 2 && account.Status == 1)
            {
                if (SessionHelper.GetObjectFromJson<Citizen>(HttpContext.Session, "CitizenProfile") == null)
                    LoadCitizenProfile();
                return View();
            }
            else
            {
                Response.Redirect("/Home");
                return Json(new { message = "Redirected to /Home" });
            }

            return Profile();
        }

        public IActionResult MedicalForm()
        {
            Account account = SessionHelper.GetObjectFromJson<Account>(HttpContext.Session, "AccountInfo");
            if (account != null && account.Role == 2 && account.Status == 1)
            {
                if (SessionHelper.GetObjectFromJson<Citizen>(HttpContext.Session, "CitizenProfile") == null)
                    LoadCitizenProfile();
                return View();
            }
            else
            {
                Response.Redirect("/Home");
                return Json(new { message = "Redirected to /Home" });
            }
        }

        public IActionResult MedicalFormList()
        {
            Account account = SessionHelper.GetObjectFromJson<Account>(HttpContext.Session, "AccountInfo");
            if (account != null && account.Role == 2 && account.Status == 1)
            {
                if (SessionHelper.GetObjectFromJson<Citizen>(HttpContext.Session, "CitizenProfile") == null)
                    LoadCitizenProfile();
                return View();
            }
            else
            {
                Response.Redirect("/Home");
                return Json(new { message = "Redirected to /Home" });
            }
        }

        public IActionResult Vaccination()
        {
            Account account = SessionHelper.GetObjectFromJson<Account>(HttpContext.Session, "AccountInfo");
            if (account != null && account.Role == 2 && account.Status == 1)
            {
                if (SessionHelper.GetObjectFromJson<Citizen>(HttpContext.Session, "CitizenProfile") == null)
                    LoadCitizenProfile();
                return View();
            }
            else
            {
                Response.Redirect("/Home");
                return Json(new { message = "Redirected to /Home" });
            }
        }

        public IActionResult AccountInfo()
        {
            Account account = SessionHelper.GetObjectFromJson<Account>(HttpContext.Session, "AccountInfo");
            if (account != null && account.Role == 2 && account.Status == 1)
            {
                if (SessionHelper.GetObjectFromJson<Citizen>(HttpContext.Session, "CitizenProfile") == null)
                    LoadCitizenProfile();
                return View();
            }
            else
            {
                Response.Redirect("/Home");
                return Json(new { message = "Redirected to /Home" });
            }
        }

        public IActionResult Profile()
        {
            Account account = SessionHelper.GetObjectFromJson<Account>(HttpContext.Session, "AccountInfo");
            if (account != null && account.Role == 2 && account.Status == 1)
            {
                if (SessionHelper.GetObjectFromJson<Citizen>(HttpContext.Session, "CitizenProfile") == null)
                    LoadCitizenProfile();
                return View();
            }
            else
            {
                Response.Redirect("/Home");
                return Json(new { message = "Redirected to /Home" });
            }
        }

        public IActionResult Registration()
        {
            Account account = SessionHelper.GetObjectFromJson<Account>(HttpContext.Session, "AccountInfo");
            if (account != null && account.Role == 2 && account.Status == 1)
            {
                if (SessionHelper.GetObjectFromJson<Citizen>(HttpContext.Session, "CitizenProfile") == null)
                    LoadCitizenProfile();
                return View();
            }
            else
            {
                Response.Redirect("/Home");
                return Json(new { message = "Redirected to /Home" });
            }
        }
        public IActionResult Certificate()
        {
            Account account = SessionHelper.GetObjectFromJson<Account>(HttpContext.Session, "AccountInfo");
            if (account != null && account.Role == 2 && account.Status == 1)
            {
                if (SessionHelper.GetObjectFromJson<Citizen>(HttpContext.Session, "CitizenProfile") == null)
                    LoadCitizenProfile();
                return View();
            }
            else
            {
                Response.Redirect("/Home");
                return Json(new { message = "Redirected to /Home" });
            }
        }
        public IActionResult SearchCitizen()
        {
            Account account = SessionHelper.GetObjectFromJson<Account>(HttpContext.Session, "AccountInfo");
            if (account != null && account.Role == 2 && account.Status == 1)
            {
                if (SessionHelper.GetObjectFromJson<Citizen>(HttpContext.Session, "CitizenProfile") == null)
                    LoadCitizenProfile();
                return View();
            }
            else
            {
                Response.Redirect("/Home");
                return Json(new { message = "Redirected to /Home" });
            }
        }
        public IActionResult AddRelative()
        {
            Account account = SessionHelper.GetObjectFromJson<Account>(HttpContext.Session, "AccountInfo");
            if (account != null && account.Role == 2 && account.Status == 1)
            {
                if (SessionHelper.GetObjectFromJson<Citizen>(HttpContext.Session, "CitizenProfile") == null)
                    LoadCitizenProfile();
                return View();
            }
            else
            {
                Response.Redirect("/Home");
                return Json(new { message = "Redirected to /Home" });
            }
        }

        //public IActionResult Statistic()
        //{
        //    Account account = SessionHelper.GetObjectFromJson<Account>(HttpContext.Session, "AccountInfo");
        //    if (account != null && account.Role == 2 && account.Status == 1)
        //    {
        //        if (SessionHelper.GetObjectFromJson<Citizen>(HttpContext.Session, "CitizenProfile") == null)
        //            LoadCitizenProfile();
        //        return View();
        //    }
        //    else
        //    {
        //        Response.Redirect("/Home");
        //        return Json(new { message = "Redirected to /Home" });
        //    }
        //}

        [HttpPost]
        public IActionResult UpdateAccount(string phone, string password, string new_password)
        {
            string message = "";
            Account account = SessionHelper.GetObjectFromJson<Account>(HttpContext.Session, "AccountInfo");
            var conn = new OracleConnection();
            conn.ConnectionString = "User Id=covid19_vaccination_infogate;Password=covid19_vaccination_infogate;Data Source=localhost/orcl";
            conn.Open();

            string query = "select Password from ACCOUNT where Username = :username";
            var command = new OracleCommand(query, conn);
            command.Parameters.Add(new OracleParameter("username", account.Username));
            var reader = command.ExecuteReader();

            reader.Read();
            account.Password = reader["Password"] as string;
            conn.Close();

            /*CHECK ENTERED PASSWORD*/
            if (password != account.Password)
            {
                account.Password = null;
                return Json(new { message = "Password is incorrect!" });
            }
            account.Password = null;

            /*CHANGE PASSWORD*/
            if (new_password == null || new_password == account.Password)
                message += "!ChangePassword";
            else
            {
                conn.Open();
                command = new OracleCommand("ACC_UPDATE_PASSWORD", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("par_Username", OracleDbType.Varchar2).Value = phone;
                command.Parameters.Add("par_OldPass", OracleDbType.Varchar2).Value = password;
                command.Parameters.Add("par_NewPass", OracleDbType.Varchar2).Value = new_password;
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

                message += "ChangePassword";
            }

            /*UPDATE USERNAME*/
            if (account.Role == 2)
            {
                if (phone == account.Username)
                {
                    message += "!UpdateAccount";
                }
                else
                {
                    Citizen citizen = SessionHelper.GetObjectFromJson<Citizen>(HttpContext.Session, "CitizenProfile");
                    conn.Open();
                    command = new OracleCommand("CITIZEN_UPDATE_RECORD", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("par_OldID", OracleDbType.Varchar2).Value = citizen.Id;
                    command.Parameters.Add("par_ID", OracleDbType.Varchar2).Value = citizen.Id;
                    command.Parameters.Add("par_LastName", OracleDbType.Varchar2).Value = citizen.LastName;
                    command.Parameters.Add("par_FirstName", OracleDbType.Varchar2).Value = citizen.FirstName;
                    command.Parameters.Add("par_Birthday", OracleDbType.Varchar2).Value = citizen.Birthday;
                    command.Parameters.Add("par_Gender", OracleDbType.Int16).Value = 1;
                    command.Parameters.Add("par_HomeTown", OracleDbType.Varchar2).Value = citizen.HomeTown;
                    command.Parameters.Add("par_ProvinceName", OracleDbType.Varchar2).Value = citizen.ProvinceName;
                    command.Parameters.Add("par_DistrictName", OracleDbType.Varchar2).Value = citizen.DistrictName;
                    command.Parameters.Add("par_TownName", OracleDbType.Varchar2).Value = citizen.TownName;
                    command.Parameters.Add("par_Street", OracleDbType.Varchar2).Value = citizen.Street;
                    command.Parameters.Add("par_Phone", OracleDbType.Varchar2).Value = phone;
                    command.Parameters.Add("par_OldPhone", OracleDbType.Varchar2).Value = citizen.Phone;
                    command.Parameters.Add("par_Email", OracleDbType.Varchar2).Value = citizen.Email;
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

                    message += "UpdateAccount";

                    account.Username = phone;
                    SessionHelper.SetObjectAsJson(HttpContext.Session, "AccountInfo", account);
                }
            }

            return Content(message, "text/htmlm");
        }

        [HttpPost]
        public IActionResult LoadCertificate()
        {
            string message = "";
            string citizenid = SessionHelper.GetObjectFromJson<Citizen>(HttpContext.Session, "CitizenProfile").Id;

            var conn = new OracleConnection();
            conn.ConnectionString = "User Id=covid19_vaccination_infogate;Password=covid19_vaccination_infogate;Data Source=localhost/orcl";
            conn.Open();

            string query = "select InjNO, DoseType, OnDate, VaccineID, Name from"
                            + " (select * from INJECTION where CitizenID = :citizenid) INJ"
                            + " join"
                            + " ("
                                + " select SCHED.ID  as ID, OnDate, VaccineID, Name  from"
                                + " (select ID, OrgID, OnDate, VaccineID, Serial from SCHEDULE) SCHED"
                                + " join"
                                + " (select ID, Name from ORGANIZATION) ORG"
                                + " on SCHED.OrgID = ORG.ID"
                            + " ) SCHED_ORG"
                            + " on INJ.SchedID = SCHED_ORG.ID";

          
            var command = new OracleCommand(query, conn);
            command.Parameters.Add(new OracleParameter("citizenid", citizenid));

            string html = "";
            try
            {
                int count = 0;
                string dosetype = "";

                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    count++;
                    switch(reader["DOSETYPE"] as string)
                    {
                        case "basic":
                            dosetype = "Cơ bản";
                            break;
                        case "booster":
                            dosetype = "Tăng cường";
                            break;
                        case "repeat":
                            dosetype = "Nhắc lại";
                            break;
                        default:
                            dosetype = "";
                            break;
                    }
                    DateTime date = (DateTime)reader["ONDATE"];

                    html +="<div class='injection'>"
                            + "<p>Mũi " + reader["INJNO"] + " (" + dosetype + ")</p>"
                            + "<p>Vaccine: " + reader["VACCINEID"] + "</p>"
                            + "<p>Đơn vị tiêm chủng: " + reader["NAME"] + "</p>"
                            + "<p>Lịch tiêm ngày: " + date.ToString("yyyy/MM/dd") + "</p>"
                        + "</div>";
                }

                switch (count)
                {
                    case 0:
                        html = "<p class='status' id='0'>Chưa thực hiện tiêm chủng vaccine Covid-19</p>" + html;
                        break;
                    case 1:
                        html = "<p class='status' id='1'>Chưa tiêm đủ liều cơ bản vaccine Covid-19</p>" + html;
                        break;
                    default:
                        html = "<p class='status' id='" + count + "'>Đã tiêm đủ liều cơ bản vaccine Covid-19</p>" + html;
                        break;
                }
            }
            catch (OracleException e)
            {
                message = e.Message;
                return Content(message, "text/html");
            }

            return Content(html, "text/html");
        }

        [HttpPost]
        public IActionResult UpdateProfile(
            string lastname, string firstname, int gender, string id, string birthday,
            string hometown, string province, string district, string town, string street, string email)
        {
            string message = "";
            var conn = new OracleConnection();
            conn.ConnectionString = "User Id=covid19_vaccination_infogate;Password=covid19_vaccination_infogate;Data Source=localhost/orcl";

            Citizen citizen = SessionHelper.GetObjectFromJson<Citizen>(HttpContext.Session, "CitizenProfile");
            conn.Open();
            var command = new OracleCommand("CITIZEN_UPDATE_RECORD", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("par_OldID", OracleDbType.Varchar2).Value = citizen.Id;
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
            command.Parameters.Add("par_Phone", OracleDbType.Varchar2).Value = citizen.Phone;
            command.Parameters.Add("par_OldPhone", OracleDbType.Varchar2).Value = citizen.Phone;
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

            citizen.Id = id;
            citizen.LastName = lastname;
            citizen.FirstName = firstname;
            citizen.Birthday = birthday;
            citizen.Gender(gender);
            citizen.HomeTown = hometown;
            citizen.ProvinceName = province;
            citizen.DistrictName = district;
            citizen.TownName = town;
            citizen.Street = street;
            citizen.Email = email;

            SessionHelper.SetObjectAsJson(HttpContext.Session, "CitizenProfile", citizen);

            return Content(message, "text/html");
        }

        [HttpPost]
        public IActionResult LoadRegistration(int status, int vaccine, int time)
        {
            string message = "";
            Citizen citizen = SessionHelper.GetObjectFromJson<Citizen>(HttpContext.Session, "CitizenProfile");

            var conn = new OracleConnection();
            conn.ConnectionString = "User Id=covid19_vaccination_infogate;Password=covid19_vaccination_infogate;Data Source=localhost/orcl";
            conn.Open();

            string query = "select SchedID, Name, ProvinceName, DistrictName, TownName, Street, TO_CHAR(OnDate, 'YYYY-MM-DD') OnDate, Time, NO, VaccineID, Serial, Status, DoseType, Image from ("
                            + " (select SchedID, Time, NO, Status, REG.DoseType, OrgID, OnDate, VaccineID, Serial, Image from("
                                + " (select ID, SchedID, NO, Time, Status, DoseType, Image from REGISTER where CitizenID = :citizenid) REG"
                                + " inner join"
                                + " (select ID, OrgID, OnDate, VaccineID, Serial from SCHEDULE) SCHED"
                                + " on REG.SchedID = SCHED.ID)"
                            + " ) REG_SCHED"
                            + " inner join"
                            + " (select ID, Name, ProvinceName, DistrictName, TownName, Street from ORGANIZATION) ORG"
                            + " on REG_SCHED.OrgID = ORG.ID"
                        + " )"
                        + " where 1 = 1";

            if (status != -1)
                query += " and Status = :status";
            if (vaccine != -1)
                query += " and VaccineID = :vaccine";
            if (time != -1)
                query += " and Time = :time";
            query += " order by Status";

            var command = new OracleCommand(query, conn);
            command.Parameters.Add(new OracleParameter("citizenid", citizen.Id));
            if (status != -1)
                command.Parameters.Add(new OracleParameter("status", status));
            if (vaccine != -1)
                command.Parameters.Add(new OracleParameter("vaccine", vaccine));
            if (time != -1)
                command.Parameters.Add(new OracleParameter("time", time));
            
            string html = "";
            try
            {
                var reader = command.ExecuteReader();

                Register reg = new Register();
                reg.Sched = new Schedule();
                reg.Sched.Org = new Organization();
                reg.Sched.Vaccine = new Vaccine();

                while (reader.Read())
                {
                    reg.Sched.Id = reader["SCHEDID"] as string;
                    reg.Sched.Org.Name = reader["NAME"] as string;
                    reg.Sched.Org.ProvinceName = reader["PROVINCENAME"] as string;
                    reg.Sched.Org.DistrictName = reader["DISTRICTNAME"] as string;
                    reg.Sched.Org.TownName = reader["TOWNNAME"] as string;
                    reg.Sched.Org.Street = reader["STREET"] as string;
                    reg.Sched.OnDate = reader["ONDATE"] as string;
                    reg.Sched.Vaccine.Id = reader["VACCINEID"] as string;
                    reg.Sched.Serial = reader["SERIAL"] as string;
                    reg.Time = reader.GetInt32(reader.GetOrdinal("TIME"));
                    reg.No = reader.GetInt32(reader.GetOrdinal("NO"));
                    reg.Status = reader.GetInt32(reader.GetOrdinal("STATUS"));
                    reg.DoseType = reader["DOSETYPE"] as string;

                    string CancelButton = "";

                    if (reg.Status < 2)
                        CancelButton = "<div class='interactive-area'>"
                            + "<button class='btn-medium-bordered btn-cancel-registration'>Hủy</button>"
                            + "</div>";

                    html +=
                    "<div class='registration' id='" + reg.Sched.Id + "'>"
                    + "<p class='obj-org-name'>" + reg.Sched.Org.Name + "</p>"
                    + "<div class='holder-obj-attr'>"
                        + "<div class='obj-attr'>"
                            + "<p class='attr-address'>Đ/c: "
                            + reg.Sched.Org.ProvinceName + ", "
                            + reg.Sched.Org.DistrictName + ", "
                            + reg.Sched.Org.TownName
                            + "</p>"
                            + "<p class='attr-date-time-no'>Lịch tiêm ngày: " + reg.Sched.OnDate
                            + "&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp Buổi " + reg.Time
                            + "&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp STT: " + reg.No + "</p>"
                            + "<p class='attr-vaccine-serial'>Vaccine: "
                            + reg.Sched.Vaccine.Id + " - " + reg.Sched.Serial
                            + "&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp Trạng thái: " + reg.Status + "</p>"
                        + "</div>"
                        + CancelButton
                    + "</div>"
                + "</div>";
                }
            }
            catch (OracleException e)
            {
                message = e.Message;
                return Content(message, "text/html");
            };

            return Content(html, "text/html");
        }
        
        [HttpPost]
        public IActionResult CancelRegistration(string SchedID)
        {
            string message = "";
            string citizenid = SessionHelper.GetObjectFromJson<Citizen>(HttpContext.Session, "CitizenProfile").Id;
            var conn = new OracleConnection();
            conn.ConnectionString = "User Id=covid19_vaccination_infogate;Password=covid19_vaccination_infogate;Data Source=localhost/orcl";
            conn.Open();

            var command = new OracleCommand("REG_UPDATE_STATUS", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("par_CitizenID", OracleDbType.Varchar2).Value = citizenid;
            command.Parameters.Add("par_SchedID", OracleDbType.Varchar2).Value = SchedID;
            command.Parameters.Add("par_Status", OracleDbType.Int16).Value = 3;
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

            message = "CancelRegistration";
            return Content(message, "text/html");
        }

        [HttpPost]
        public IActionResult LoadOrg(string province, string district, string town)
        {
            string message = "";
            var conn = new OracleConnection();
            conn.ConnectionString = "User Id=covid19_vaccination_infogate;Password=covid19_vaccination_infogate;Data Source=localhost/orcl";
            conn.Open();

            string query = "select ORG.ID as ID, Name, ProvinceName, DistrictName, TownName, Street, COUNT(SCHED.ID) as C"
                            + " from "
                            + " (select * from ORGANIZATION where 1 = 1 ";
            if (province != null)
                query += " and ProvinceName = :province";
            if (district != null)
                query += " and DistrictName = :district";
            if (district != null)
                query += " and TownName = :town";
            query += ") ORG"
            + " inner join"
            + " (select ID, OrgID from SCHEDULE where OnDate > SYSDATE) SCHED"
            + " on ORG.ID = SCHED.OrgID"
            + " group by ORG.ID, Name, ProvinceName, DistrictName, TownName, Street";

            var command = new OracleCommand(query, conn);
            if (province != null)
                command.Parameters.Add(new OracleParameter("province", province));
            if (district != null)
                command.Parameters.Add(new OracleParameter("district", district));
            if (town != null)
                command.Parameters.Add(new OracleParameter("town", town));

            string html = "";
            try
            {
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    html += "<div class='organization object' id='" + reader["ID"] as string + "'>"
                        + "<div class='holder-org'>"
                            + "<p class='obj-org-name'>" + reader["NAME"] + ": " + reader["C"] as string + " lịch</p>"
                            + "<div class='obj-attr'>"
                                + "<p class='attr-location'>K/v: " + reader["PROVINCENAME"] as string + " - " + reader["DISTRICTNAME"] as string + " - " + reader["TOWNNAME"] as string + "</p>"
                                + "<p class='attr-address'>Đ/c: " + reader["STREET"] as string + "</p>"
                            + "</div>"
                        + "</div>"
                        + "<div class='holder-btn-expand-org'>"
                            + "<div class='btn-expand-org'> > </div> "
                       + "</div>"
                   + " </div>";
                }
            }
            catch (OracleException e)
            {
                message = e.Message;
                return Content(message, "text/html");
            }

            return Content(html, "text/html");
        }

        [HttpPost]
        public IActionResult LoadSchedule(string orgid, string startdate, string enddate, string vaccine )
        {
            string message = "";
            var conn = new OracleConnection();
            conn.ConnectionString = "User Id=covid19_vaccination_infogate;Password=covid19_vaccination_infogate;Data Source=localhost/orcl";
            conn.Open();

            string query = "select * from SCHEDULE where OrgID = :id and OnDate >= SYSDATE";

            if (startdate != null)
                query += " and OnDate >= TO_DATE(:startdate, 'YYYY-MM-DD')";
            if (enddate != null)
                query += " and OnDate <= TO_DATE(:enddate, 'YYYY-MM-DD')";
            if (vaccine != null)
                query += " and VaccineID = :vaccine";
            query += " order by OnDate";

            var command = new OracleCommand(query, conn);
            
            command.Parameters.Add(new OracleParameter("id", orgid));
            if (startdate != null)
                command.Parameters.Add(new OracleParameter("startdate", startdate));
            if (enddate != null)
                command.Parameters.Add(new OracleParameter("enddate", enddate));
            if (vaccine != null)
                command.Parameters.Add(new OracleParameter("vaccine", vaccine));

            string html = "";
            try
            {
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    DateTime date = (DateTime)reader["ONDATE"];

                    html +=
                "<div class='schedule object' id='" + reader["ID"] as string + "'>"
                        + "<div class='obj-attr'>"
                            + "<p class='attr-date'>Lịch tiêm ngày: " + date.ToString("yyyy/MM/dd") + "</p>"
                            + "<p class='attr-vaccine'>Vaccine: " + reader["VACCINEID"] as string + "</p>"
                            + "<p class='attr-serial'>Serial: " + reader["SERIAL"] as string + "</p>"
                        + "</div>"
                        + "<div class='obj-attr'>"
                            + "<p class='attr-daytime'>Buổi sáng: " + reader["DAYREGISTERED"] as string + "/" + reader["LIMITDAY"] as string + "</p>"
                            + "<p class='attr-noontime'>Buổi trưa: " + reader["NOONREGISTERED"] as string + "/" + reader["LIMITNOON"] as string + "</p>"
                            + "<p class='attr-nighttime'>Buổi tối: " + reader["NIGHTREGISTERED"] as string + "/" + reader["LIMITNIGHT"] as string + "</p>"
                        + "</div>"
                        + "<div class='interactive-area'>"
                            + "<select class='drop-down-time' name='' id=''>"
                                + "<option value='0'>Sáng</option>"
                                + "<option value='1'>Trưa</option>"
                                + "<option value='2'>Tối</option>"
                           + " </select>"
                            + "<br>"
                            + "<button class='btn-medium-filled btn-register-schedule'>Đăng ký</button>"
                        + "</div>"
                    + "</div>";
                }
            }
            catch (OracleException e)
            {
                message = e.Message;
                return Content(message, "text/html");
            }

            return Content(html, "text/html");
        }

        [HttpPost]
        public IActionResult CheckRegistration()
        {
            string message = "";
            string citizenid = SessionHelper.GetObjectFromJson<Citizen>(HttpContext.Session, "CitizenProfile").Id;
            var conn = new OracleConnection();
            conn.ConnectionString = "User Id=covid19_vaccination_infogate;Password=covid19_vaccination_infogate;Data Source=localhost/orcl";
            conn.Open();

            var command = new OracleCommand("REG_BEFORE_INSERT_RECORD", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("par_CitizenID", OracleDbType.Varchar2).Value = citizenid;
            command.Parameters.Add("par_BoosterAvai", OracleDbType.Int16).Direction = ParameterDirection.Output;
            command.Parameters.Add("par_DoseType", OracleDbType.Varchar2, 50).Direction = ParameterDirection.Output;
            try
            {
                command.ExecuteNonQuery();
                message = command.Parameters["par_BoosterAvai"].Value as string;
            }
            catch (OracleException e)
            {
                message = e.Message;
                return Content(message, "text/html");
            };
            conn.Close();

            message += "CheckRegistration";
            return Content(message, "text/html");
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
        public IActionResult RegisterVaccination(string SchedID, int time, string dosetype)
        {
            string message = "";
            string citizenid = SessionHelper.GetObjectFromJson<Citizen>(HttpContext.Session, "CitizenProfile").Id;
            string citizenFullName = SessionHelper.GetObjectFromJson<Citizen>(HttpContext.Session, "CitizenProfile").FullName();
            string citizenMail = SessionHelper.GetObjectFromJson<Citizen>(HttpContext.Session, "CitizenProfile").Email;

            var conn = new OracleConnection();
            conn.ConnectionString = "User Id=covid19_vaccination_infogate;Password=covid19_vaccination_infogate;Data Source=localhost/orcl";
            conn.Open();

            var command = new OracleCommand("REG_INSERT_RECORD", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("par_CitizenID", OracleDbType.Varchar2).Value = citizenid;
            command.Parameters.Add("par_SchedID", OracleDbType.Varchar2).Value = SchedID;
            command.Parameters.Add("par_Time", OracleDbType.Int16).Value = time;
            command.Parameters.Add("par_DoseType", OracleDbType.Varchar2).Value = dosetype;

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


            string query = "select * from ("
                            + " (select * from ORGANIZATION where ID = :id) ORG"
                            + " join (select OrgID, TO_CHAR(OnDate,'DD/MM/YYYY') as OnDate, VaccineID, Serial from SCHEDULE where ID = :schedid) SCHED"
                            + " on ORG.ID = SCHED.OrgID)";
            conn.Open();
            command = new OracleCommand(query, conn);
            command.Parameters.Add(new OracleParameter("id", SchedID.Substring(0,5)));
            command.Parameters.Add(new OracleParameter("schedid", SchedID));

            Schedule Sched = new Schedule();
            try
            {
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Sched.Org.Id = reader["id"] as string;
                    Sched.Org.Name = reader["name"] as string;
                    Sched.Org.ProvinceName = reader["ProvinceName"] as string;
                    Sched.Org.DistrictName = reader["DistrictName"] as string;
                    Sched.Org.TownName = reader["TownName"] as string;
                    Sched.Org.Street = reader["Street"] as string;
                    Sched.OnDate = reader["OnDate"] as string;
                    Sched.Vaccine.Id = reader["VaccineID"] as string;
                    Sched.Serial = reader["Serial"] as string;
                }
            }
            catch (OracleException e)
            {
                message = e.Message;
                return Content(message, "text/html");
            }
            conn.Close();

            Register reg = new Register();
            reg.Time = time;

            string content = "Gửi " + citizenFullName + ",\n\n"
                            + "Bạn đã thực hiện đăng ký tiêm chủng thành công!\nLịch tiêm của bạn diễn ra vào ngày: " + Sched.OnDate + " - lúc: " + reg.TimeClock() + "\nVaccine: " + Sched.Vaccine.Id + " - Serial: " + Sched.Serial + "\n\n"
                            + "Tại địa điểm " + Sched.Org.Name + " (" 
                            + Sched.Org.ProvinceName + ", " + Sched.Org.DistrictName + ", " + Sched.Org.TownName + ", " 
                            + Sched.Org.Street + ")\n\n"
                            + "Vui lòng đảm bảo các quy tắc phòng chống dịch khi đến nơi thực hiện tiêm chủng!";
            SendEmail(Sched.Org.Name, citizenMail, citizenFullName, "THƯ XÁC NHẬN ĐÃ ĐĂNG KÝ TIÊM CHỦNG", content);

            message = "RegisterVaccination";
            return Content(message, "text/html");
        }

        [HttpPost]
        public IActionResult MedicalList(string formdate)
        {
            string message = "";
            string citizenid = SessionHelper.GetObjectFromJson<Citizen>(HttpContext.Session, "CitizenProfile").Id;
            string citizenFullName = SessionHelper.GetObjectFromJson<Citizen>(HttpContext.Session, "CitizenProfile").FullName();
            var conn = new OracleConnection();
            conn.ConnectionString = "User Id=covid19_vaccination_infogate;Password=covid19_vaccination_infogate;Data Source=localhost/orcl";
            conn.Open();

            string query = "select * from FORM where CitizenID = :citizenid and (to_date(filleddate,'DD-MM-YYYY') > (to_date(CURRENT_DATE,'DD-MM-YYYY') - :formdate)) order by FilledDate desc, ID desc";

            var command = new OracleCommand(query, conn);

            command.Parameters.Add(new OracleParameter("citizenid", citizenid));
            command.Parameters.Add(new OracleParameter("citizenid", formdate));

            string html = "";
            try
            {
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Form form = new Form();
                    DateTime date = (DateTime)reader["FILLEDDATE"];
                    form.FilledDate = date.ToString("yyyy/MM/dd");
                    form.Choice = reader["CHOICE"] as string;
                    form.Id = reader.GetInt32(reader.GetOrdinal("ID"));

                    if (form.Choice == "0000")
                    {
                        html += "<div class='form-medical'>"
                                + "<p class='title'>Đối tượng: " + citizenFullName + " (ID: " + citizenid + ")</p>"
                                + "<p class='date'>Ngày thực hiện khai báo: " + form.FilledDate + "</p>"
                                + "<p class='detail-good'>Sức khỏe bình thường - Đạt điều kiện sức khỏe tiêm chủng</p>"
                                + "</div>";
                    }
                    else
                    {
                        html += "<div class='form-medical'>"
                        + "<p class='title'>Đối tượng: " + citizenFullName + " (ID: " + citizenid + ")</p>"
                        + "<p class='date'>Ngày thực hiện khai báo: " + form.FilledDate + "</p>"
                        + "<p class='detail-bad'>Sức khỏe không tốt/không đảm bảo</p>"
                        + "</div>";
                    }
                }
            }
            catch (OracleException e)
            {
                message = e.Message;
                return Content(message, "text/html");
            }

            return Content(html, "text/html");
        }

        [HttpPost]
        public IActionResult MedicalForm(string filleddate, string choice)
        {
            string message = "";
            string citizenid = SessionHelper.GetObjectFromJson<Citizen>(HttpContext.Session, "CitizenProfile").Id;
            var conn = new OracleConnection();
            conn.ConnectionString = "User Id=covid19_vaccination_infogate;Password=covid19_vaccination_infogate;Data Source=localhost/orcl";
            conn.Open();

            var command = new OracleCommand("FORM_INSERT_RECORD", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("par_CitizenID", OracleDbType.Varchar2).Value = citizenid;
            command.Parameters.Add("par_FilledDate", OracleDbType.Varchar2).Value = filleddate;
            command.Parameters.Add("par_Choice", OracleDbType.Varchar2).Value = choice;
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

            message = "Form Submited!";
            return Content(message, "text/html");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
