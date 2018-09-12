using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AddEditDeleteDBMVVM
{
    public class UpdateCommand : ICommand
    {
        private ViewModel VM;

        public UpdateCommand(ViewModel VM)
        {
            this.VM = VM;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            VM.UpdatePerson();
        }
    }
}
