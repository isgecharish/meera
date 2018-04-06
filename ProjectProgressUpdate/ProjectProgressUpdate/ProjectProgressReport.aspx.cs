using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace ProjectProgressUpdate
{
    public partial class ProjectProgressReport : System.Web.UI.Page
    {
        ProjectClass objProjectCls;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    BindProjectId();
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void BindProjectId()
        {
            objProjectCls = new ProjectClass();
            DataTable dt = objProjectCls.GetProjectId();
            ddlProject.DataSource = dt;
            ddlProject.DataTextField = "t_cprj";
            ddlProject.DataValueField = "t_cprj";
            ddlProject.DataBind();
            ddlProject.Items.Insert(0, "Select");
        }
        protected void ddlProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            objProjectCls = new ProjectClass();
            DataTable dt = objProjectCls.GetProjectName(ddlProject.SelectedValue);
            txtProjectName.Text = dt.Rows[0][0].ToString();
        }
        private void GetProject()
        {
            DataTable dt = new DataTable();
            if (HttpContext.Current.Cache["ProjectData"] == null)
            {
                objProjectCls = new ProjectClass();
                string ProjectId = ddlProject.SelectedValue;
                dt = objProjectCls.GetProject(ProjectId);
                gvData.DataSource = dt;
                gvData.DataBind();
                HttpContext.Current.Cache.Insert("ProjectData", dt, null, DateTime.Now.AddMinutes(20), TimeSpan.Zero);
            }
            else
            {
                dt = (DataTable)HttpContext.Current.Cache["ProjectData"];
            }
        }
        protected void gvData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvData.PageIndex = e.NewPageIndex;
            GetProject();
        }
        protected void lnkUpdate_Click(object sender, EventArgs e)
        {
            LinkButton lnkUpdate = (LinkButton)sender;
            string[] Values = lnkUpdate.CommandArgument.Split('&');
            Response.Redirect("UpdateProjectProgress.aspx?cprj=" + Values[0] + "&cact=" + Values[1]);
        }
        protected void btnShow_Click(object sender, EventArgs e)
        {
            if (ddlProject.SelectedValue != "Select")
            {
                HttpContext.Current.Cache.Remove("ProjectData");
                GetProject();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", "alert('Select project');", true);
            }
        }
    }
}