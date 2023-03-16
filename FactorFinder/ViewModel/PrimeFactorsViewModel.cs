using FactorFinder.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FactorFinder.ViewModel
{
    public class PrimeFactorsViewModel : INotifyPropertyChanged
    {
        #region Private Fields
        private string _result;
        private readonly IPrimeModel _primeModel;
        private ICommand _calculatePrimesCommand;
        #endregion

        #region Constructor
        public PrimeFactorsViewModel(IPrimeModel primeModel)
        {
            _primeModel = primeModel;
            _result = string.Empty;
        }
        #endregion

        #region Public Properties
        public int Number { get; set; }

        public string Result
        {
            get { return _result; }
            set 
            {
                _result = value;
                OnPropertyChanged("Result");
            }
        }
 
        public ICommand CalculatePrimesCommand
        {
            get
            {
                return _calculatePrimesCommand ?? (_calculatePrimesCommand = new CommandHandler(() => CalculatePrimes(), () => CanExecuteCalculatePrimes));
            }
        }
        public bool CanExecuteCalculatePrimes
        {
            get
            {
                return true;
            }
        }
        #endregion

        #region Public Methods
        public void CalculatePrimes()
        {
            _primeModel.Number = Number;
            _primeModel.CalculatePrimeFactors();
            if (_primeModel.PrimeFactors.Count() == 1)
            {
                Result = $"{Number} is a prime number.";
            }
            else
            {
                Result = $"The prime factors of {Number} are {string.Join(",", _primeModel.PrimeFactors)}. This was determined using the {_primeModel.PrimeDeriver.Name} method.";
            }
        }
        #endregion

        #region PropertyChanged Event
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }

    #region CommandHandler
    public class CommandHandler : ICommand
    {
        private readonly Action _action;
        private readonly Func<bool> _canExecute;

        public CommandHandler(Action action, Func<bool> canExecute)
        {
            _action = action;
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute.Invoke();
        }

        public void Execute(object parameter)
        {
            _action();
        }
    }
    #endregion
}
