using System.Collections.ObjectModel;
using System.Windows.Input;
using PMS.Models;

namespace PMS.ViewModels
{
    public class DashboardViewModel : ViewModelBase
    {
        public ObservableCollection<PatientData> Patients { get; } =
        [
            new PatientData
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "john@example.com",
                Contact = "1234567890",
                Gender = "Male",
                DateOfBirth = new DateTime(day: 29, month: 9, year: 2000),
                Address = "3000 Victoria Park Avenue, North York, Ontario, Canada",
                Allergies = "None",
                BloodGroup = "B+",
                EmergencyContact = "1234567890",
                MedicalHistory = "N/A",
                Notes = "N/A",
            },
            new PatientData
            {
                FirstName = "Jane",
                LastName = "Smith",
                Email = "jane@example.com",
                Contact = "0987654321",
                Gender = "Female",
                DateOfBirth = new DateTime(day: 18, month: 8, year: 2000),
                Address = "81 Glenstroke Drive, Scarborough, Ontario, Canada",
                Allergies = "None",
                BloodGroup = "A+",
                EmergencyContact = "1234567890",
                MedicalHistory = "N/A",
                Notes = "N/A"
            }
        ];

        public ICommand ViewCommand { get; }
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }

        public DashboardViewModel()
        {
            ViewCommand = new RelayCommand<PatientData>(OnView);
            EditCommand = new RelayCommand<PatientData>(OnEdit);
            DeleteCommand = new RelayCommand<PatientData>(OnDelete);
        }

        private void OnView(PatientData? patient)
        {
            if (patient == null) return;
            var window = new Views.PatientDataWindow { DataContext = new PatientDataViewModel { Patient = patient } };
            window.ShowDialog();
        }

        private void OnEdit(PatientData? patient)
        {
            // Implement edit logic (e.g., open edit dialog)
        }

        private void OnDelete(PatientData? patient)
        {
            if (patient != null)
                Patients.Remove(patient);
        }
    }
}