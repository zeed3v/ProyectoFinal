using System.Data;
using System.Data.SqlClient;

namespace ProyectoFinal
{
    public class ProductoHandler : DbHandler
    {
        public static List<Producto> TraerProductos(int id)
        {
            List<Producto> productos = new List<Producto>();
            
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.Connection.Open();
                    sqlCommand.CommandText = "SELECT * FROM Producto where IdUsuario = @idUsuario;";

                    sqlCommand.Parameters.AddWithValue("@idUsuario", id);

                    SqlDataAdapter dataAdapter = new SqlDataAdapter();
                    dataAdapter.SelectCommand = sqlCommand;
                    DataTable table = new DataTable();
                    dataAdapter.Fill(table); //Se ejecuta el Select
                    sqlCommand.Connection.Close();
                    foreach (DataRow row in table.Rows)
                    {
                        Producto producto = new Producto();
                        producto.Id = Convert.ToInt32(row["Id"]);
                        producto.Descripciones = row["Descripciones"]?.ToString();
                        producto.Costo = Convert.ToDouble(row["Costo"]);
                        producto.PrecioVenta = Convert.ToDouble(row["PrecioVenta"]);
                        producto.Stock = Convert.ToInt32(row["Stock"]);
                        producto.IdUsuario = Convert.ToInt32(row["IdUsuario"]);

                        productos.Add(producto);
                    }
                }
            }

            return productos;
        }

    }
}