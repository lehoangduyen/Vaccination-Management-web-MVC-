using Covid19_Vaccination_Infogate_MVC.Models;
using Covid19_Vaccination_Infogate_MVC.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Reflection;
using System.Web.Helpers;
using System.Reflection.PortableExecutable;
using System.Web.WebPages;
using System.IO;
using System.Xml.Linq;
using Microsoft.AspNetCore.Http;

namespace Covid19_Vaccination_Infogate_MVC.Controllers
{
    public class ORGController : Controller
    {
        private readonly ILogger<ORGController> _logger;

        public ORGController(ILogger<ORGController> logger)
        {
            _logger = logger;
        }

        public void LoadORGProfile()
        {
            Organization org = new Organization();
            Account account = SessionHelper.GetObjectFromJson<Account>(HttpContext.Session, "AccountInfo");

            SessionHelper.GetObjectFromJson<Account>(HttpContext.Session, "AccountInfo");
            var conn = new OracleConnection();
            conn.ConnectionString = "User Id=covid19_vaccination_infogate;Password=covid19_vaccination_infogate;Data Source=localhost/orcl";
            conn.Open();

            string query = "select * from Organization where ID = :username";
            var command = new OracleCommand(query, conn);
            command.Parameters.Add(new OracleParameter("userName", account.Username));
            var reader = command.ExecuteReader();

            if (reader.HasRows == false)
                return;

            while (reader.Read())
            {
                org.Id = reader["ID"] as string;
                org.Name = reader["NAME"] as string;
                org.ProvinceName = reader["PROVINCENAME"] as string;
                org.DistrictName = reader["DISTRICTNAME"] as string;
                org.TownName = reader["TOWNNAME"] as string;
                org.Street = reader["STREET"] as string;
            }
            SessionHelper.SetObjectAsJson(HttpContext.Session, "ORGProfile", org);

            return;
        }

        public IActionResult Index()
        {
            Account account = SessionHelper.GetObjectFromJson<Account>(HttpContext.Session, "AccountInfo");
            if (account != null && account.Role < 2)
            {
                if (SessionHelper.GetObjectFromJson<Organization>(HttpContext.Session, "ORGProfile") == null)
                    LoadORGProfile();
                return View();
            }
            else
            {
                Response.Redirect("/Home");
                return Json(new { message = "Redirected to /Home" });
            }
            return Profile();
        }
        
        public IActionResult AccountInfo()
        {
            Account account = SessionHelper.GetObjectFromJson<Account>(HttpContext.Session, "AccountInfo");
            if (account != null && account.Role < 2)
            {
                if (SessionHelper.GetObjectFromJson<Organization>(HttpContext.Session, "ORGProfile") == null)
                    LoadORGProfile();
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
            if (account != null && account.Role < 2)
            {
                if (SessionHelper.GetObjectFromJson<Organization>(HttpContext.Session, "ORGProfile") == null)
                    LoadORGProfile();
                return View();
            }
            else
            {
                Response.Redirect("/Home");
                return Json(new { message = "Redirected to /Home" });
            }
        }

        public IActionResult Schedule()
        {
            Account account = SessionHelper.GetObjectFromJson<Account>(HttpContext.Session, "AccountInfo");
            if (account != null && account.Role == 1)
            {
                if (SessionHelper.GetObjectFromJson<Organization>(HttpContext.Session, "ORGProfile") == null)
                    LoadORGProfile();
                return View();
            }
            else
            {
                Response.Redirect("/Home");
                return Json(new { message = "Redirected to /Home" });
            }
        }
        public IActionResult CreateSchedule()
        {
            Account account = SessionHelper.GetObjectFromJson<Account>(HttpContext.Session, "AccountInfo");
            if (account != null && account.Role == 1)
            {
                if (SessionHelper.GetObjectFromJson<Organization>(HttpContext.Session, "ORGProfile") == null)
                    LoadORGProfile();
                return View();
            }
            else
            {
                Response.Redirect("/Home");
                return Json(new { message = "Redirected to /Home" });
            }
        }
        public IActionResult Document()
        {
            Account account = SessionHelper.GetObjectFromJson<Account>(HttpContext.Session, "AccountInfo");
            if (account != null && account.Role < 2)
            {
                if (SessionHelper.GetObjectFromJson<Organization>(HttpContext.Session, "ORGProfile") == null)
                    LoadORGProfile();
                return View();
            }
            else
            {
                Response.Redirect("/Home");
                return Json(new { message = "Redirected to /Home" });
            }
        }

       /* public IActionResult Statistic()
        {
            Account account = SessionHelper.GetObjectFromJson<Account>(HttpContext.Session, "AccountInfo");
            if (account != null && account.Role < 2)
            {
                if (SessionHelper.GetObjectFromJson<Organization>(HttpContext.Session, "ORGProfile") == null)
                    LoadORGProfile();
                return View();
            }
            else
            {
                Response.Redirect("/Home");
                return Json(new { message = "Redirected to /Home" });
            }
        }*/

        [HttpPost]
        public IActionResult CreateSchedule(string orgid, string date, string vaccine, string serial, int limitday, int limitnoon, int limitnight)
        {
            string message = "";
            Account account = SessionHelper.GetObjectFromJson<Account>(HttpContext.Session, "AccountInfo");
            var conn = new OracleConnection();
            conn.ConnectionString = "User Id=covid19_vaccination_infogate;Password=covid19_vaccination_infogate;Data Source=localhost/orcl";
            conn.Open();

            var command = new OracleCommand("SCHED_INSERT_RECORD", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("par_OrgID", OracleDbType.Varchar2).Value = orgid;
            command.Parameters.Add("par_OnDate", OracleDbType.Varchar2).Value = date;
            command.Parameters.Add("par_VaccineID", OracleDbType.Varchar2).Value = vaccine;
            command.Parameters.Add("par_Serial", OracleDbType.Varchar2).Value = serial;
            command.Parameters.Add("par_LimitDay", OracleDbType.Int16).Value = limitday;
            command.Parameters.Add("par_LimitNoon", OracleDbType.Int16).Value = limitnoon;
            command.Parameters.Add("par_LimitNight", OracleDbType.Int16).Value = limitnight;
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

            message = "CreateSchedule";
            return Content(message, "text/html");
        }

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

            return Content(message, "text/htmlm");
        }

        [HttpPost]
        public IActionResult UpdateOrgProfile(string name, string district, string town, string street)
        {
            string message = "";
            var conn = new OracleConnection();
            conn.ConnectionString = "User Id=covid19_vaccination_infogate;Password=covid19_vaccination_infogate;Data Source=localhost/orcl";

            Organization org = SessionHelper.GetObjectFromJson<Organization>(HttpContext.Session, "ORGProfile");
            conn.Open();
            var command = new OracleCommand("ORG_UPDATE_RECORD", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("par_ID", OracleDbType.Varchar2).Value = org.Id;
            command.Parameters.Add("par_Name", OracleDbType.Varchar2).Value = name;
            command.Parameters.Add("par_DistrictName", OracleDbType.Varchar2).Value = district;
            command.Parameters.Add("par_TownName", OracleDbType.Varchar2).Value = town;
            command.Parameters.Add("par_Street", OracleDbType.Varchar2).Value = street;
            try
            {
                command.ExecuteNonQuery();
            }
            catch (OracleException e)
            {
                message = e.Message;
            };
            conn.Close();

            message += "UpdateProfile";

            org.Name = name;
            org.DistrictName = district;
            org.TownName = town;
            org.Street = street;

            SessionHelper.SetObjectAsJson(HttpContext.Session, "ORGProfile", org);

            return Content(message, "text/html");
        }

        [HttpPost]
        public IActionResult LoadSchedule(string startdate, string enddate, string vaccine)
        {
            string message = "";
            var conn = new OracleConnection();
            conn.ConnectionString = "User Id=covid19_vaccination_infogate;Password=covid19_vaccination_infogate;Data Source=localhost/orcl";
            conn.Open();
            string orgid = SessionHelper.GetObjectFromJson<Organization>(HttpContext.Session, "ORGProfile").Id;

            string query = "select * from SCHEDULE where OrgID = :id";

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
                    string CancelButton = "";
                    if (date > DateTime.Now)
                        CancelButton = "<button class='btn-short-bordered btn-cancel'>Hủy</button>";

                    html += "<div class='schedule object' id='" + reader["ID"] + "'>"
                            + "<div class='holder-schedule'>"
                            + "<div class='obj-attr'>"
                                + "<p class='attr-date-vaccine-serial'>Ngày tiêm: " + date.ToString("yyyy/MM/dd") + " - Vaccine:"
                                + reader["VACCINEID"] + " - " + reader["SERIAL"] + "</p>"
                                + "<div class='attr-time'>"
                                    + "<p>Buổi sáng: " + reader["DAYREGISTERED"] + "/</p><p class='day' id='" + reader["LIMITDAY"] + "'>" + reader["LIMITDAY"] + "</p>"
                                    + "<p>&nbsp- Buổi trưa: " + reader["NOONREGISTERED"] + "/</p><p class='noon' id='" + reader["LIMITNOON"] + "'>" + reader["LIMITNOON"] + "</p>"
                                    + "<p>&nbsp- Buổi tối: " + reader["NIGHTREGISTERED"] + "/</p><p class='night' id='" + reader["LIMITNIGHT"] + "'>" + reader["LIMITNIGHT"] + "</p>"
                                    + "</div>"
                                + "</div>"
                                + "<div class='interactive-area'>"
                                    + "<button class='btn-medium-filled btn-registration'>Lượt đăng ký</button>"
                                    + "<button class='btn-medium-bordered btn-update'>Cập nhật</button>"
                                    + CancelButton
                                + "</div>"
                            + "</div>"
                            + "<div class='holder-btn-expand-schedule'>"
                                + "<div class='btn-expand-schedule'> > </div>"
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
        public IActionResult LoadScheduleRegistration(string SchedID, string date, int time, int status)
        {
            string message = "";
            var conn = new OracleConnection();
            conn.ConnectionString = "User Id=covid19_vaccination_infogate;Password=covid19_vaccination_infogate;Data Source=localhost/orcl";
            conn.Open();

            string query = "select LastName, FirstName, Gender, BirthYear, ID, Phone, Time, NO, Status, Image from ("
                        + " (select Time, NO, Status, Image, CitizenID from REGISTER where SchedID = :schedid and Status < 3) REG"
                        + " inner join"
                        + " (select LastName, FirstName, Gender, EXTRACT(year from Birthday) as BirthYear, ID, Phone from CITIZEN) CITIZEN"
                        + " on REG.CitizenID = CITIZEN.ID"
                        + " )"
                        + " where 1=1"; ;

            if (time != null)
                query += " and Time =:time";
            if (status != null)
                query += " and Status =:statu";
           
            query += " order by Time, NO";

            var command = new OracleCommand(query, conn);

            command.Parameters.Add(new OracleParameter("id", SchedID));
            if (time != null)
                command.Parameters.Add(new OracleParameter("startdate", time));
            if (status != null)
                command.Parameters.Add(new OracleParameter("enddate", status));

            string html = "";
            try
            {
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Register reg = new Register();
                    reg.Citizen.LastName = reader["LASTNAME"] as string;
                    reg.Citizen.FirstName = reader["FIRSTNAME"] as string;
                    reg.Citizen.Gender(reader.GetInt32(reader.GetOrdinal("GENDER")));
                    reg.Citizen.Birthday = reader["BIRTHYEAR"] as string;
                    reg.Citizen.Id = reader["ID"] as string;
                    reg.Citizen.Phone = reader["PHONE"] as string;
                    reg.Time = reader.GetInt32(reader.GetOrdinal("TIME"));
                    reg.No = reader.GetInt32(reader.GetOrdinal("NO"));
                    reg.Status = reader.GetInt32(reader.GetOrdinal("STATUS"));

                    string interaction = "";
                    if (reg.Status < 2)
                    {
                        interaction += "<select class='select-status' name=''>";
                        if (reg.Status == 0)
                            interaction += "<option value='1'>Điểm danh</option><option value='3'>Đã hủy</option>";
                        else
                            interaction += "<option value='2'>Đã tiêm</option><option value='3'>Đã hủy</option>";
                        interaction += "</select><br><button class='btn-medium-filled btn-update-registration'>Cập nhật</button>";
                    }

                    html += "<div class='registration' id='" + SchedID + "'>"
                            + "<p class='obj-name' id='" + reg.Citizen.Id + "'>" + reg.Citizen.FullName() + " - " + reg.Citizen.Gender() + " - " + reg.Citizen.Birthday + " (ID:" + reg.Citizen.Id + ")</p>"
                            + "<div class='hoder-obj-attr'>"
                                + "<div class='obj-attr'>"
                                    + "<p class='attr-sdt'>SĐT: " + reg.Citizen.Phone + "</p>"
                                    + "<div class='attr-detail'>"
                                        + "<p>Buổi: " + reg.Time + "</p>"
                                        + "<p>STT: " + reg.No + "</p>"
                                        + "<p>Tình trạng: " + reg.Status + " </p>"
                                    + "</div>"
                                + "</div>"
                                + "<div class='interactive-area'>"
                                    + interaction
                                + "</div>"
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
        public IActionResult UpdateRegistrationStatus(string citizenid, string SchedID, string status)
        {
            string message = "";
            var conn = new OracleConnection();
            conn.ConnectionString = "User Id=covid19_vaccination_infogate;Password=covid19_vaccination_infogate;Data Source=localhost/orcl";

            conn.Open();
            var command = new OracleCommand("REG_UPDATE_STATUS", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("par_CitizenID", OracleDbType.Varchar2).Value = citizenid;
            command.Parameters.Add("par_SchedID", OracleDbType.Varchar2).Value = SchedID;
            command.Parameters.Add("par_Status", OracleDbType.Varchar2).Value = status;
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

            message += status;

            return Content(message, "text/html");
        }

        [HttpPost]
        public IActionResult SelectScheduleValue(string SchedID)
        {
            string message = "";
            var conn = new OracleConnection();
            conn.ConnectionString = "User Id=covid19_vaccination_infogate;Password=covid19_vaccination_infogate;Data Source=localhost/orcl";
            conn.Open();

            string query = "select LimitDay, LimitNoon, LimitNight from SCHEDULE where ID = :id";
            var command = new OracleCommand(query, conn);
            command.Parameters.Add(new OracleParameter("id", SchedID));
            try
            {
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    HttpContext.Session.SetInt32("limitday", reader.GetInt32(reader.GetOrdinal("LIMITDAY")));
                    HttpContext.Session.SetInt32("limitnoon", reader.GetInt32(reader.GetOrdinal("LIMITNOON")));
                    HttpContext.Session.SetInt32("limitnight", reader.GetInt32(reader.GetOrdinal("LIMITNIGHT")));
                }
            }
            catch(OracleException e)
            {
                message = e.Message;
                return Content(message, "text/html");
            }
            conn.Close();

            return Content(message, "text/html");
        }

        [HttpPost]
        public IActionResult UpdateSchedule(string SchedID, int? limitday, int? limitnoon, int? limitnight)
        {
            string message = "";
            var conn = new OracleConnection();
            conn.ConnectionString = "User Id=covid19_vaccination_infogate;Password=covid19_vaccination_infogate;Data Source=localhost/orcl";
            conn.Open();

            if (limitday == -1)
                limitday = HttpContext.Session.GetInt32("limitday");
            if (limitnoon == -1)
                limitnoon = HttpContext.Session.GetInt32("limitnoon"); 
            if (limitnight == -1)
                limitnight = HttpContext.Session.GetInt32("limitnight");
            HttpContext.Session.Remove("limitday");
            HttpContext.Session.Remove("limitnoon");
            HttpContext.Session.Remove("limitnight");

            var command = new OracleCommand("SCHED_UPDATE_RECORD", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("par_ID", OracleDbType.Varchar2).Value = SchedID;
            command.Parameters.Add("par_LimitDay", OracleDbType.Int16).Value = limitday;
            command.Parameters.Add("par_LimitNoon", OracleDbType.Int16).Value = limitnoon;
            command.Parameters.Add("par_LimitNight", OracleDbType.Int16).Value = limitnight;
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

            message += "UpdateSchedule";

            return Content(message, "text/html");
        }

        [HttpPost]
        public IActionResult CancelSchedule(string SchedID)
        {
            string message = "";
            var conn = new OracleConnection();
            conn.ConnectionString = "User Id=covid19_vaccination_infogate;Password=covid19_vaccination_infogate;Data Source=localhost/orcl";
            conn.Open();

            var command = new OracleCommand("SCHED_CANCEL_SCHED", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("par_ID", OracleDbType.Varchar2).Value = SchedID;
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

            message += "CancelSchedule";

            return Content(message, "text/html");
        }

        
        /*MOH method*/
        public IActionResult ManageOrg()
        {
            Account account = SessionHelper.GetObjectFromJson<Account>(HttpContext.Session, "AccountInfo");
            if (account != null && account.Role == 0)
            {
                if (SessionHelper.GetObjectFromJson<Organization>(HttpContext.Session, "ORGProfile") == null)
                    LoadORGProfile();
                return View();
            }
            else
            {
                Response.Redirect("/Home");
                return Json(new { message = "Redirected to /Home" });
            }
        }
        public IActionResult ProvideOrgAcc()
        {
            Account account = SessionHelper.GetObjectFromJson<Account>(HttpContext.Session, "AccountInfo");
            if (account != null && account.Role == 0)
            {
                if (SessionHelper.GetObjectFromJson<Organization>(HttpContext.Session, "ORGProfile") == null)
                    LoadORGProfile();
                return View();
            }
            else
            {
                Response.Redirect("/Home");
                return Json(new { message = "Redirected to /Home" });
            }
        }

        [HttpPost]
        public IActionResult LoadOrg(string province, string district, string town)
        {
            string message = "";
            var conn = new OracleConnection();
            conn.ConnectionString = "User Id=covid19_vaccination_infogate;Password=covid19_vaccination_infogate;Data Source=localhost/orcl";
            conn.Open();

            string query = "select * from ORGANIZATION where 1=1 ";
            if (province != null)
                query += " and ProvinceName = :province";
            if (district != null)
                query += " and DistrictName = :district";
            if (district != null)
                query += " and TownName = :town";

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
                    html += "<div class='organization' id='" + reader["ID"] as string + "'>"
                            + "<p class='obj-org-name'>" + reader["NAME"] as string + "</p>"
                            + "<div class='holder-obj-attr'>"
                                + "<div class='obj-attr'>"
                                    + "<p class='id-org'>ID: " + reader["ID"] as string + "</p>"
                                    + "<p class='attr-location'>K/v: " + reader["PROVINCENAME"] as string + " - " + reader["DISTRICTNAME"] as string + " - " + reader["TOWNNAME"] as string + "</p>"
                                    + "<p class='attr-address'>Đ/c: " + reader["STREET"] as string + "</p>"
                                + "</div>"
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
        public IActionResult ProvideAccount(int quantity, string code, string province)
        {

            string message = "";
            var conn = new OracleConnection();
            conn.ConnectionString = "User Id=covid19_vaccination_infogate;Password=covid19_vaccination_infogate;Data Source=localhost/orcl";
            conn.Open();

            var command = new OracleCommand("ACC_CREATE_ORG", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("par_Quantity", OracleDbType.Int32).Value = quantity;
            command.Parameters.Add("par_ProvinceCode", OracleDbType.Varchar2).Value = code;
            command.Parameters.Add("par_ProvinceName", OracleDbType.Varchar2).Value = province;
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

            message += "ProvideAccount";

            return Content(message, "text/html");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
