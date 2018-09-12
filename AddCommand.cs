using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AddEditDeleteDBMVVM
{
    public class AddCommand : ICommand
    {
        private ViewModel VM;

        PersonEntities DB = new PersonEntities();

        public AddCommand(ViewModel VM)
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
            VM.AddPerson();
            

        }
    }
}
