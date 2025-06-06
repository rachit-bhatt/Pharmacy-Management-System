using PMS.Models;
using PMS.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;

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
                Contact = "9876543210",
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

        public ICommand AddCommand { get; }
        public ICommand ExitCommand { get; }
        public ICommand RefreshCommand { get; }
        public ICommand ViewCommand { get; }
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }

        public DashboardViewModel()
        {
            AddCommand = new RelayCommand<object>(_ => AddRecord());
            ExitCommand = new RelayCommand<object>(_ => System.Windows.Application.Current.Shutdown());
            RefreshCommand = new RelayCommand<object>(_ => Refresh());

            ViewCommand = new RelayCommand<PatientData>(OnView);
            EditCommand = new RelayCommand<PatientData>(OnEdit);
            DeleteCommand = new RelayCommand<PatientData>(OnDelete);
        }

        private void AddRecord()
        {
            PatientData newPatient = new();
            PatientDataViewModel vm = new() { Patient = newPatient, IsEditing = true };
            PatientDataWindow window = new() { DataContext = vm, ShowInTaskbar = false, Topmost = true };

            if (window.ShowDialog() == true &&
                window.DialogResult.HasValue &&
                window.DialogResult.Value)
            {
                Patients.Add(newPatient);
            }
        }

        private static void Refresh()
        {
            // About to implement the Refresh Logic.
        }

        private static void OnView(PatientData? patient)
        {
            if (patient == null) return;
            PatientDataViewModel vm = new() { Patient = patient, IsEditing = false };
            PatientDataWindow window = new() { DataContext = vm };
            window.ShowDialog();
        }

        private static void OnEdit(PatientData? patient)
        {
            if (patient == null) return;

            PatientData editCopy = new()
            {
                Id = patient.Id,
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                Email = patient.Email,
                Contact = patient.Contact,
                DateOfBirth = patient.DateOfBirth,
                Gender = patient.Gender,
                Address = patient.Address,
                MedicalHistory = patient.MedicalHistory,
                EmergencyContact = patient.EmergencyContact,
                BloodGroup = patient.BloodGroup,
                Allergies = patient.Allergies,
                Notes = patient.Notes
            };

            PatientDataViewModel vm = new() { Patient = editCopy, IsEditing = true };
            PatientDataWindow window = new() { DataContext = vm, ShowInTaskbar = false, Topmost = true };

            if (window.ShowDialog() == true &&
                window.DialogResult.HasValue &&
                window.DialogResult.Value)
            {
                // Only update the original if Save was pressed
                patient.FirstName = editCopy.FirstName;
                patient.LastName = editCopy.LastName;
                patient.Email = editCopy.Email;
                patient.Contact = editCopy.Contact;
                patient.DateOfBirth = editCopy.DateOfBirth;
                patient.Gender = editCopy.Gender;
                patient.Address = editCopy.Address;
                patient.MedicalHistory = editCopy.MedicalHistory;
                patient.EmergencyContact = editCopy.EmergencyContact;
                patient.BloodGroup = editCopy.BloodGroup;
                patient.Allergies = editCopy.Allergies;
                patient.Notes = editCopy.Notes;
            }
        }

        private void OnDelete(PatientData? patient)
        {
            if (patient != null)
                Patients.Remove(patient);
        }
    }
}