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
            SaveCommand = new RelayCommand<object>(_ => Save(), _ => IsEditing);
        }

        private void Save()
        {
            System.Windows.Window? window = System.Windows.Application.Current.Windows
                .OfType<System.Windows.Window>()
                .FirstOrDefault(w => w.DataContext == this);

            if (window != null)
            {
                window.DialogResult = true; // This is the key line!
                window.Close();
            }
        }
    }
}