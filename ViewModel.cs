using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AddEditDeleteDBMVVM
{
    public class ViewModel : DependencyObject, INotifyPropertyChanged
    {
        PersonEntities DB = new PersonEntities();

        public Add addButton { get; set; }
        public AddCommand addCommand { get; set; }
        public Update updateButton { get; set; }
        public UpdateCommand updateCommand { get; set; }
        public DeleteCommand deleteCommand { get; set; }

        public ViewModel()
        {
            FillDataGrid();
            this.addButton = new Add(this);
            this.addCommand = new AddCommand(this);
            this.deleteCommand = new DeleteCommand(this);
            this.updateButton = new Update(this);
            this.updateCommand = new UpdateCommand(this);
        }

        public void FillDataGrid()
        {
            var query = (from x in DB.Person select x).ToList();

            this.PersonList = query;
   
        }

        public static readonly DependencyProperty IdProperty =
           DependencyProperty.Register("Id",
           typeof(int), typeof(ViewModel),
           new UIPropertyMetadata(0));

        public static readonly DependencyProperty FirstNameProperty =
            DependencyProperty.Register("FirstName",
            typeof(string),
            typeof(ViewModel),
            new UIPropertyMetadata());

        public static readonly DependencyProperty LastNameProperty =
           DependencyProperty.Register("LastName",
           typeof(string),
           typeof(ViewModel),
           new UIPropertyMetadata());

        public static readonly DependencyProperty AgeProperty =
            DependencyProperty.Register("Age",
            typeof(int), typeof(ViewModel),
            new UIPropertyMetadata(0));

        public int Id
        {
            get { return (int)GetValue(IdProperty); }
            set { SetValue(IdProperty, value); onPropertyChanged("Id"); }
        }

        public string FirstName
        {
            get { return (string)GetValue(FirstNameProperty); }
            set { SetValue(FirstNameProperty, value); onPropertyChanged("FirstName"); }
        }

        public string LastName
        {
            get { return (string)GetValue(LastNameProperty); }
            set { SetValue(LastNameProperty, value); onPropertyChanged("LastName"); }
        }

        public int Age
        {
            get { return (int)GetValue(AgeProperty); }
            set { SetValue(AgeProperty, value); onPropertyChanged("Age"); }
        }


        private List<Person> _personList;
        public List<Person> PersonList
        {
            get
            {
                return _personList;
            }
            set
            {
                _personList = value;
                onPropertyChanged("Id");
                onPropertyChanged("FirstName");
                onPropertyChanged("LastName");
                onPropertyChanged("Age");
                onPropertyChanged("PersonList");
            }
        }

        //private ObservableCollection<Person> _personList;
        //public ObservableCollection<Person> PersonList
        //{
        //    get
        //    {
        //        return _personList;
        //    }
        //    set
        //    {
        //        _personList = value;
        //        onPropertyChanged("PersonList");
        //    }
        //}

        public event PropertyChangedEventHandler PropertyChanged;

        private void onPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public void AddPerson()
        {
            int id = this.Id;
            string firstName = this.FirstName;
            string lastName = this.LastName;
            int age = this.Age;

            Person newPerson = new Person()
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
                Age = age
            };

            DB.Person.Add(newPerson);
            DB.SaveChanges();
            FillDataGrid();

            Id = 0;
            FirstName = "";
            LastName = "";
            Age = 0;

        }

        public void DeletePerson(System.Windows.Controls.DataGrid Record)
        {
            int id = (Record.SelectedItem as Person).Id;

            var deleteMember = DB.Person.Where(m => m.Id == id).Single();
            DB.Person.Remove(deleteMember);
            DB.SaveChanges();
            FillDataGrid();
            //myDataGrid.ItemsSource = DB.members.ToList();


        }

        public void UpdatePerson()
        {
            int id = this.Id;
            string firstName = this.FirstName;
            string lastName = this.LastName;
            int age = this.Age;

            Person updatePerson = (from m in DB.Person
                                   where m.Id == id
                                   select m).Single();

            updatePerson.Id = id;
            updatePerson.FirstName = firstName;
            updatePerson.LastName = lastName;
            updatePerson.Age = age;
            
            DB.SaveChanges();
            FillDataGrid();

            Id = 0;
            FirstName = "";
            LastName = "";
            Age = 0;

        }
    }
}

