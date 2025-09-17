using PMS.Models;
using PMS.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace PMS.ViewModels
{
    public class DashboardViewModel : ViewModelBase
    {
        public ObservableCollection<PatientData> Patients { get; } = new();

        public ICommand ReloadCommand { get; }
        public ICommand AddCommand { get; }
        public ICommand ExitCommand { get; }
        public ICommand RefreshCommand { get; }
        public ICommand ViewCommand { get; }
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }

        public DashboardViewModel()
        {
            ReloadCommand = new RelayCommand<object>(_ => PatientDb.LoadAll());
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
                PatientDb.Add(newPatient);
                Patients.Add(newPatient);
            }
        }

        private static void Refresh()
        {
            // Implement refresh logic if needed
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

            PatientDb.Update(patient.Id, patient);
        }

        private void OnDelete(PatientData? patient)
        {
            if (patient != null)
            {
                Patients.Remove(patient);
                PatientDb.Delete(patient.Id);
            }
        }
    }
}