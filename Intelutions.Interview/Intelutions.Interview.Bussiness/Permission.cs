using System;

namespace Intelutions.Interview.Bussiness
{
    /// <summary>
    /// Entidad permiso.
    /// </summary>
    public class Permission
    {
        /// <summary>
        /// Identificador del permiso.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nombre del empleado.
        /// </summary>
        public string EmployeeFirstName { get; set; }

        /// <summary>
        /// Apellidos del empleado.
        /// </summary>
        public string EmployeeFamilyName { get; set; }

        /// <summary>
        /// Objeto con la información del tipo de permiso.
        /// </summary>
        public PermissionType PermissionType { get; set; }

        /// <summary>
        /// Identificador del tipo de permiso.
        /// </summary>
        public int PermissionTypeId { get; set; }

        /// <summary>
        /// Fecha del permiso.
        /// </summary>
        public DateTime PermissionDate { get; set; }
    }
}
