using Amarok.Bootstrap.Domain.Entities;
using Amarok.Bootstrap.Domain.Repository;
using NHibernate;
using System;
using System.Collections.Generic;

namespace Amarok.Bootstrap.Infrastructure.Repository
{
    public class RepositoryNH<T> : IRepository<T>
        where T : Entity
    {
        protected internal ISession session;

        public RepositoryNH(ISession session)
        {
            this.session = session;
        }

        public void Add<T>(T item)
        {
            if (item != null)
            {
                using (ITransaction transaction = this.session.BeginTransaction())
                {
                    try
                    {
                        this.session.Save(item);
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        if (transaction.IsActive)
                            transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public void Delete<T>(T item)
        {
            if (item != null)
            {
                using (ITransaction transaction = this.session.BeginTransaction())
                {
                    try
                    {
                        this.session.Delete(item);
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public void Update<T>(T item)
        {
            if (item != null)
            {
                using (ITransaction transaction = this.session.BeginTransaction())
                {
                    try
                    {
                        this.session.Update(item);
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public T Get<T>(long id)
        {
            return this.session.Get<T>(id);
        }

        public IEnumerable<T> All()
        {
            return this.session.QueryOver<T>().List<T>();
        }

        public void Save<T>(T item)
        {
            if (item != null)
            {
                using (ITransaction transaction = this.session.BeginTransaction())
                {
                    try
                    {
                        this.session.Save(item);
                        transaction.Commit();
                    }
                    catch
                    {
                        if (transaction.IsActive)
                            transaction.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}