using System.Collections.ObjectModel;
using System.Windows.Input;
using PMS.Models;

namespace PMS.ViewModels
{
    public class DashboardViewModel : ViewModelBase
    {
        public ObservableCollection<PatientData> Patients { get; } =
        [
            new PatientData { FirstName = "John", LastName = "Doe", Email = "john@example.com", Contact = "1234567890", Gender = "Male" },
            new PatientData { FirstName = "Jane", LastName = "Smith", Email = "jane@example.com", Contact = "0987654321", Gender = "Female" }
        ];

        private PatientData? _selectedPatient;
        public PatientData? SelectedPatient
        {
            get => _selectedPatient;
            set => SetProperty(ref _selectedPatient, value);
        }

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