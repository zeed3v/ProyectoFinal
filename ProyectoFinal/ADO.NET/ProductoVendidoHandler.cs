using System.Data.SqlClient;

namespace ProyectoFinal
{
    public class ProductoVendidoHandler : DbHandler
    {
        public ProductoVendido GetById(int id)
        {
            List<ProductoVendido> productos = new List<ProductoVendido>();
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.Connection.Open();
                    sqlCommand.CommandText = "select * from ProductoVendido where IdUsuario = @IdUsuario";

                    sqlCommand.Parameters.AddWithValue("@id", id);

                    SqlDataAdapter dataAdapter = new SqlDataAdapter();
                    dataAdapter.SelectCommand = sqlCommand;
                    DataTable table = new DataTable();
                    dataAdapter.Fill(table); //Se ejecuta el Select
                    sqlCommand.Connection.Close();
                    foreach (DataRow row in table.Rows)
                    {
                        ProductoVendido productoVendido = new ProductoVendido();
                        
                        productoVendido.Id = Convert.ToInt32(row["Id"]);
                        productoVendido.Stock = row["Stock"]?.ToString();
                        productoVendido.IdProducto = Convert.ToDouble(row["IdProducto"]);
                        productoVendido.IdVenta = Convert.ToDouble(row["IdVenta"]);

                        productoVendido.Add(productoVendido);
                    }
                }
            }

            return productos?.FirstOrDefault();
        }

        public class TraerProductoVendido();
    }
}