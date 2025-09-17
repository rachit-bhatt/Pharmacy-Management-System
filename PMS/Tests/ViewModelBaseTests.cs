using PMS.ViewModels;
using System.ComponentModel;

namespace Tests
{
    public class ViewModelBaseTests
    {
        private class TestViewModel : ViewModelBase
        {
            private string _testProperty;
            public string TestProperty
            {
                get => _testProperty;
                set => SetProperty(ref _testProperty, value);
            }
        }

        [Fact]
        public void SetProperty_UpdatesValue_AndRaisesPropertyChanged()
        {
            var vm = new TestViewModel();
            bool eventRaised = false;
            ((INotifyPropertyChanged)vm).PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == nameof(TestViewModel.TestProperty))
                    eventRaised = true;
            };

            vm.TestProperty = "new value";

            Assert.Equal("new value", vm.TestProperty);
            Assert.True(eventRaised);
        }

        [Fact]
        public void SetProperty_DoesNotRaisePropertyChanged_WhenValueUnchanged()
        {
            var vm = new TestViewModel
            {
                TestProperty = "value"
            };
            bool eventRaised = false;
            ((INotifyPropertyChanged)vm).PropertyChanged += (s, e) => eventRaised = true;

            vm.TestProperty = "value"; // same value

            Assert.False(eventRaised);
        }

        [Fact]
        public void RaisePropertyChanged_ManuallyRaisesEvent()
        {
            var vm = new TestViewModel();
            bool eventRaised = false;
            ((INotifyPropertyChanged)vm).PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == nameof(TestViewModel.TestProperty))
                    eventRaised = true;
            };

            //vm.RaisePropertyChanged(nameof(TestViewModel.TestProperty));

            Assert.True(eventRaised);
        }
    }
}