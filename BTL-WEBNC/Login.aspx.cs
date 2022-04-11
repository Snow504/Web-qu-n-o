using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace BTL_WEBNC
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {

                string user = Request.Form["txtUsername"];
                string pass = Request.Form["txtPassword"];
                if(Check_Username(user, pass))
                {
                    Session["Username"] = user;
                    Response.Redirect("Index.aspx?sUsername="+user);
                }
                else {
                    Response.Write("<script>alert('Thông tin không đúng')</script>");

                }


            }
        }
        //KIỂM TRA TÀI KHOẢN: nếu tồn tại trả giá trị true, ngược lại false
        protected bool Check_Username(String username, String password)
        {
            string conn = ConfigurationManager.ConnectionStrings["ql"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(conn))
            {
                using (SqlCommand cmd = new SqlCommand("Select * from tblUsername where sUsername= '" + username+ "' and sPassword= '" + password+ "'", cnn))
                {
                    cnn.Open();
                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        if (rd.HasRows)
                        {
                            rd.Close();
                            cnn.Close();
                            return true;
                        } else {
                            rd.Close();
                            cnn.Close();
                            return false;
                        }
                    }
                }
            }
        }
    }
}