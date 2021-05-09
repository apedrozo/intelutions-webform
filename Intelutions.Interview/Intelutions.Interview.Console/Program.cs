using Intelutions.Interview.Bussiness;
using Intelutions.Interview.Data;
using System;
using System.Collections.Generic;

namespace Intelutions.Interview.AppConsole
{
    /// <summary>
    /// Configuración de la aplicación de consola.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Inicio del programa.
        /// </summary>
        /// <param name="args">Argumentos del programa.</param>
        static void Main(string[] args)
        {
            SelectPermmisionTypes();
            //InsertPermmisionTypes();
            Console.ReadKey();
        }

        /// <summary>
        /// Prueba para la obtención de tipos de permisos.
        /// </summary>
        static void SelectPermmisionTypes()
        {
            PermissionRepository repository = new PermissionRepository();

            List<PermissionType> permissionTypes = repository.GetPermissionTypes();

            foreach (PermissionType permissionType in permissionTypes)
            {
                Console.WriteLine($"{permissionType.Id}: {permissionType.Description}");
            }
        }

        /// <summary>
        /// Prueba para la inserción de tipos de permisos.
        /// </summary>
        static void InsertPermmisionTypes()
        {
            PermissionRepository repository = new PermissionRepository();

            var permissionType = new PermissionType
            {
                Description = "Enfermedad"
            };
            repository.NewPermissionType(permissionType);

            permissionType = new PermissionType
            {
                Description = "Diligencias"
            };
            repository.NewPermissionType(permissionType);

            permissionType = new PermissionType
            {
                Description = "Otros"
            };
            repository.NewPermissionType(permissionType);
        }
    }
}
