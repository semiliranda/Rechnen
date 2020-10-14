using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Media;
using System.Windows.Input;
using Rechnen.View;
using Rechnen.Model;

namespace Rechnen.ViewModel
{
    class RechnenViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected internal void OnPropertyChanged(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }

        Zahlen _z = new Zahlen();

        private string _zahl1;
        public string Zahl1
        {
            get { return this._zahl1; }
            set
            {
                this._zahl1 = value;
                // change of UI must be caused, only when one will set fields of ViewModel to 0 
                this.OnPropertyChanged("Zahl1");
            }
        }

        private string _zahl2;
        public string Zahl2
        {
            get { return this._zahl2; }
            set
            {
                this._zahl2 = value;
                this.OnPropertyChanged("Zahl2");
            }
        }

        private string _zahlErgebnis;
        public string ZahlErgebnis
        {
            get { return this._zahlErgebnis; }
            set
            {
                this._zahlErgebnis = value;
                // cause the change of UI
                this.OnPropertyChanged("ZahlErgebnis");
            }
        }

        private SolidColorBrush _farbeVordergrund;
        public SolidColorBrush FarbeVordergrund
        {
            get { return this._farbeVordergrund; }
            set
            {
                _farbeVordergrund = value;
                // cause the change of UI
                this.OnPropertyChanged("FarbeVordergrund");
            }
        }

        // that is important for showing error messages
        private string _fehler;
        public string Fehler
        {
            get { return _fehler; }
            set
            {
                _fehler = value;
                // cause a change in UI
                this.OnPropertyChanged("Fehler");
            }
        }

        // important for commands
        private bool _canExecute = true;
        public bool CanExecute
        {
            get { return this._canExecute; }
            set
            {
                if (this._canExecute == value)
                {
                    return;
                }
                this._canExecute = value;
            }
        }

        // important for buttons
        private ICommand _additionButtonCommand;
        public ICommand AdditionButtonCommand
        {
            get { return _additionButtonCommand; }
            set { _additionButtonCommand = value; }
        }

        private ICommand _subtraktionButtonCommand;
        public ICommand SubtraktionButtonCommand
        {
            get { return _subtraktionButtonCommand; }
            set { _subtraktionButtonCommand = value; }
        }

        private ICommand _resetButtonCommand;
        public ICommand ResetButtonCommand
        {
            get { return _resetButtonCommand; }
            set { _resetButtonCommand = value; }
        }

        // important for binding on runtime
        public ViewRechnen Formular { get; set; }

        private void Addition(object obj)
        {
            try
            {
                Fehler = ""; // reset
                // give data to model
                this._z.Zahl1 = Convert.ToDecimal(Zahl1);
                this._z.Zahl2 = Convert.ToDecimal(Zahl2);
                // call method Add and convert the result into string
                ZahlErgebnis = this._z.Add().ToString();
                Farbe();
            } catch (Exception ex)
            {
                Fehler = "Fehler bei der Addition:" + Environment.NewLine + ex.Message;
                ZahlErgebnis = "Fehler!";
            }
        }

        private void Subtraktion(object obj)
        {
            try
            {
                Fehler = ""; // reset
                // give data to model
                this._z.Zahl1 = Convert.ToDecimal(Zahl1);
                this._z.Zahl2 = Convert.ToDecimal(Zahl2);
                // call method Sub and convert the result into string
                ZahlErgebnis = this._z.Sub().ToString();
                Farbe();
            }
            catch (Exception ex)
            {
                Fehler = "Fehler bei der Subtraktion:" + Environment.NewLine + ex.Message;
                ZahlErgebnis = "Fehler!";
            }
        }

        private void Reset(object obj)
        {
            Zahl1 = "0";
            Zahl2 = "0";
            ZahlErgebnis = "0";
            // Color to default
            FarbeVordergrund = Brushes.Black;
        }

        #region Hilfsmethoden
        private void Farbe()
        {
            // defauld with white background
            FarbeVordergrund = Brushes.Black;
            if (this._z.ZahlErg > 0)
            {
                FarbeVordergrund = Brushes.Green;
            }
            if (this._z.ZahlErg < 0)
            {
                FarbeVordergrund = Brushes.Red;
            }
        }
        #endregion

        // Constructor
        public RechnenViewModel()
        {
            // methods for user actions
            _additionButtonCommand = new RelayCommand(Addition, param => this._canExecute);
            _subtraktionButtonCommand = new RelayCommand(Subtraktion, param => this._canExecute);
            _resetButtonCommand = new RelayCommand(Reset, param => this._canExecute);
            // <--

            _zahl1 = "0"; // set default values is (optional)
            _zahl2 = "0";
            _zahlErgebnis = "0";
        }
    }
}
