using System.Collections.Generic;

namespace KampGameProject.Abstract
{
    public interface ITableOperationsService<IEntity>
    {
        void Add(IEntity entity);

        void Delete(IEntity entity);

        void Update(IEntity entity);

        List<IEntity> GetList();

        IEntity GetById(int entityId);

        int LastIndex();

        void ConsoleMenu();

        void ConsoleAddForm();

        void ConsoleUpdateForm();

        void ConsoleDeleteForm();

        void ConsoleListView();
    }
}
