using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace ProjectProgressUpdate
{
    public partial class UpdateProjectProgress : System.Web.UI.Page
    {
        ProjectClass objProjectCls;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["cprj"] != null  && Request.QueryString["cact"] != null)
                {
                    GetProjectProgress();
                }
            }
        }

        private void GetProjectProgress()
        {
            objProjectCls = new ProjectClass();
            DataTable dt = objProjectCls.GetProjectProgressByID(Request.QueryString["cprj"],Request.QueryString["cact"]);
            if (dt.Rows.Count > 0)
            {
                txtActivity.Text = dt.Rows[0]["t_cact"].ToString();
                txtDescription.Text = dt.Rows[0]["t_dsca"].ToString();
                txtScheduledStartDate.Text = Convert.ToDateTime(dt.Rows[0]["t_sdst"]).ToString("dd-MM-yyyy");
                txtScheduledFinishDate.Text = Convert.ToDateTime(dt.Rows[0]["t_sdfn"]).ToString("dd-MM-yyyy");
                txtActualStartDate.Text = Convert.ToDateTime(dt.Rows[0]["t_acsd"]).ToString("dd-MM-yyyy");
                txtActualFinishDate.Text = Convert.ToDateTime(dt.Rows[0]["t_acfn"]).ToString("dd-MM-yyyy");
            }
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                objProjectCls = new ProjectClass();
                string Actual_SDate = Convert.ToDateTime(txtActualStartDate.Text).ToString("yyyy-MM-dd");
                string Actual_FDate = Convert.ToDateTime(txtActualFinishDate.Text).ToString("yyyy-MM-dd");
                int res = objProjectCls.UpdateActualDates(Request.QueryString["cprj"],Request.QueryString["cact"], Actual_SDate, Actual_FDate);
                if (res > 0)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", "alert('Successfully Updated');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", "alert('Not Updated');", true);
                }
            }
            catch(Exception ex)
            {

            }
        }
    }
}