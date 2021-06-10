using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;

/// <summary>
/// Summary description for WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService
{
    public WebService()
    {
    }

    BAL bal;

    [WebMethod]
    public string InsertEmployee(string atrip, string afrom, string ato, string adepart, string aarr, string atime, string atimes, string akid, string aadult, string aseni)
    {
        Common(atrip, afrom,ato,adepart,aarr,atime,atimes,akid,aadult,aseni);
        string status = bal.Insert();

        if (status == "PASS")
            return "Ticket Booked";
        else
            return "Ticket Not Booked";
    }
   

   

    [WebMethod]
    
    public List<BAL> SelectEmployee(int id)
    {
        bal = new BAL();
        List<BAL> lstbal = bal.Select(id);

        if (lstbal != null)
            return lstbal;
        else
            return lstbal;
    }
    string conStr = ConfigurationManager.ConnectionStrings["DBCon"].ConnectionString;



    [WebMethod]
    public List<BAL> AllEmployeee()
    {
        using (MySqlConnection conn = new MySqlConnection(conStr))
        {
            MySqlCommand cmd = new MySqlCommand("allrecord", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataAdapter da = new MySqlDataAdapter();
            DataTable dt = new DataTable();
            da.SelectCommand = cmd;
            da.Fill(dt);
            List<BAL> Employee = new List<BAL>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    BAL empObj = new BAL();
                    empObj.id = Convert.ToInt16(dr["Id"]);
                    empObj.TRIP = dr["trip"].ToString();
                    empObj.FROM= dr["fro"].ToString();
                    empObj.TO = dr["oto"].ToString();
                    empObj.DEPART = dr["depart"].ToString();
                    empObj.ARR= dr["arr"].ToString();
                    empObj.TIME = dr["time"].ToString();
                    empObj.TIMES = dr["times"].ToString();
                    empObj.KID = dr["kid"].ToString();
                    empObj.ADULT = dr["adult"].ToString();
                    empObj.SENI = dr["senior"].ToString();
                    Employee.Add(empObj);

                }
            }
            return Employee;








        }
    }




    private void Common(string atrip, string afrom, string ato, string adepart, string aarr, string atime, string atimes, string akid, string aadult, string aseni)
    {
        bal = new BAL
        {
            TRIP = atrip,
            FROM = afrom,
            TO = ato,
             
            DEPART  = adepart,
            ARR = aarr,
            TIME = atime,
            TIMES = atimes,
            KID = akid,
            ADULT = aadult,
            SENI = aseni
        };
    }




}
