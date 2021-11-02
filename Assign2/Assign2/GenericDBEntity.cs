using SQLite;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SQLiteNetExtensions.Extensions;
using SQLiteNetExtensionsAsync.Extensions;

namespace Assign2
{
    public class GenericDBEntity<T> where T : class, new()
    {
        public SQLiteAsyncConnection Connection { get; }
        public GenericDBEntity(string dbPath)
        {
            Connection = new SQLiteAsyncConnection(dbPath);
            Connection.CreateTableAsync<T>().Wait();
        }

        public Task<List<T>> GetAsync() => Connection.GetAllWithChildrenAsync<T>();

        public Task SaveAsync(T t) => Connection.InsertWithChildrenAsync(t);

        public Task<T> GetOneByPredicate(Expression<Func<T, bool>> predicate)
        {
            return Connection.GetAllWithChildrenAsync(predicate).ContinueWith(a => a.Result.Count > 0 ? a.Result[0] : null);
        }

        public Task Update(T t)
        {
            return Connection.UpdateWithChildrenAsync(t);
        }
    }
}
