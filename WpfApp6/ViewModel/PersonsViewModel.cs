using System.ComponentModel;
using System.Linq;
using System.Collections.ObjectModel;
using WpfApp6.Model;
using WpfApp6.Utils;
using System.Windows.Forms;
using System.Windows.Input;
using System.Drawing;
using System.Windows.Media.Imaging;
using System;
using System.IO;
using System.Threading.Tasks;

namespace WpfApp6.ViewModel
{
    class PersonsViewModel : INotifyPropertyChanged
    {
        public PersonsViewModel()
        {
            DB.Connection(this);
            SaveDiractory = new DelegateCommand(LoadSaveDiractory);
            SexContent = new ObservableCollection<string>
            {
                "male",
                "female"
            };
        }

        public ObservableCollection<string> SexContent { get; private set; }

        private Person personforAdd = new Person();
        public Person PersonForAdd
        {
            get { AddPersonCommand.RaiseCanExecuteChanged(); return personforAdd;  }
            set { personforAdd = value; OnPropertyChanged("PersonForAdd"); }
        }
        private ObservableCollection<Person> persons = new ObservableCollection<Person>();
        public ObservableCollection<Person> Persons
        {
            get { return persons; }
            set { persons = value; OnPropertyChanged("Persons"); }
        }
        private Person selected;
        public Person Selected
        {
            get { return selected; }
            set { selected = value; OnPropertyChanged("Selected"); RemovePersonCommand.RaiseCanExecuteChanged(); SaveChanges.RaiseCanExecuteChanged(); }
        }
        private DelegateCommand removePersonCommand;
        public DelegateCommand RemovePersonCommand
        {
            get
            {
                return removePersonCommand ?? (removePersonCommand = new DelegateCommand(RemovePerson, CanRemovePerson));
            }
        }

        private void RemovePerson(object args)
        {
            DB.DeleteFormDb(Selected.Id);
            persons.Remove(Selected);
        }

        private bool CanAddPerson(object args)
        {
            if (personforAdd == null)
                return false;
            else if (personforAdd.Login == null || personforAdd.Pass == null || personforAdd.FirstName == null)
                return false;
            return true;
        }

        private bool CanRemovePerson(object args)
        {
            if (Selected == null)
                return false;
            var person = FindPerson(Selected);
            if (person == null)
                return false;
            return true;
        }
        private void AddNewPerson(object arg)
        {
            Persons.Add(PersonForAdd);
            DB.AddNew(PersonForAdd);
            PersonForAdd = new Person();
        }
        private DelegateCommand addPersonCommand;
        public DelegateCommand AddPersonCommand
        {
            get
            {
                return addPersonCommand ?? (addPersonCommand = new DelegateCommand(AddNewPerson,CanAddPerson));
            }
        }
        private void SaveChangesToBD(object args)
        {
            DB.SaveChanges(Selected);
        }
        private DelegateCommand saveChanges;
        public DelegateCommand SaveChanges
        {
            get
            {
                return saveChanges ?? (saveChanges = new DelegateCommand(SaveChangesToBD, CanRemovePerson));
            }
        }
        #region Private Methods
        private Person FindPerson(Person findperson)
        {
            if (findperson == null)
                return null;
            return persons.FirstOrDefault(person => person.Id == findperson.Id);
        }
        #endregion
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string param)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(param));
        }
        #region ForPhoto
        
        public ICommand SaveDiractory { get; set; }

        private void LoadSaveDiractory(object parameter)
        {
            System.Windows.Forms.OpenFileDialog browse = new System.Windows.Forms.OpenFileDialog();
            if (browse.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Savepath = browse.FileName;
            }
            
            OnPropertyChanged("LoadSaveDiractory");
        }
        
        private string savepath = "";
        public string Savepath
        {
            get { return savepath; }
            set
            {
                savepath = value;
                if (ImageProcess.ImageFromPath(savepath, personforAdd, selected))
                {
                    OnPropertyChanged("savepath"); OnPropertyChanged("Image");
                }
            }
        }
        
        #endregion
    }

}
