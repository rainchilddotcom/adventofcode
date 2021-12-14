using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _8
{
    /// <summary>
    /// Interaction logic for Digit.xaml
    /// </summary>
    public partial class Digit : UserControl, INotifyPropertyChanged
    {
        public Digit()
        {
            InitializeComponent();
        }

        private string _signal;
        public string Signal
        {
            get
            {
                return _signal;
            }
            set
            {
                _signal = value;
                NotifyPropertyChanged();
            }
        }

        public char SignalDigit
        {
            get
            {
                return ' ';
            }
            set
            {
                Signal = LookupSignal(value);
            }
        }

        public string LookupSignal(char value)
        {
            switch (value)
            {
                case '0':
                    return "abcefg";
                case '1':
                    return "cf";
                case '2':
                    return "acdeg";
                case '3':
                    return "acdfg";
                case '4':
                    return "bcdf";
                case '5':
                    return "abdfg";
                case '6':
                    return "abdefg";
                case '7':
                    return "acf";
                case '8':
                    return "abcdefg";
                case '9':
                    return "abcdfg";
                default:
                    throw new NotSupportedException("can't display character: " + value);
            }
        }

        private bool CheckVisibility(char signalToCheck)
        {
            return Signal?.Contains(signalToCheck) == true;
        }

        public bool SignalA
        {
            get { return CheckVisibility('a'); }
        }

        public bool SignalB
        {
            get { return CheckVisibility('b'); }
        }

        public bool SignalC
        {
            get { return CheckVisibility('c'); }
        }

        public bool SignalD
        {
            get { return CheckVisibility('d'); }
        }

        public bool SignalE
        {
            get { return CheckVisibility('e'); }
        }

        public bool SignalF
        {
            get { return CheckVisibility('f'); }
        }

        public bool SignalG
        {
            get { return CheckVisibility('g'); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SignalA)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SignalB)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SignalC)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SignalD)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SignalE)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SignalF)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SignalG)));
        }
    }
}
