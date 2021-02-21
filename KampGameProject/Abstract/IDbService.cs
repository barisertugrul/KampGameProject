using System.Collections.Generic;

namespace KampGameProject.Abstract
{
    public interface IDbService<IEntity>
    {
        void Add(IEntity entity);
        void Update(IEntity entity);
        void Delete(IEntity entity);
        List<IEntity> GetList();
    }
}
