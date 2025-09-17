using System.ComponentModel;
using System.Runtime.CompilerServices;
using PMS.Config;
using PMS.Models;
using PMS.ViewModels.DataBase;

namespace PMS.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        protected static DatabaseConfig? AppConfig { get; private set; }
        protected static DataBase<PatientData>? PatientDb { get; private set; }

        static ViewModelBase()
        {
            // Load config once for all ViewModels
            AppConfig = DatabaseConfig.Load("Config/Config.xml");
            if (AppConfig != null)
            {
                PatientDb = new DataBase<PatientData>(
                    AppConfig.ConnectionString,
                    AppConfig.DatabaseName,
                    AppConfig.CollectionName
                );
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void RaisePropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
        {
            if (Equals(field, value))
                return false;
            field = value;
            RaisePropertyChanged(propertyName);
            return true;
        }
    }
}