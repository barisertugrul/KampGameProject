using System.Collections.Generic;

namespace KampGameProject.Abstract
{
    public interface IDbAdapterService<IEntity>
    {
        void Add(IEntity entity);
        void Update(IEntity entity);
        void Delete(IEntity entity);
        List<IEntity> GetList();
        int LastIndex();
        IEntity GetById(int entityId);
    }
}
