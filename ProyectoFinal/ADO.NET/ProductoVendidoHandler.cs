using System.Data;
using System.Data.SqlClient;

namespace ProyectoFinal
{
    public class ProductoVendidoHandler : DbHandler
    {
        public List<ProductoVendido> TraerProductoVendido(int id)
        {
            List<ProductoVendido> productosVendidos = new List<ProductoVendido>();
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.Connection.Open();
                    sqlCommand.CommandText = "select * from ProductoVendido where IdUsuario = @idUsuario";

                    sqlCommand.Parameters.AddWithValue("@idUsuario", id);

                    SqlDataAdapter dataAdapter = new SqlDataAdapter();
                    dataAdapter.SelectCommand = sqlCommand;
                    DataTable table = new DataTable();
                    dataAdapter.Fill(table);
                    sqlCommand.Connection.Close();
                    foreach (DataRow row in table.Rows)
                    {
                        ProductoVendido productoVendido = new ProductoVendido();
                        
                        productoVendido.Id = Convert.ToInt32(row["Id"]);
                        productoVendido.Stock = Convert.ToInt32(row["Stock"]);
                        productoVendido.IdProducto = Convert.ToInt32(row["IdProducto"]);
                        productoVendido.IdVenta = Convert.ToInt32(row["IdVenta"]);

                        productosVendidos.Add(productoVendido);
                    }
                }
            }

            return productosVendidos;
        }
    }
}