using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTL_WEBNC
{
    public partial class Home : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string conn_str = ConfigurationManager.ConnectionStrings["ql"].ConnectionString;
            string query = "SELECT TOP(3) iID ,sName,sNSX,sImage,sType,fPrice,iSLnhap,iSLton,sInfor, iSLnhap-iSLton AS TopSale FROM tblProduct ORDER BY TopSale DESC";
            SqlDataAdapter da = new SqlDataAdapter(query, conn_str);
            DataSet ds = new DataSet();
            da.Fill(ds, "Products");
            DataList1.DataSource = ds.Tables["Products"];
            DataList1.DataBind();
            lbUsername.Text = "Tài khoản: " + Session["Username"];
            txtGiohang.Text = "GIỎ HÀNG"+"("+Session["Giohang"]+")";
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");

        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Index.aspx?Search=" + txtSearch.Text);
        }
    }
}