using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace PMS.Views.Controls
{
    public enum ErrorPosition
    {
        Bottom,
        Top,
        Left,
        Right
    }

    public partial class ValidatedField : UserControl
    {
        public string? Error
        {
            get
            {
                // If Error is set, use it; otherwise, try to get from DataContext
                var value = (string)GetValue(ErrorProperty);
                if (!string.IsNullOrEmpty(value))
                    return value;

                // Try to get error from DataContext (assuming INotifyDataErrorInfo or IDataErrorInfo)
                if (DataContext is IDataErrorInfo dataErrorInfo && !string.IsNullOrEmpty(BoundPropertyName))
                    return dataErrorInfo[BoundPropertyName];

                return null;
            }
            set => SetValue(ErrorProperty, value);
        }

        public static readonly DependencyProperty ErrorProperty =
            DependencyProperty.Register(
                nameof(Error),
                typeof(string),
                typeof(ValidatedField),
                new PropertyMetadata(null));

        public static readonly DependencyProperty ErrorPositionProperty =
            DependencyProperty.Register(nameof(ErrorPosition), typeof(ErrorPosition), typeof(ValidatedField), new PropertyMetadata(ErrorPosition.Bottom));

        public static readonly DependencyProperty FieldContentProperty =
            DependencyProperty.Register(nameof(FieldContent), typeof(object), typeof(ValidatedField), new PropertyMetadata(null));

        public static readonly DependencyProperty BoundPropertyNameProperty =
            DependencyProperty.Register(
                nameof(BoundPropertyName),
                typeof(string),
                typeof(ValidatedField),
                new PropertyMetadata(null));

        public ErrorPosition ErrorPosition
        {
            get => (ErrorPosition)GetValue(ErrorPositionProperty);
            set => SetValue(ErrorPositionProperty, value);
        }

        public object FieldContent
        {
            get => GetValue(FieldContentProperty);
            set => SetValue(FieldContentProperty, value);
        }

        public string BoundPropertyName
        {
            get => (string)GetValue(BoundPropertyNameProperty);
            set => SetValue(BoundPropertyNameProperty, value);
        }

        public ValidatedField()
        {
            InitializeComponent();
            DataContextChanged += OnDataContextChanged;
        }

        private void OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (e.OldValue is INotifyPropertyChanged oldNotify)
                oldNotify.PropertyChanged -= OnBoundPropertyChanged;
            if (e.NewValue is INotifyPropertyChanged newNotify)
                newNotify.PropertyChanged += OnBoundPropertyChanged;
            UpdateError();
        }

        private void OnBoundPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == BoundPropertyName)
                UpdateError();
        }

        private void UpdateError()
        {
            if (DataContext is IDataErrorInfo dataErrorInfo && !string.IsNullOrEmpty(BoundPropertyName))
                SetValue(ErrorProperty, dataErrorInfo[BoundPropertyName]);
            else
                SetValue(ErrorProperty, null);
        }
    }
}