using Intelutions.Interview.Bussiness;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Intelutions.Interview.Data
{
    /// <summary>
    /// Repositorio con las funciones para la manipulación de datos.
    /// </summary>
    public class PermissionRepository
    {
        /// <summary>
        /// Contexto de la base de datos.
        /// </summary>
        private readonly PermissionDbContext _context = new PermissionDbContext();

        /// <summary>
        /// Agrega un nuevo tipo de permiso.
        /// </summary>
        /// <param name="permissionType">Información del tipo de permiso.</param>
        public void NewPermissionType(PermissionType permissionType)
        {
            this._context.PermissionTypes.Add(permissionType);
            this._context.SaveChanges();
        }

        /// <summary>
        /// Actualiza un tipo de permiso.
        /// </summary>
        /// <param name="permission">Información del tipo de permiso.</param>
        public void UpdatePermissionType(PermissionType permissionType)
        {
            PermissionType currentPermissionType = this._context.PermissionTypes
                .FirstOrDefault(model => model.Id == permissionType.Id);
            // TODO: [apedrozo]
        }

        /// <summary>
        /// Obtiene listado de tipos de permiso.
        /// </summary>
        /// <returns>Listado de tipos de permiso.</returns>
        public List<PermissionType> GetPermissionTypes()
        {
            return this._context.PermissionTypes.ToList();
        }

        /// <summary>
        /// Agrega un nuevo permiso.
        /// </summary>
        /// <param name="permission">Información del permiso.</param>
        public void NewPermission(Permission permission)
        {
            this._context.Permissions.Add(permission);
            this._context.SaveChanges();
        }

        /// <summary>
        /// Actualiza un permiso.
        /// </summary>
        /// <param name="permission">Información del permiso.</param>
        public void UpdatePermission(Permission permission)
        {
            Permission currentPermission = this._context.Permissions
                .FirstOrDefault(model => model.Id == permission.Id);

            currentPermission.EmployeeFirstName = permission.EmployeeFirstName;
            currentPermission.EmployeeFamilyName = permission.EmployeeFamilyName;
            currentPermission.PermissionTypeId = permission.PermissionTypeId;
            currentPermission.PermissionDate = permission.PermissionDate;

            this._context.SaveChanges();

            // TODO: [apedrozo]
        }

        /// <summary>
        /// Elimina un permiso.
        /// </summary>
        /// <param name="permission">Permiso a eliminar.</param>
        public void DeletePermission(Permission permission)
        {
            this._context.Permissions.Remove(permission);
            this._context.SaveChanges();
        }

        /// <summary>
        /// Elimina un permiso por identificador.
        /// </summary>
        /// <param name="id">Identificador del permiso.</param>
        public void DeletePermission(int id)
        {
            Permission permission = this._context.Permissions
                .FirstOrDefault(model => model.Id == id);

            this.DeletePermission(permission);
        }

        /// <summary>
        /// Obtiene un permiso por identificador.
        /// </summary>
        /// <param name="id">Identificador del permiso.</param>
        /// <returns>Información del permiso.</returns>
        public Permission GetPermission(int id) => this._context.Permissions
            .FirstOrDefault(model => model.Id == id);

        /// <summary>
        /// Obtiene un permiso con el tipo de permiso por identificador.
        /// </summary>
        /// <param name="id">Identificador del permiso.</param>
        /// <returns>Información del permiso con tipo de permiso.</returns>
        public Permission GetPermissionWithType(int id) => this._context.Permissions
            .Include(model => model.PermissionType)
            .FirstOrDefault(model => model.Id == id);

        /// <summary>
        /// Obtiene un listado de permisos.
        /// </summary>
        /// <returns>Listado de permisos.</returns>
        public List<Permission> GetPermissions() => this._context.Permissions.ToList();
        

        /// <summary>
        /// Obtiene un listado de permisos con tipo de permiso.
        /// </summary>
        /// <returns>Listado de permisos con tipo de permiso.</returns>
        public List<Permission> GetPermissionsWithType() => this._context.Permissions
            .Include(model => model.PermissionType).ToList();
    }
}
