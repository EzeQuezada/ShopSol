

namespace ShopSol.Aplication.Core
{
    public abstract class BaseService<TModelAdd, TModelMOd,TModelRem>
    {
        public abstract ServiceResult Get();
        public abstract ServiceResult GetById(int id);
        public abstract ServiceResult Save(TModelAdd model);
        public abstract ServiceResult Update(TModelMOd model);
        public abstract ServiceResult Remove(TModelRem model);

    }
}
