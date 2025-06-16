using System;
using System.Data.SqlClient;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace proyectoUNP
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Probar la conexión a la base de datos
            TestDatabaseConnection();
        }

        private void TestDatabaseConnection()
        {
            string connectionString = "Server=ACERNITRO;Database=Sist_ControlActivos2;User Id=sa;Password=marlon123;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    System.Diagnostics.Debug.WriteLine("Conexión exitosa a la base de datos.");
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Error al conectar a la base de datos: " + ex.Message);
                }
            }
        }
    }
}
