using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using timer_mvvm_test.Classes;
using static System.Net.Mime.MediaTypeNames;
using Color = System.Windows.Media;
using MessageBox = System.Windows.MessageBox;

namespace timer_mvvm_test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TimerViewModel? _vm;
        private bool _canClose;
        private readonly SolidColorBrush _defaultColor;
        private readonly SolidColorBrush _selectedTimeTextColor = new(Color.Color.FromArgb(255, 238, 66, 94));

        public static MainWindow? Instance { get; private set; }


        public MainWindow()
        {
            InitializeComponent();
            Instance = this;

            _defaultColor = (SolidColorBrush)TimeSecondsTextBlock.Foreground;
            taskbarIcon.Icon = new System.Drawing.Icon(PathManager.GetRelativePath("Images", "2.ico"));

        }


        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = !_canClose;
            Hide();
        }

        private void TrayMouseDoubleClick(object sender, EventArgs e)
        {

            InitializeViewModel();

            _vm?.ShowMainWindowCommand.Execute(null);

        }

        private void taskbarIcon_TrayMouseDoubleClick(object sender, RoutedEventArgs e)
        {
            _canClose = true;
            Close();
        }

        private void TimeHoursTextBlock_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            InitializeViewModel();

            if (e.Delta > 0)
            {
                Debug.Assert(_vm != null, nameof(_vm) + " != null");
                _vm.Hours++;
            }
            else if (e.Delta < 0)
            {
                Debug.Assert(_vm != null, nameof(_vm) + " != null");
                _vm.Hours--;
            }
        }

        private void TimeMinutesTextBlock_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            InitializeViewModel();

            if (e.Delta > 0)
            {
                Debug.Assert(_vm != null, nameof(_vm) + " != null");
                _vm.Minutes++;
            }
            else if (e.Delta < 0)
            {
                Debug.Assert(_vm != null, nameof(_vm) + " != null");
                _vm.Minutes--;
            }
        }

        private void TimeSecondsTextBlock_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            InitializeViewModel();

            if (e.Delta > 0)
            {
                Debug.Assert(_vm != null, nameof(_vm) + " != null");
                _vm.Seconds++;
            }
            else if (e.Delta < 0)
            {
                Debug.Assert(_vm != null, nameof(_vm) + " != null");
                _vm.Seconds--;
            }
            e.Handled = true;
        }

        private void InitializeViewModel()
        {

            _vm = DataContext as TimerViewModel;

            if (_vm == null) return;
        }

        private void TimeSecondsTextBlock_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            TimeSecondsTextBlock.Foreground = _selectedTimeTextColor;
        }

        private void TimeSecondsTextBlock_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            TimeSecondsTextBlock.Foreground = _defaultColor;
        }

        private void TimeMinutesTextBlock_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            TimeMinutesTextBlock.Foreground = _selectedTimeTextColor;

        }

        private void TimeMinutesTextBlock_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            TimeMinutesTextBlock.Foreground = _defaultColor;
        }

        private void TimeHoursTextBlock_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            TimeHoursTextBlock.Foreground = _defaultColor;
        }

        private void TimeHoursTextBlock_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            TimeHoursTextBlock.Foreground = _selectedTimeTextColor;
        }
    }
}
