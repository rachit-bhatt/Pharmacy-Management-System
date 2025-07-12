using MongoDB.Driver;
using PMS.Models;

namespace PMS.ViewModels
{
    public class PatientRepository
    {
        private readonly IMongoCollection<PatientData> _patients;

        public PatientRepository(MongoDbContext context)
        {
            _patients = context.GetCollection<PatientData>("patients");
        }

        public List<PatientData> GetAll() => _patients.Find(_ => true).ToList();

        public PatientData GetById(string id) =>
            _patients.Find(p => p.Id == id).FirstOrDefault();

        public void Insert(PatientData patient) => _patients.InsertOne(patient);

        public void Update(string id, PatientData patient) =>
            _patients.ReplaceOne(p => p.Id == id, patient);

        public void Delete(string id) =>
            _patients.DeleteOne(p => p.Id == id);
    }
}