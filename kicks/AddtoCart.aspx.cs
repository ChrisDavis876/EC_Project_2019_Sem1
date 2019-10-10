using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace kicks
{
    public partial class AddtoCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                DataTable dt = new DataTable();
                DataRow dr;
                dt.Columns.Add("sno");
                dt.Columns.Add("PId");
                dt.Columns.Add("pName");
                dt.Columns.Add("pImage");
                dt.Columns.Add("pPrice");
                dt.Columns.Add("cost");
                dt.Columns.Add("totalcost");
                

                if (Request.QueryString["PId"] != null)
                {
                    if (Session["Buyitems"] == null)
                    {
                       
                        dr = dt.NewRow();
                        String mycon = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Shoes.mdf;Integrated Security=True";
                        SqlConnection scon = new SqlConnection(mycon);
                        String myquery = "select * from warehouse where PId=" + Request.QueryString["PId"];
                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandText = myquery;
                        cmd.Connection = scon;
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        dr["sno"] = 1;
                        dr["PId"] = ds.Tables[0].Rows[0]["PId"].ToString();
                        dr["pName"] = ds.Tables[0].Rows[0]["pName"].ToString();
                        dr["pImage"] = ds.Tables[0].Rows[0]["pImage"].ToString();
                        dr["pPrice"] = ds.Tables[0].Rows[0]["pPrice"].ToString();
                        dt.Rows.Add(dr);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        Session["buyitems"] = dt;
                    }
                    else
                    {

                        dt = (DataTable)Session["buyitems"];
                        int sr;
                        sr = dt.Rows.Count;

                        dr = dt.NewRow();
                        String mycon = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Shoes.mdf;Integrated Security=True";
                        SqlConnection scon = new SqlConnection(mycon);
                        String myquery = "select * from warehouse where PId=" + Request.QueryString["PId"];
                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandText = myquery;
                        cmd.Connection = scon;
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        dr["sno"] = sr + 1;
                        dr["PId"] = ds.Tables[0].Rows[0]["PId"].ToString();
                        dr["pName"] = ds.Tables[0].Rows[0]["pName"].ToString();
                        dr["pImage"] = ds.Tables[0].Rows[0]["pImage"].ToString();
                        dr["pPrice"] = ds.Tables[0].Rows[0]["pPrice"].ToString();
                        dt.Rows.Add(dr);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        Session["buyitems"] = dt;

                    }
                }
                else
                {
                    dt = (DataTable)Session["buyitems"];
                    GridView1.DataSource = dt;
                    GridView1.DataBind();

                }

            }
        }

      
    }
}