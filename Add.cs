using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AddEditDeleteDBMVVM
{
    public class Add : ICommand
    {
        private ViewModel VM;

        public event EventHandler CanExecuteChanged; 

        public Add(ViewModel VM)
        {
            this.VM = VM;

        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            AddPage addPage = new AddPage();
            
            addPage.DataContext = VM;
            addPage.ShowDialog();
            //VM.FillDataGrid();
        }
    }
}
