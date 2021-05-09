using Intelutions.Interview.Bussiness;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace Intelutions.Interview.Data
{
    public class PermissionInitializer : DropCreateDatabaseIfModelChanges<PermissionDbContext>
    {
        protected override void Seed(PermissionDbContext context)
        {
            var permissionTypes = new List<PermissionType>
            {
                new PermissionType { Description="Enfermedad" },
                new PermissionType { Description="Diligencia" },
                new PermissionType { Description="Otro" }
            };

            permissionTypes.ForEach(permissionType => context.PermissionTypes.Add(permissionType));
            context.SaveChanges();

            var permissions = new List<Permission>
            {
                new Permission { EmployeeFirstName = "Alejandro", EmployeeFamilyName = "Pedrozo", PermissionTypeId = 1, PermissionDate = DateTime.Now },
                new Permission { EmployeeFirstName = "Caro", EmployeeFamilyName = "Ospina", PermissionTypeId = 2, PermissionDate = DateTime.Now }
            };

            permissions.ForEach(permission => context.Permissions.Add(permission));
        }
    }
}
