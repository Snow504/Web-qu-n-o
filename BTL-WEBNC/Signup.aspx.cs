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
    public partial class Signup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                string user = Request.Form["txtUsername"];
                string pass = Request.Form["txtPassword"];
                if (Check_Username(user))
                {
                    // Tài khoản đã tồn tại và gửi thông báo
                    Response.Write("<script>alert('Tài khoản: " + user + " đã tồn tại')</script>");
                }
                else// ngược lại tài khoản chưa tồn tại. Thêm dữ liệu vào
                {
                    string conn = ConfigurationManager.ConnectionStrings["ql"].ConnectionString;
                    SqlConnection con = new SqlConnection(conn);
                    SqlCommand cmd = con.CreateCommand();
                    try
                    {
                        cmd.CommandText = "pr_InsertUsername";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@user", user);
                        cmd.Parameters.AddWithValue("@pass", pass);
                        con.Open();
                        int i = cmd.ExecuteNonQuery();
                        if (i == 0)
                            Response.Write("<script>alert('Tài khoản: " + user + " đăng ký thất bại')</script>");
                        else
                            Response.Write("<script>alert('Tài khoản: " + user + " đăng ký thành công')</script>");
                        con.Close();
                        

                    }
                    catch { }


                }
            }
        }
        //KIỂM TRA TÀI KHOẢN: nếu tồn tại trả giá trị true, ngược lại false
        protected bool Check_Username(String username)
        {
            string conn = ConfigurationManager.ConnectionStrings["ql"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(conn))
            {
                using (SqlCommand cmd = new SqlCommand("Select * from tblUsername where sUsername= '" + username + "'" , cnn))
                {
                    cnn.Open();
                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        if (rd.HasRows)
                        {
                            rd.Close();
                            cnn.Close();
                            return true;
                        }
                        else
                        {
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