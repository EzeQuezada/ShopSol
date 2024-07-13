    

namespace ShopSol.Persistence.Exceptions
{
    public class ProductsExceptions : Exception
    {
        public ProductsExceptions(string message) : base(message)
        {
            //Logica para guardar el error en la base datos y enviar correo
        }

    }
}
