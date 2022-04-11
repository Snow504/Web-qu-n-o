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
    public partial class Child_page : System.Web.UI.Page
    {
        static int CurrentPage;
        protected void Page_Load(object sender, EventArgs e)
        {
                if (Request.QueryString["type"] != null)
                {
                    BindList();
                }
                else
                {
                    Response.Write("alert('Lỗi')");
                }
        }
        void BindList()
        {
            PagedDataSource objPage = new PagedDataSource();
            try
            {
                DataTable dt = new DataTable();
                string conn_str = ConfigurationManager.ConnectionStrings["ql"].ConnectionString;
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM tblProduct where sType= '" + Request.QueryString["type"] + "'", conn_str);
                da.Fill(dt);
                objPage.DataSource = dt.DefaultView;
                objPage.AllowPaging = true;
                objPage.PageSize = 9;
                objPage.CurrentPageIndex = CurrentPage;
                btnNext.Enabled = !objPage.IsLastPage;
                btnPre.Enabled = !objPage.IsFirstPage;
                databaseindex.DataSource = objPage;
                databaseindex.DataBind();
                // TotalRecord = dts.Tables[0].Rows.Count;            
            }
            catch (Exception)
            {
            }
            finally
            {
                objPage = null;
            }
        }

        protected void btnPre_Click(object sender, EventArgs e)
        {
            CurrentPage -= 1;
            BindList();
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            CurrentPage += 1;
            BindList();
        }
    }
}