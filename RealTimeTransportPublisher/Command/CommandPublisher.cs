using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace RealTimeTransportPublisher.Command
{
    class CommandPublisher : ICommand
    {
        Action<object> _execute;
        Func<object, bool> _canExecute;
        public CommandPublisher(Action<object> _excute, Func<object, bool> _canExecute)
        {
            this._execute = _excute;
            this._canExecute = _canExecute;

            }
        event EventHandler ICommand.CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; } // cela permet de donner un comportement au canExecute
            remove { CommandManager.RequerySuggested -= value; }
        }

        bool ICommand.CanExecute(object parameter)// endroid ou on verifie si operation peut sexecuter
        {
            return this._canExecute(parameter);
                
                    
        }

        void ICommand.Execute(object parameter)// endroid ou on mettre le code (en ^paramettre un objet
        {
            //MessageBox.Show("ca marche?");
            this._execute(parameter);
        }

        
    }
}
