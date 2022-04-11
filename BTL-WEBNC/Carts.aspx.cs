using BTL_WEBNC.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTL_WEBNC
{
    public partial class Carts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                hiengiohang();

        }
        private void hiengiohang()
        {
            float totalprice = 0;
            List<Cart> arr = (List<Cart>)Application["cart"];
            foreach (Cart sp in arr)
            {
                totalprice += sp.figure *sp.price;

            }
            DsGioHang.DataSource = arr;
            DsGioHang.DataBind();
            TotalProduct.Text = arr.Count.ToString();
            TotalPriceProduct.Text = totalprice.ToString();


        }
        protected void Unnamed_Command(object sender, CommandEventArgs e)
        {
            int id = Int32.Parse(e.CommandArgument.ToString());

            List<Cart> arr = (List<Cart>)Application["cart"];
            Cart giohang = new Cart();
            foreach (Cart sp in arr)
            {
                if (sp.id == id)
                {
                    arr.Remove(sp);
                    Session["Giohang"] = Int32.Parse(Session["Giohang"].ToString()) - 1;

                    break;

                }
            }
            hiengiohang();
        }
        protected float showTT(object a, object b)
        {
            return Int32.Parse(a.ToString()) * float.Parse(b.ToString());
        }
        /*
        protected void HienTB_Click(object sender, EventArgs e)
        {
            /*string xml = "Bạn đã thanh toán";
            Response.Write(xml);
            Response.Write("<script languague='javascript'> alert('Bạn đã thanh toán thành công !');</script>");
        }



        /*protected void btnRemove_Click(object sender, EventArgs e)
        {
            string id = ((Button)sender).CommandArgument.ToString();
            List<DsSanPham> arr = (List<DsSanPham>)Application["giohang"];
            foreach (DsSanPham sp in arr)
            {
                if (sp.id == id)
                {
                    arr.Remove(sp);
                    break;

                }
            }
            Application["giohang"] = arr;
            DsGioHang.DataSource = arr;
            DsGioHang.DataBind();
            TotalProduct.Text = arr.Count.ToString();
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }
        
        public void updateSL()
        {

        }*/
    }
}