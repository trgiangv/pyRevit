using System;
using System.Windows;
using System.Windows.Controls;
using UserControl = System.Windows.Controls.UserControl;

namespace pyRevitLabs.CommonWPF.Controls
{
    /// <summary>
    /// Interaction logic for LabelledTextBox.xaml
    /// </summary>
    public partial class LabelledTextBox : UserControl
    {
        public static readonly DependencyProperty LabelProperty =
            DependencyProperty.Register("Label", typeof(string), typeof(LabelledTextBox),
                                        new FrameworkPropertyMetadata(string.Empty));

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(LabelledTextBox),
                                        new FrameworkPropertyMetadata(string.Empty));


        public LabelledTextBox()
        {
            InitializeComponent();
        }

        public LabelledTextBox(string label)
        {
            InitializeComponent();
            Label = label;
        }

        public string Label
        {
            get => GetValue(LabelProperty) as String;
            set => SetValue(LabelProperty, value);
        }

        public string Text
        {
            get => GetValue(TextProperty) as String;
            set => SetValue(TextProperty, value);
        }
    }
}
