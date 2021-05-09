using Intelutions.Interview.Data;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Intelutions.Interview.WebForm
{
    public partial class Permission : Page
    {
        private readonly PermissionRepository repository = new PermissionRepository();

        protected List<Bussiness.PermissionType> PermissionTypes
        {
            get
            {
                return repository.GetPermissionTypes();
            }
        }

        private bool IsEdit
        {
            get
            {
                return !string.IsNullOrWhiteSpace(Request.QueryString["id"]);
            }
        }

        private int PermissionId
        {
            get
            {
                int.TryParse(Request.QueryString["id"], out int id);

                return id;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.txtPermissionDate.Attributes.Add("readonly", "readonly");

            if (!IsPostBack)
            {
                this.LoadPermissionTypes();

               if (IsEdit)
                {
                    Bussiness.Permission permission = repository.GetPermission(this.PermissionId);

                    this.txtFirstName.Text = permission.EmployeeFirstName;
                    this.txtFamilyName.Text = permission.EmployeeFamilyName;
                    this.drpPermissionType.SelectedValue = $"{permission.PermissionTypeId}";
                    this.txtPermissionDate.Text = permission.PermissionDate.ToString("dd-MM-yyyy");
                }
            }
        }

        private void LoadPermissionTypes()
        {
            List<Bussiness.PermissionType> permissionTypes = PermissionTypes;

            drpPermissionType.Items.Clear();
            drpPermissionType.Items.Add(new ListItem("Ninguno", ""));

            foreach (var permissionType in permissionTypes)
            {
                drpPermissionType.Items.Add(new ListItem(permissionType.Description, $"{permissionType.Id}"));
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int.TryParse(this.drpPermissionType.SelectedValue, out int permissionTypeId);

            Bussiness.Permission permission = new Bussiness.Permission
            {
                EmployeeFirstName = this.txtFirstName.Text,
                EmployeeFamilyName = this.txtFamilyName.Text,
                PermissionTypeId = permissionTypeId,
                PermissionDate = DateTime.Parse(this.txtPermissionDate.Text)
            };

            if (IsEdit)
            {
                permission.Id = this.PermissionId;
                
                repository.UpdatePermission(permission);

                Response.Redirect("Default.aspx", false);
                HttpContext.Current.ApplicationInstance.CompleteRequest();

                return;
            }

            repository.NewPermission(permission);

            Response.Redirect("Default.aspx", false);
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
    }
}