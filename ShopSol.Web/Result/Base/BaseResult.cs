namespace ShopSol.Web.Result.Base
{
    public class BaseResult<TModel>
    {
        public bool success { get; set; }
        public object message { get; set; }
        public TModel data { get; set; }
    }
}
