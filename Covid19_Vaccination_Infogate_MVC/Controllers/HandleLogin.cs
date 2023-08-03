using Oracle.ManagedDataAccess.Client;
using System.Net.Http;
using System.Web;

public partial class _Default: System.Net.WebRequest
{
    [HttpPost]
    public ActionResult Login()
    {
        var conn = new OracleConnection();
        conn.ConnectionString = "User Id=covid19_vaccination_infogate;Password=covid19_vaccination_infogate;Data Source=orcl";
        conn.Open();

        if (conn.State == System.Data.ConnectionState.Open)
        {
            string query = "select * from ACCOUNT where Username = :username";
            var command = new OracleCommand(query, conn);
            command.Parameters.Add(new OracleParameter("userName", "0332743065"));
            var reader = command.ExecuteReader();
        }
        else
            return "Connection Fail!";
        conn.Close();

        return "Login";
    }
}