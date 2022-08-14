namespace ProyectoFinal
{
    public class ProbarObjetos
    {
        static void Main(string[] args)
        {
            ProductoHandler productoHandler = new ProductoHandler();

            productoHandler.TraerProductos();


            UsuarioHandler usuarioHandler = new UsuarioHandler();

            usuarioHandler.TraerUsuario();


            ProductoVendidoHandler productoVendidoHandler = new ProductoVendidoHandler();

            productoVendidoHandler.TraerProductoVendido();
            

            VentaHandler ventaHandler = new VentaHandler();

            ventaHandler.TraerVenta();
        }
    }
}