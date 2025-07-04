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
        public static readonly DependencyProperty ErrorProperty =
            DependencyProperty.Register(nameof(Error), typeof(string), typeof(ValidatedField), new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty ErrorPositionProperty =
            DependencyProperty.Register(nameof(ErrorPosition), typeof(ErrorPosition), typeof(ValidatedField), new PropertyMetadata(ErrorPosition.Bottom));

        public static readonly DependencyProperty FieldContentProperty =
            DependencyProperty.Register(nameof(FieldContent), typeof(object), typeof(ValidatedField), new PropertyMetadata(null));

        public string Error
        {
            get => (string)GetValue(ErrorProperty);
            set => SetValue(ErrorProperty, value);
        }

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

        public ValidatedField()
        {
            InitializeComponent();
        }
    }
}