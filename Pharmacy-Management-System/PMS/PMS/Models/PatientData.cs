namespace PMS.Models
{
    public class PatientData : ModelBase
    {
        private int _id;
        public int Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        private string _firstName = string.Empty;
        public string FirstName
        {
            get => _firstName;
            set => SetProperty(ref _firstName, value);
        }

        private string _lastName = string.Empty;
        public string LastName
        {
            get => _lastName;
            set => SetProperty(ref _lastName, value);
        }

        private string _email = string.Empty;
        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        private string _contact = string.Empty;
        public string Contact
        {
            get => _contact;
            set => SetProperty(ref _contact, value);
        }

        private DateTime? _dateOfBirth;
        public DateTime? DateOfBirth
        {
            get => _dateOfBirth;
            set => SetProperty(ref _dateOfBirth, value);
        }

        /// <summary>
        /// Gets the current age in years, or null if DateOfBirth is null.
        /// </summary>
        public int? Age
        {
            get
            {
                if (!_dateOfBirth.HasValue)
                    return null;

                var today = DateTime.Today;
                var dob = _dateOfBirth.Value;
                int age = today.Year - dob.Year;
                if (dob.Date > today.AddYears(-age)) age--;
                return age;
            }
        }

        private string _gender = string.Empty;
        public string Gender
        {
            get => _gender;
            set => SetProperty(ref _gender, value);
        }

        private string _address = string.Empty;
        public string Address
        {
            get => _address;
            set => SetProperty(ref _address, value);
        }

        private string _medicalHistory = string.Empty;
        public string MedicalHistory
        {
            get => _medicalHistory;
            set => SetProperty(ref _medicalHistory, value);
        }

        private string _emergencyContact = string.Empty;
        public string EmergencyContact
        {
            get => _emergencyContact;
            set => SetProperty(ref _emergencyContact, value);
        }

        private string _bloodGroup = string.Empty;
        public string BloodGroup
        {
            get => _bloodGroup;
            set => SetProperty(ref _bloodGroup, value);
        }

        private string _allergies = string.Empty;
        public string Allergies
        {
            get => _allergies;
            set => SetProperty(ref _allergies, value);
        }

        private string _notes = string.Empty;
        public string Notes
        {
            get => _notes;
            set => SetProperty(ref _notes, value);
        }
    }
}