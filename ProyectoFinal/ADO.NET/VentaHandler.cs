using System.Data;
using System.Data.SqlClient;

namespace ProyectoFinal
{
    public class VentaHandler : DbHandler
    {
        public List<Venta> TraerVentas(int id)
        {
            List<Venta> ventas = new List<Venta>();
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.Connection.Open();
                    sqlCommand.CommandText = "SELECT * FROM Venta WHERE IdUsuario = @idUsuario;";

                    sqlCommand.Parameters.AddWithValue("@idUsuario", id);

                    SqlDataAdapter dataAdapter = new SqlDataAdapter();
                    dataAdapter.SelectCommand = sqlCommand;
                    DataTable table = new DataTable();
                    dataAdapter.Fill(table); //Se ejecuta el Select
                    sqlCommand.Connection.Close();
                    foreach (DataRow row in table.Rows)
                    {
                        Venta venta = new Venta();

                        venta.Id = Convert.ToInt32(row["Id"]);
                        venta.Comentarios = row["Comentarios"]?.ToString();

                        ventas.Add(venta);
                    }
                }
            }

            return ventas;
        }
    }
}