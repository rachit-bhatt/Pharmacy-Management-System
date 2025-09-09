using PMS.Models;
using System.Windows.Input;

namespace PMS.ViewModels
{
    public class PatientDataViewModel : ViewModelBase
    {
        private PatientData _patient = new();
        private bool _isEditing;

        public PatientData Patient
        {
            get => _patient;
            set => SetProperty(ref _patient, value);
        }

        public bool IsEditing
        {
            get => _isEditing;
            set => SetProperty(ref _isEditing, value);
        }

        public ICommand SaveCommand { get; }

        public PatientDataViewModel()
        {
            SaveCommand = new RelayCommand<object>(_ => Save(), _ => CanSave());
        }

        private bool CanSave()
        {
            // Validate all properties using IDataErrorInfo
            var properties = typeof(PatientData).GetProperties()
                .Where(p => p.CanRead && p.Name != nameof(PatientData.Error));
            foreach (var prop in properties)
            {
                if (!string.IsNullOrEmpty(Patient[prop.Name]))
                    return false;
            }
            return IsEditing;
        }

        private void Save()
        {
            System.Windows.Window? window = System.Windows.Application.Current.Windows
                .OfType<System.Windows.Window>()
                .FirstOrDefault(w => w.DataContext == this);

            if (window != null)
            {
                window.DialogResult = true;
                window.Close();
            }
        }
    }
}