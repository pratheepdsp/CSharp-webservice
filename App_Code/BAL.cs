using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;

/// <summary>
/// Summary description for BAL
/// </summary>
public class BAL
{
    private string _atrip;
    private string _afrom;
    private string _ato;
    private string _adepart;
    private string _aarr;
    private string _atime;
    private string _atimes;
    private string _akid;
    private string _aadult;
    private string _aseni;






    public int id { get; set; }

    public string TRIP
    {
        get { return _atrip; }
        set { _atrip = value; }
    }

    public string FROM
    {
        get { return _afrom; }
        set { _afrom = value; }
    }


    

    public string TO
    {
        get { return _ato; }
        set { _ato = value; }
    }

    public string DEPART
    {
        get { return _adepart; }
        set { _adepart = value; }
    }

    public string ARR
    {
        get { return _aarr; }
        set { _aarr = value; }
    }

    public string TIME
    {
        get { return _atime; }
        set { _atime = value; }
    }
    public string TIMES
    {
        get { return _atimes; }
        set { _atimes = value; }
    }

    public string KID
    {
        get { return _akid; }
        set { _akid = value; }
    }

    public string ADULT
    {
        get { return _aadult; }
        set { _aadult = value; }
    }

    public string SENI
    {
        get { return _aseni; }
        set { _aseni = value; }
    }



    public BAL()
    {
    }

    string conStr = ConfigurationManager.ConnectionStrings["DBCon"].ConnectionString;

    public string Insert()
    {
        using (MySqlConnection conn = new MySqlConnection(conStr))
        {
            MySqlCommand sqlcmd = new MySqlCommand("insertb", conn);
            sqlcmd.CommandType = CommandType.StoredProcedure;

            sqlcmd.Parameters.AddWithValue("@p_trip", TRIP);
            sqlcmd.Parameters.AddWithValue("@p_from", FROM);
            sqlcmd.Parameters.AddWithValue("@p_to", TO);
            sqlcmd.Parameters.AddWithValue("@p_depart", DEPART);
            sqlcmd.Parameters.AddWithValue("@p_arr", ARR);
            sqlcmd.Parameters.AddWithValue("@p_time", TIME);
            sqlcmd.Parameters.AddWithValue("@p_times", TIMES);
            sqlcmd.Parameters.AddWithValue("@p_kid", KID);
            sqlcmd.Parameters.AddWithValue("@p_adult", ADULT);
            sqlcmd.Parameters.AddWithValue("@p_senior", SENI);




            conn.Open();
            int count = sqlcmd.ExecuteNonQuery();

            if (count > 0)
                return "PASS";
            else
                return "FAIL";
        }
    }
   

    
    public List<BAL> Select(int id)
    {
        using (MySqlConnection conn = new MySqlConnection(conStr))
        {
            MySqlCommand cmd = new MySqlCommand("Select_p", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@p_id", id);

            conn.Open();
            MySqlDataReader dr = cmd.ExecuteReader();

            List<BAL> lstbal = new List<BAL>();
            while (dr.Read())
            {
                BAL bal = new BAL
                {
                id = Convert.ToInt16(dr["id"]),
                TRIP = dr["trip"].ToString(),
                FROM = dr["fro"].ToString(),
                TO = dr["oto"].ToString(),
                DEPART = dr["depart"].ToString(),
                ARR = dr["arr"].ToString(),
                TIME = dr["time"].ToString(),
                TIMES = dr["times"].ToString(),
                KID = dr["kid"].ToString(),
                ADULT = dr["adult"].ToString(),
               SENI = dr["senior"].ToString()
            };
            lstbal.Add(bal);
        }

        return lstbal;
    }
}
    






    }


      
    







    






    