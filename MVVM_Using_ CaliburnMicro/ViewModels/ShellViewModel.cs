using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using MVVM_Using__CaliburnMicro.Models;

namespace MVVM_Using__CaliburnMicro.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        private string _firstName = "Misa";
        private string _lastname;
        private PersonModel _selectedPerson;
        private BindableCollection<PersonModel> _people = new BindableCollection<PersonModel>();

        public ShellViewModel()
        {
            People.Add(new PersonModel(){FirstName = "Misa",LastName = "Novaku"});
            People.Add(new PersonModel() { FirstName = "Petr", LastName = "Povak" });
            People.Add(new PersonModel() { FirstName = "Monika", LastName = "Mala" });
            People.Add(new PersonModel() { FirstName = "Jorge", LastName = "Pico" });

        }

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value;
                NotifyOfPropertyChange(() => FirstName);
                NotifyOfPropertyChange((() => FullName));
                }
        }

        public string LastName { get { return _lastname; } set { _lastname = value;NotifyOfPropertyChange((() => _lastname)); NotifyOfPropertyChange((() => FullName)); } }

        public string FullName => $"{FirstName} {LastName}";



        public BindableCollection<PersonModel> People
        {
            get { return _people; }
            set { _people = value; }
        }

        public PersonModel SelectedPerson
        {
            get { return _selectedPerson; }
            set
            {
                _selectedPerson = value;
                NotifyOfPropertyChange((() => SelectedPerson));
            }
        }

        public bool CanClearText(string f, string l)
        {
            return !string.IsNullOrWhiteSpace(f) && !string.IsNullOrWhiteSpace(l);
        }

        public void ClearText(string f, string l)
        {
            FirstName = "";
            LastName = "";
        }

        public void LoadPageOne()
        {
            ActivateItem(new FirstChildViewModel());
        }

        public void LoadPageTwo()
        {
            ActivateItem(new SecondChildViewModel());
        }
    }
}
