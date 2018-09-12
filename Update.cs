using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AddEditDeleteDBMVVM
{
    public class Update : ICommand
    {
        private ViewModel VM;

        public Update(ViewModel VM)
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
            UpdatePage updatePage = new UpdatePage();

            updatePage.DataContext = VM;
            updatePage.ShowDialog();
        }
    }
}
