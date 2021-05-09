using Intelutions.Interview.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Intelutions.Interview.WebForm
{
    public partial class _Default : Page
    {
        private readonly PermissionRepository repository = new PermissionRepository();

        protected DataTable GetPermissions
        {
            get
            {
                DataTable datatable = new DataTable();
                datatable.Columns.Add("PermissionID", typeof(int));
                datatable.Columns.Add("EmployeeFirstName", typeof(string));
                datatable.Columns.Add("EmployeeFamilyName", typeof(string));
                datatable.Columns.Add("PermissionType", typeof(string));
                datatable.Columns.Add("PermissionDate", typeof(DateTime));

                List<Bussiness.Permission> permissions = repository.GetPermissionsWithType();
                foreach (Bussiness.Permission permission in permissions)
                {
                    datatable.Rows.Add(
                        permission.Id, 
                        permission.EmployeeFirstName, 
                        permission.EmployeeFamilyName,
                        permission.PermissionType.Description,
                        permission.PermissionDate);
                }

                return datatable;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
            }

            this.PermissionsDataBind();
        }

        protected void PermissionsDataBind()
        {
            this.GridViewPermissions.DataSource = this.GetPermissions;
            this.GridViewPermissions.DataBind();
        }

        protected void GridViewPermissions_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridViewPermissions.PageIndex = e.NewPageIndex;
            PermissionsDataBind();
        }

        protected void GridViewPermissions_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //if (e.CommandName == "Edit")
            //{
            //    int rowIndex = Convert.ToInt32(e.CommandArgument);
            //    GridViewRow row = this.GridViewPermissions.Rows[rowIndex];
            //    string permissionId = "1"; // row.Cells[0].Text;
                
            //    Response.Redirect($"Permission.aspx?id={permissionId}", false);
            //    HttpContext.Current.ApplicationInstance.CompleteRequest();
            //}
        }

        protected void Edit_Click(Object sender, CommandEventArgs e)
        {
            if (int.TryParse($"{e.CommandArgument}", out int permissionId))
            {
                Response.Redirect($"Permission.aspx?id={permissionId}", false);
                HttpContext.Current.ApplicationInstance.CompleteRequest();
            }
        }

        protected void Delete_Click(Object sender, CommandEventArgs e)
        {
            if (int.TryParse($"{e.CommandArgument}", out int permissionId))
            {
                repository.DeletePermission(permissionId);
                Response.Redirect(Request.RawUrl);
            }
        }
    }
}