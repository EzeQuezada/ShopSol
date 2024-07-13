

namespace ShopSol.Persistence.Exceptions
{
    public class SuppliersExceptions : Exception
    {
        public SuppliersExceptions(string message) : base(message)
        {
            //Logica para guardar el error en la base datos y enviar correo
        }
    }
}
