using System.Windows;
using System.Windows.Input;

namespace WPFhanoi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void cmd_Exit(object sender, ExecutedRoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        public void cmd_CanExit(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
}
}