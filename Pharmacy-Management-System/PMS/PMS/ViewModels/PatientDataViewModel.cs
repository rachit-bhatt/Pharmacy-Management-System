using PMS.Models;

namespace PMS.ViewModels
{
    public class PatientDataViewModel : ViewModelBase
    {
        private PatientData _patient = new();

        public PatientData Patient
        {
            get => _patient;
            set => SetProperty(ref _patient, value);
        }

        public PatientDataViewModel()
        {

        }
    }
}