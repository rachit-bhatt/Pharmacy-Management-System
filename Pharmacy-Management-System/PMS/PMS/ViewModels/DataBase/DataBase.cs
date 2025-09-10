using System.Linq.Expressions;
using MongoDB.Driver;
using System.Collections.ObjectModel;
using PMS.Models;

namespace PMS.ViewModels.DataBase
{
    public class DataBase<T> where T : class
    {
        private readonly IMongoCollection<T> _collection;

        public ObservableCollection<T> Items { get; } = new();

        public DataBase(string connectionString, string databaseName, string collectionName)
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);
            _collection = database.GetCollection<T>(collectionName);
            LoadAll();
        }

        #region Select/Load

        public void LoadAll()
        {
            Items.Clear();
            foreach (var item in _collection.Find(_ => true).ToList())
                Items.Add(item);
        }

        public T? GetById(string id)
        {
            var filter = Builders<T>.Filter.Eq(nameof(PatientData.Id), id);
            return _collection.Find(filter).FirstOrDefault();
        }

        /// <summary>
        /// New function: Load by any field name and value
        /// </summary>
        /// <param name="fieldName"></param>
        /// <param name="value"></param>
        public void LoadByField(string fieldName, object value)
        {
            Items.Clear();
            var filter = Builders<T>.Filter.Eq(fieldName, value);
            foreach (var item in _collection.Find(filter).ToList())
                Items.Add(item);
        }

        /// <summary>
        /// New overload using Expression for compile-time safety
        /// </summary>
        /// <typeparam name="TField"></typeparam>
        /// <param name="fieldSelector"></param>
        /// <param name="value"></param>
        public void LoadByField<TField>(Expression<Func<T, TField>> fieldSelector, TField value)
        {
            var fieldName = GetMemberName(fieldSelector);
            LoadByField(fieldName, value!);
        }

        private static string GetMemberName<TField>(Expression<Func<T, TField>> expression)
        {
            if (expression.Body is MemberExpression member)
                return member.Member.Name;
            if (expression.Body is UnaryExpression unary && unary.Operand is MemberExpression memberOperand)
                return memberOperand.Member.Name;
            throw new ArgumentException("Invalid field selector expression");
        }

        #endregion

        #region Insert/Add

        public void Add(T item)
        {
            _collection.InsertOne(item);
            Items.Add(item);
        }

        #endregion

        #region Update/Alter

        public void Update(string id, T item)
        {
            var filter = Builders<T>.Filter.Eq(nameof(PatientData.Id), id);
            _collection.ReplaceOne(filter, item);
            LoadAll();
        }

        #endregion

        #region Delete/Drop/Truncate

        public void Delete(string id)
        {
            var filter = Builders<T>.Filter.Eq(nameof(PatientData.Id), id);
            _collection.DeleteOne(filter);
            var toRemove = Items.FirstOrDefault(i => (string?)i?.GetType().GetProperty(nameof(PatientData.Id))?.GetValue(i) == id);
            if (toRemove != null)
                Items.Remove(toRemove);
        }

        #endregion
    }
}