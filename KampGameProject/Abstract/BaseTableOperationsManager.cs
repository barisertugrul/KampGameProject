using System;
using System.Collections.Generic;

namespace KampGameProject.Abstract
{
    public class BaseTableOperationsManager<IEntity> : ITableOperationsService<IEntity>
    {
        private IDbAdapterService<IEntity> _dbService;

        public BaseTableOperationsManager(IDbAdapterService<IEntity> dbService)
        {
            _dbService = dbService;

        }
        public virtual void Add(IEntity entity)
        {
            _dbService.Add(entity);
        }

        public void Delete(IEntity entity)
        {
            _dbService.Delete(entity);
        }

        public List<IEntity> GetList()
        {
            return _dbService.GetList();
        }

        public virtual void Update(IEntity entity)
        {
            _dbService.Update(entity);
        }

        public IEntity GetById(int entityId)
        {
            return _dbService.GetById(entityId);
        }

        public virtual void ConsoleMenu()
        {
            throw new NotImplementedException();
        }

        public virtual void ConsoleAddForm()
        {
            throw new NotImplementedException();
        }

        public virtual void ConsoleUpdateForm()
        {
            throw new NotImplementedException();
        }

        public virtual void ConsoleDeleteForm()
        {
            throw new NotImplementedException();
        }

        public virtual void ConsoleListView()
        {
            throw new NotImplementedException();
        }

        public int LastIndex()
        {
            return _dbService.LastIndex();
        }
    }
}
