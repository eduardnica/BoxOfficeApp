using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BoxOfficeApp
{
    public partial class GridView : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection con;
        SqlDataAdapter adapt;
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowData();
            }
        }

        protected void ShowData()
        {
            dt = new DataTable();
            con = new SqlConnection(cs);
            con.Open();
            adapt = new SqlDataAdapter("Select IdMovie,Title,ReleaseDate, url, imageURL from Movies", con);
            adapt.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            con.Close();
        }

        protected void GridView1EditRow(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            ShowData();
        }
        protected void GridView1UpdateRow(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {

            Label id = GridView1.Rows[e.RowIndex].FindControl("lbl_ID") as Label;
            TextBox title = GridView1.Rows[e.RowIndex].FindControl("txt_Title") as TextBox;
            TextBox releaseDate = GridView1.Rows[e.RowIndex].FindControl("txt_releaseDate") as TextBox;
            TextBox url = GridView1.Rows[e.RowIndex].FindControl("txt_url") as TextBox;
            TextBox imageURL = GridView1.Rows[e.RowIndex].FindControl("txt_imageURl") as TextBox;
            con = new SqlConnection(cs);
            con.Open();
            //updating the record
            SqlCommand cmd = new SqlCommand("Update Movies set Title='" + title.Text + "',releaseDate='" + releaseDate.Text + "',url='" + url.Text + "',imageURL='" + imageURL.Text + "' where IdMovie=" + Convert.ToInt32(id.Text), con);
            cmd.ExecuteNonQuery();
            con.Close();
            //cancel
            GridView1.EditIndex = -1;
            ShowData();
        }
        protected void GridView1CancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {

            GridView1.EditIndex = -1;
            ShowData();
        }
    }
}