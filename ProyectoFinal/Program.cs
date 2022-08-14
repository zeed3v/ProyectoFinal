namespace ProyectoFinal
{
    public class ProbarObjetos
    {
        static void Main(string[] args)
        {
            ProductoHandler productoHandler = new ProductoHandler();

            productoHandler.TraerProductos();


            UsuarioHandler usuarioHandler = new UsuarioHandler();

            usuarioHandler.TraerUsuarios();


            ProductoVendidoHandler productoVendidoHandler = new ProductoVendidoHandler();

            ProductoVendidoHandler.TraerProductoVendido();
            

            VentaHandler ventaHandler = new VentaHandler();

            ventaHandler.TraerVenta();
        }
    }
}