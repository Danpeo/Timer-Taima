using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using AsyncAwaitBestPractices.MVVM;
using timer_mvvm_test.Commands;

namespace timer_mvvm_test
{
    public class TimerViewModel : INotifyPropertyChanged
    {
        private readonly TimerModel _timerModel;
        private readonly System.Windows.Threading.DispatcherTimer _dispatcherTimer;

        public event PropertyChangedEventHandler? PropertyChanged;

        private int _hours;
        public int Hours
        {
            get => _hours;
            set
            {
                if (_hours != value && value >= 0)
                {
                    _hours = value >= 99 ? 99 : value;

                    OnPropertyChanged(nameof(Hours));
                }
            }
        }

        private int _minutes;
        public int Minutes
        {
            get => _minutes;
            set
            {
                if (_minutes != value && value >= 0)
                {
                    if (value >= 60)
                    {
                        Hours++;
                        _minutes = 0;
                    }
                    else
                        _minutes = value;

                    OnPropertyChanged(nameof(Minutes));
                }
            }
        }

        private int _seconds;
        public int Seconds
        {
            get => _seconds;
            set
            {
                if (_seconds != value && value >= 0)
                {
                    if (value >= 60)
                    {
                        Minutes++;
                        _seconds = 0;
                    }
                    else
                        _seconds = value;

                    OnPropertyChanged(nameof(Seconds));
                }
            }
        }

        private int _totalSeconds;
        public int TotalSeconds
        {
            get => _totalSeconds;
            set
            {
                if (_totalSeconds != value)
                {
                    _totalSeconds = value;
                    OnPropertyChanged(nameof(TotalSeconds));
                }
            }
        }

        private string? _tickUntilTime;
        public string? TickUntilTime
        {
            get => _tickUntilTime;
            set
            {
                if (_tickUntilTime != value)
                {
                    _tickUntilTime = value;
                    OnPropertyChanged(nameof(TickUntilTime));
                }
            }
        }

        private bool _isRunning;
        public bool IsRunning
        {
            get => _isRunning;
            set
            {
                if (_isRunning != value)
                {
                    _isRunning = value;
                    OnPropertyChanged(nameof(IsRunning));
                }
            }
        }
        private string _currentToggleButtonContent = "Start";
        public string CurrentToggleButtonContent
        {
            get => _currentToggleButtonContent;
            set
            {
                if (_currentToggleButtonContent != value)
                {
                    _currentToggleButtonContent = value;
                    OnPropertyChanged(nameof(CurrentToggleButtonContent));
                }
            }
        }

        private string _timeIsUpText = string.Empty;
        public string TimeIsUpText
        {
            get => _timeIsUpText;
            set
            {
                if (_timeIsUpText != value)
                {
                    _timeIsUpText = value;
                    OnPropertyChanged(nameof(TimeIsUpText));
                }
            }
        }

        public ICommand StartPauseCommand { get; private set; }
        public ICommand ResetCommand { get; private set; }
        public ICommand ShowMainWindowCommand { get; private set; }


        public TimerViewModel()
        {
            _timerModel = new TimerModel();
            _dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            _dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
            _dispatcherTimer.Tick += DispatcherTimer_Tick;

            Hours = Properties.Settings.Default.LastTimeHours;
            Minutes = Properties.Settings.Default.LastTimeMinutes;
            Seconds = Properties.Settings.Default.LastTimeSeconds;

            StartPauseCommand = new RelayCommand(StartPauseTimer);
            ResetCommand = new RelayCommand(ResetTimer);
            ShowMainWindowCommand = new RelayCommand(ShowMainWindow);
        }

        private void ShowMainWindow()
        {
            MainWindow.Instance?.Show();
            Debug.Assert(MainWindow.Instance != null, "MainWindow.Instance != null");
            MainWindow.Instance.WindowState = WindowState.Normal;
        }


        private void DispatcherTimer_Tick(object? sender, EventArgs e)
        {
            _timerModel.Tick();
            if (!_timerModel.IsTimerRunning())
            {
                ResetTimer();
            }

            Hours = _timerModel.Hours;
            Minutes = _timerModel.Minutes;
            Seconds = _timerModel.Seconds;
            TotalSeconds = _timerModel.TotalSeconds;

            TickUntilTime = DateTime.Now.AddSeconds(TotalSeconds).ToString(CultureInfo.CurrentCulture);

            if (TotalSeconds <= 0)
            {
                TimeIsUpText = "タイムアップ!!!";
                MusicPlayer.PlaySound("final-fantasy-prelude.wav");
            }
        }

        private void StartPauseTimer()
        {
            if (IsRunning)
            {
                StopTimer();
            }
            else
            {
                StartTimer();

            }
        }

        private void StartTimer()
        {
            _timerModel.SetTime(Hours, Minutes, Seconds);
            
            Properties.Settings.Default.LastTimeSeconds = Seconds;
            Properties.Settings.Default.LastTimeMinutes = Minutes;
            Properties.Settings.Default.LastTimeHours = Hours;

            Properties.Settings.Default.Save();

            if (!_timerModel.IsTimerRunning())
            {
                return;
            }

            IsRunning = true;

            CurrentToggleButtonContent = "Pause";

            _dispatcherTimer.Start();
        }

        private void StopTimer()
        {
            IsRunning = false;
            CurrentToggleButtonContent = "Start";
            _dispatcherTimer.Stop();
            TickUntilTime = string.Empty;
        }

        private void ResetTimer()
        {
            StopTimer();

            Hours = Properties.Settings.Default.LastTimeHours;
            Minutes = Properties.Settings.Default.LastTimeMinutes;
            Seconds = Properties.Settings.Default.LastTimeSeconds;

            TimeIsUpText = string.Empty;

            MusicPlayer.StopSound();
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
