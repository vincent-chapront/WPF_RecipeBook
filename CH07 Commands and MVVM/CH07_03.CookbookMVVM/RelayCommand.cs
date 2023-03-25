﻿using System;
using System.Windows.Input;

namespace CH07_03.CookbookMVVM
{
    public class RelayCommand : RelayCommand<object>
    {
        public RelayCommand(Action execute, Func<bool> canExecute = null) : base(obj => execute(), (canExecute == null ? null : new Func<object, bool>(obj => canExecute())))
        {
        }
    }

    public class RelayCommand<T> : ICommand
    {
        private readonly Func<T, bool> _canExecute;

        private readonly Action<T> _execute;

        public RelayCommand(Action<T> execute, Func<T, bool> canExecute = null)
        {
            if (execute == null)
            {
                throw new ArgumentNullException(nameof(execute));
            }
            _execute = execute;
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                if (_canExecute != null)
                {
                    CommandManager.RequerySuggested += value;
                }
            }
            remove
            {
                if (_canExecute != null)
                {
                    CommandManager.RequerySuggested -= value;
                }
            }
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute?.Invoke(TranslateParameter(parameter))??true;
        }

        public void Execute(object parameter)
        {
            _execute(TranslateParameter(parameter));
        }

        private static bool CanExecute(T paramter)
        {
            return true;
        }

        private T TranslateParameter(object parameter)
        {
            T value = default(T);
            if (parameter != null && typeof(T).IsEnum)
            {
                value = (T)Enum.Parse(typeof(T), (string)parameter);
            }
            else
            {
                value = (T)parameter;
            }
            return value;
        }
    }
}