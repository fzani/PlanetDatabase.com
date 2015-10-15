using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Data.SqlClient;

namespace PlanetDatabase.Infrastructure.Base
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly IUnitOfWork _unitOfWork;
        internal DbSet<T> dbSet;

        public Repository(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null) throw new ArgumentNullException((typeof(IUnitOfWork)).GetType().FullName);
            _unitOfWork = unitOfWork;
            this.dbSet = _unitOfWork.Db.Set<T>();
        }

        /// <summary>
        /// Sets a different type from T in run time
        /// </summary>
        /// <typeparam name="TEntity">Entity type</typeparam>
        /// <returns>DbSet</returns>
        public DbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return this._unitOfWork.Db.Set<TEntity>();
        }

        /// <summary>
        /// Expose a "where" filter in delegate finction filter, if filter is null expose a object as quaryable.
        /// </summary>
        /// <param name="filter">delegate finction filter</param>
        /// <returns>object as quaryable</returns>
        public IQueryable<T> Query(Expression<Func<T, bool>> filter = null)
        {
            IQueryable<T> query = dbSet.AsQueryable();

            if (filter != null)
                query = query.Where(filter);

            return query;
        }

        /// <summary>
        /// Return a IEnumerable of typed request
        /// </summary>
        /// <typeparam name="TEntity">Entity return</typeparam>
        /// <param name="query">Sql query (ex.: "Select * from [table]")</param>
        /// <param name="parameters"></param>
        /// <returns>IEnumerable of type request</returns>
        public IEnumerable<TEntity> SqlQuery<TEntity>(string query, params object[] parameters) where TEntity : class
        {
            var _dbSet = _unitOfWork.Db.Set<TEntity>();
            return _dbSet.SqlQuery(query, parameters);
        }

        /// <summary>
        /// Call database procedure and return 'TEntity' type. This type not necessary exist in your DBContext.
        /// </summary>
        /// <typeparam name="TEntity">Return of procedure</typeparam>
        /// <param name="name">Porcedure name. Only name, without "exec"</param>
        /// <param name="parameters">SqlParameters</param>        
        /// <returns></returns>
        public IEnumerable<TEntity> ProcedureCall<TEntity>(string name, params SqlParameter[] parameters) where TEntity : class
        {
            if (name.ToLower().Contains("exec "))
            {
                throw new Exception("Your call contains \"EXEC <procedure>\". Call again without \"exec\" parameter.");
            }
            return _unitOfWork.Db.Database.SqlQuery<TEntity>(string.Concat("exec ", name), parameters);
        }

        /// <summary>
        /// Returns the object with the primary key specifies or throws
        /// </summary>
        /// <typeparam name="TU">The type to map the result to</typeparam>
        /// <param name="primaryKey">The primary key</param>
        /// <returns>The result mapped to the specified type</returns>
        public T Single(object primaryKey)
        {

            var dbResult = dbSet.Find(primaryKey);
            return dbResult;

        }

        /// <summary>
        /// Returns the unique object with the primary key specifies or expression
        /// </summary>
        /// <typeparam name="T">The type to map the result to</typeparam>
        /// <param name="filter">Expression linq</param>
        /// <returns>The result mapped to the specified type</returns>
        public T SingleOrDefault(Expression<Func<T, bool>> filter)
        {
            var dbResult = dbSet.FirstOrDefault(filter);
            return dbResult;
        }

        /// <summary>
        /// Returns the object with the primary key specifies or the default for the type
        /// </summary>
        /// <typeparam name="TU">The type to map the result to</typeparam>
        /// <param name="primaryKey">The primary key</param>
        /// <returns>The result mapped to the specified type</returns>
        public T SingleOrDefault(object primaryKey)
        {
            var dbResult = dbSet.Find(primaryKey);
            return dbResult;
        }

        //public virtual IEnumerable<T> GetAllWithDeleted()
        //{
        //    var dbresult = _unitOfWork.Db.Fetch<T>("");

        //    return dbresult;
        //}

        public bool Exists(object primaryKey)
        {
            return dbSet.Find(primaryKey) == null ? false : true;
        }

        public virtual T Insert(T entity)
        {
            dynamic obj = dbSet.Add(entity);
            this._unitOfWork.Db.SaveChanges();
            return obj;
        }        

        public bool Create(T entity)
        {
            dynamic obj = dbSet.Add(entity);
            return this._unitOfWork.Db.SaveChanges() > 0;
        }

        public virtual void Update(T entity)
        {
            dbSet.Attach(entity);
            _unitOfWork.Db.Entry(entity).State = EntityState.Modified;
            this._unitOfWork.Db.SaveChanges();
        }
        public Int64 Delete(T entity)
        {
            if (_unitOfWork.Db.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dynamic obj = dbSet.Remove(entity);
            this._unitOfWork.Db.SaveChanges();
            return obj.Id;
        }

        public Dictionary<string, string> GetAuditNames(dynamic dynamicObject)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            return dbSet.AsEnumerable().ToList();
        }

        #region ImplementDispose
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
        ~Repository()
        {
            // Simply call Dispose(false).
            Dispose(false);
        }

        #endregion


    }
}