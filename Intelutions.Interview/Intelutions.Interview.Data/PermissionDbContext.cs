using Intelutions.Interview.Bussiness;
using System.Data.Entity;

namespace Intelutions.Interview.Data
{
    /// <summary>
    /// Contexto de base de datos.
    /// </summary>
    public class PermissionDbContext : DbContext
    {
        /// <summary>
        /// Conjunto de tipos de permiso.
        /// </summary>
        public DbSet<PermissionType> PermissionTypes { get; set; }

        /// <summary>
        /// Conjunto de permisos.
        /// </summary>
        public DbSet<Permission> Permissions { get; set; }
    }
}