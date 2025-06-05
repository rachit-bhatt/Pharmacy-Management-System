using PMS.Models;

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

        public PatientDataViewModel()
        {

        }
    }
}