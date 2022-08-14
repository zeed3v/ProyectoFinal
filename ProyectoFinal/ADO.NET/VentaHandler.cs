using System.Data.SqlClient;

namespace ProyectoFinal
{
    public class VentaHandler : DbHandler
    {
        public Venta GetById(int id)
        {
            List<Venta> venta = new List<Venta>();
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.Connection.Open();
                    sqlCommand.CommandText = "SELECT * FROM Venta WHERE IdUsuario = @id;";

                    sqlCommand.Parameters.AddWithValue("@id", id);

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
                        
                        venta.Add(venta);
                    }
                }
            }

            return venta;
        }

        public List<Venta> TraerVenta()
        {
            List<Venta> ventas = new List<Venta>();
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand(
                    "select * from Venta where Id = @id;", sqlConnection))
                {
                    sqlConnection.Open();

                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        // Me aseguro que haya filas que leer
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                Venta venta = new Venta();

                                venta.Id = Convert.ToInt32(dataReader["Id"]);
                                venta.Comentarios = dataReader["Comentarios"].ToString();

                                venta.Add(venta);
                            }
                        }
                    }

                    sqlConnection.Close();
                }
            }

            return ventas;
        }
    }
}