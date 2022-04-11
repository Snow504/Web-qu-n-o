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
    public partial class Index : System.Web.UI.Page
    {
        static int CurrentPage;
        DataTable dt = new DataTable();
        DataTable datasearch;
        static DataView View;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { 
                datasearch  =new DataTable();
                BindList();
                View = new DataView(dt);

                if (Request.QueryString["Search"] != null)
                {
                    CurrentPage = 0;
                    View.RowFilter = "sName LIKE '%" + (Request.QueryString["Search"]).ToString().ToUpper() + "%'";
                    SearchList(View);
                }
            }

        }
        void BindList()
        {
            PagedDataSource objPage = new PagedDataSource();
            try
            {

                string conn_str = ConfigurationManager.ConnectionStrings["ql"].ConnectionString;
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM tblProduct", conn_str);
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
            if (Request.QueryString["Search"] != null)
            {
                SearchList(View);
            }
            else
                BindList();
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            CurrentPage += 1;
            if (Request.QueryString["Search"] != null)
            {
                SearchList(View);
            }
            else
                BindList();
        }
        protected void SearchList(DataView View)
        {
            datasearch = View.ToTable();
            PagedDataSource objPage = new PagedDataSource();
            objPage.DataSource = datasearch.DefaultView;
            objPage.AllowPaging = true;
            objPage.PageSize = 9;
            objPage.CurrentPageIndex = CurrentPage;
            btnNext.Enabled = !objPage.IsLastPage;
            btnPre.Enabled = !objPage.IsFirstPage;
            databaseindex.DataSource = objPage;
            databaseindex.DataBind();
        }
    }
}