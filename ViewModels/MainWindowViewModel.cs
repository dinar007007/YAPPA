using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using Avalonia.Controls;
using Avalonia.Threading;
using NetCoreAudio;
using ReactiveUI;
using SharpDX.Direct2D1;
using YAAPA.Models;
using YAAPA.Services;
using YAPPA.Views;

namespace YAAPA.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel(Storage storage)
        {
            Tomatoes = new ObservableCollection<Tomato>(storage.GetItems());
            _dispatcherTimer = new DispatcherTimer(TimeSpan.FromSeconds(1), DispatcherPriority.Normal, TimerTick);
        }

        public ObservableCollection<Tomato> Tomatoes { get; }

        public string StartButtonLabel
        {
            get => _startButtonLabel;
            private set => this.RaiseAndSetIfChanged(ref _startButtonLabel, value);
        }

        public string Timer
        {
            get => _timer;
            private set => this.RaiseAndSetIfChanged(ref _timer, value);
        }

        public int CountTomato
        {
            get => _countTomato;
            private set => this.RaiseAndSetIfChanged(ref _countTomato, value);
        }

        private string _startButtonLabel = "Start";
        private string _timer;
        private DispatcherTimer _dispatcherTimer;
        private int _seconds;
        private const int _durationTomato = 1500;
        private Player _player = new Player();

        private int _countTomato;

        private void TimerTick(object sender, EventArgs e)
        {
            if (_seconds >= _durationTomato)
            {
                _seconds = 0;
                Timer = _seconds.ToString();
                CountTomato++;
                StartButtonLabel = "Start";
                _dispatcherTimer.IsEnabled = false;
                _player?.Play(@"C:\Dev\YAAPA\YAAPA\Assets\ding.wav");
                return;
            }
            _seconds++;
            Timer = _seconds.ToString();
        }

        public void StartButtonAction()
        {
            _dispatcherTimer.IsEnabled = !_dispatcherTimer.IsEnabled;
            StartButtonLabel = _dispatcherTimer.IsEnabled ? "Stop" : "Start";
        }

        public void OpenSettings()
        {
            var settingsWindow = new Settings();
            settingsWindow.Show();
        }

    }
}
