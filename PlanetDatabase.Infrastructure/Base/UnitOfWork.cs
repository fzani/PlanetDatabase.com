using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;


namespace PlanetDatabase.Infrastructure.Base
{

    public class UnitOfWork<T> : IUnitOfWork where T : IObjectContextAdapter, new()
    {
        public DbContext Db
        {
            get { return _db; }
        }
        private TransactionScope _transaction;
        private readonly DbContext _db;

        public UnitOfWork()
        {
            _db = new T() as DbContext;
        }

        public void DelegateTransaction(Action action)
        {
            using (var resource = _db.Database.BeginTransaction())
            {
                try
                {
                    action.Invoke();
                    resource.Commit();
                }
                catch (Exception ex)
                {
                    resource.Rollback();
                    throw ex;
                }
            }
        }

        public void StartTransaction()
        {
            _transaction = new TransactionScope();
        }

        public void Commit()
        {
            _db.SaveChanges();
            if (_transaction != null)
            {
                _transaction.Complete();
            }
        }

        private bool disposed = false;

        //Implement IDisposable.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // Free other state (managed objects).
                }
                // Free your own state (unmanaged objects).
                // Set large fields to null.
                disposed = true;
            }
        }

        // Use C# destructor syntax for finalization code.
        ~UnitOfWork()
        {
            // Simply call Dispose(false).
            Dispose(false);
        }



    }
}

