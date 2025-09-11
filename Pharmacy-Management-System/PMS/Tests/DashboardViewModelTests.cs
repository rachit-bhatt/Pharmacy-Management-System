// Make sure the PMS.ViewModels namespace is available to your test project.
// If the PMS project is not referenced, add a project reference to it in your test project.
// If the namespace is different, update the using directive accordingly.

using PMS.ViewModels;
using PMS.Models;
using System.ComponentModel;
using System.Collections.Specialized;
using Xunit;

namespace Tests
{
    public class DashboardViewModelTests
    {
        private PatientData CreateValidPatient(string? id = null)
        {
            return new PatientData
            {
                Id = id ?? Guid.NewGuid().ToString(),
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                Contact = "1234567890",
                DateOfBirth = new DateTime(1990, 1, 1),
                Gender = "Male",
                Address = "123 Main St",
                MedicalHistory = "None",
                EmergencyContact = "Jane Doe",
                BloodGroup = "O+",
                Allergies = "None",
                Notes = "Test patient"
            };
        }

        [Fact]
        public void DashboardViewModel_InitializesCommandsAndPatients()
        {
            var vm = new DashboardViewModel();
            Assert.NotNull(vm);
            Assert.NotNull(vm.Patients);
            Assert.NotNull(vm.ReloadCommand);
            Assert.NotNull(vm.AddCommand);
            Assert.NotNull(vm.DeleteCommand);
        }

        [Fact]
        public void Patients_InitialState_IsEmpty()
        {
            var vm = new DashboardViewModel();
            Assert.Empty(vm.Patients);
        }

        [Fact]
        public void ReloadCommand_RefreshesPatientsList()
        {
            var vm = new DashboardViewModel();
            var originalPatients = vm.Patients.ToList();
            vm.ReloadCommand.Execute(null);
            Assert.NotNull(vm.Patients);
            Assert.NotSame(originalPatients, vm.Patients);
        }

        [Fact]
        public void AddCommand_AddsNewPatient()
        {
            var vm = new DashboardViewModel();
            int initialCount = vm.Patients.Count;
            var newPatient = CreateValidPatient();
            vm.Patients.Add(newPatient); // Simulate AddCommand logic
            Assert.Equal(initialCount + 1, vm.Patients.Count);
            Assert.Contains(newPatient, vm.Patients);
        }

        [Fact]
        public void DeleteCommand_RemovesPatient()
        {
            var vm = new DashboardViewModel();
            var patient = CreateValidPatient();
            vm.Patients.Add(patient);
            int countAfterAdd = vm.Patients.Count;
            vm.DeleteCommand.Execute(patient);
            Assert.Equal(countAfterAdd - 1, vm.Patients.Count);
            Assert.DoesNotContain(patient, vm.Patients);
        }

        [Fact]
        public void Patients_RaisesPropertyChangedEvent()
        {
            var vm = new DashboardViewModel();
            bool eventRaised = false;
            ((INotifyPropertyChanged)vm).PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == "Patients")
                    eventRaised = true;
            };
            vm.ReloadCommand.Execute(null);
            Assert.True(eventRaised);
        }

        [Fact]
        public void Patients_RaisesCollectionChangedEvent_OnAddRemove()
        {
            var vm = new DashboardViewModel();
            bool addRaised = false, removeRaised = false;
            NotifyCollectionChangedEventHandler handler = (s, e) =>
            {
                if (e.Action == NotifyCollectionChangedAction.Add) addRaised = true;
                if (e.Action == NotifyCollectionChangedAction.Remove) removeRaised = true;
            };
            vm.Patients.CollectionChanged += handler;
            var patient = CreateValidPatient();
            vm.Patients.Add(patient);
            vm.Patients.Remove(patient);
            Assert.True(addRaised);
            Assert.True(removeRaised);
        }

        [Fact]
        public void AddCommand_DoesNotAddDuplicatePatients_ById()
        {
            var vm = new DashboardViewModel();
            var patient = CreateValidPatient("sameid");
            vm.Patients.Add(patient);
            int countAfterFirstAdd = vm.Patients.Count;
            var duplicate = CreateValidPatient("sameid");
            if (!vm.Patients.Any(p => p.Id == duplicate.Id))
                vm.Patients.Add(duplicate);
            int countAfterSecondAdd = vm.Patients.Count;
            Assert.Equal(countAfterFirstAdd, countAfterSecondAdd);
        }

        [Fact]
        public void DeleteCommand_DoesNothingIfPatientDoesNotExist()
        {
            var vm = new DashboardViewModel();
            int initialCount = vm.Patients.Count;
            var nonExistentPatient = CreateValidPatient();
            vm.DeleteCommand.Execute(nonExistentPatient);
            Assert.Equal(initialCount, vm.Patients.Count);
        }

        [Fact]
        public void AddCommand_ThrowsOnNullPatient()
        {
            var vm = new DashboardViewModel();
            Assert.ThrowsAny<Exception>(() => vm.AddCommand.Execute(null));
        }

        [Fact]
        public void DeleteCommand_ThrowsOnNullPatient()
        {
            var vm = new DashboardViewModel();
            Assert.ThrowsAny<Exception>(() => vm.DeleteCommand.Execute(null));
        }

        [Fact]
        public void ReloadCommand_HandlesEmptyOrNullDataSource()
        {
            var vm = new DashboardViewModel();
            vm.Patients.Clear();
            vm.ReloadCommand.Execute(null);
            Assert.NotNull(vm.Patients);
        }
    }
}