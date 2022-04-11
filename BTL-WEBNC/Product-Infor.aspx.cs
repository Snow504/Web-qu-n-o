using BTL_WEBNC.Object;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTL_WEBNC
{
    public partial class Product_Infor : System.Web.UI.Page
    {
        static float price;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] == null)
            {
                Response.Redirect("Index.aspx", true);

            }
            else
            {
                string iId = Request.QueryString["id"];
                string conn = ConfigurationManager.ConnectionStrings["ql"].ConnectionString;
                using (SqlConnection cnn = new SqlConnection(conn))
                {
                    using (SqlCommand cmd = new SqlCommand("Select * from tblProduct where iID= " + iId, cnn))
                    {
                        cnn.Open();
                        using (DbDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {

                                while (reader.Read())
                                {
                                    img.ImageUrl = reader["sImage"].ToString();
                                    lblName.Text = reader["sName"].ToString();
                                    lblFeature.Text = reader["sInfor"].ToString();
                                    lblPrice.Text = reader["fPrice"].ToString();
                                    price=Int32.Parse(reader["fPrice"].ToString());
                                }
                            }
                        }
                    }
                }
            }
        }

        protected void btnCart_Click(object sender, EventArgs e)
        {
            List<Cart> arrCart = (List<Cart>)Application["cart"];
            Cart cart = new Cart();
            cart.id = Int32.Parse(Request.QueryString["id"]);
            cart.img = img.ImageUrl;
            cart.name = lblName.Text;
            cart.detail = lblFeature.Text;
            cart.price = float.Parse(lblPrice.Text);
          
            cart.figure = Int32.Parse(txtfigure.Text);
            arrCart.Add(cart);
            Application["cart"] = arrCart;
            Session["Giohang"] = Int32.Parse(Session["Giohang"].ToString()) + 1;
            Response.Redirect("Carts.aspx");
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }
    }
}