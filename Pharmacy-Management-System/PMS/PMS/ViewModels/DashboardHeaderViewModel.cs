using PMS.ViewModels;
using System.Windows.Input;

public class DashboardHeaderViewModel : ViewModelBase
{
    public ICommand AddCommand { get; }
    public ICommand ExitCommand { get; }
    public ICommand RefreshCommand { get; }

    public DashboardHeaderViewModel()
    {
        AddCommand = new RelayCommand<object>(_ => AddRecord());
        ExitCommand = new RelayCommand<object>(_ => System.Windows.Application.Current.Shutdown());
        RefreshCommand = new RelayCommand<object>(_ => Refresh());
    }

    private static void AddRecord()
    {
        // About to implement the Add Record from Database when implementing the database.
    }

    private static void Refresh()
    {
        // About to implement the Refresh Logic.
    }
}