﻿using System;
using System.Windows.Input;

namespace ToDoList.Core
{
    internal class DelegateCommand : ICommand
    {
        Action<object> execute;
        Func<object, bool> canExecute;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value;}
            remove { CommandManager.RequerySuggested -= value; }
        }
        public bool CanExecute(object parameter)
        {
           if(canExecute != null)
               return canExecute(parameter);
           return true;

        }

        public void Execute(object parameter)
        {
            execute(parameter);
        }

        public DelegateCommand(Action<object> executeAction) : this(executeAction, null) { }

        public DelegateCommand(Action<object> executeAction, Func<object, bool> canExecuteFunc)
        {
            canExecute = canExecuteFunc;
            execute = executeAction;
        }

    }
}
