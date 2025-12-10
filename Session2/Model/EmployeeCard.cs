using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Desktop.Model
{
    public class EmployeeCard : INotifyPropertyChanged
    {
        private SolidColorBrush color;
        public SolidColorBrush Color
        {
            get { return color; }
            set { color = value; OnPropertyChanged(nameof(Color)); }
        }

        private int idemployee;
        public int IdEmployee
        {
            get { return idemployee; }
            set { idemployee = value; }
        }

        private string surname = null!;

        public string Surname
        {
            get { return surname; }
            set { surname = value; OnPropertyChanged(nameof(Surname)); }
        }

        private string firstname = null!;

        public string FirstName
        {
            get { return firstname; }
            set { firstname = value; OnPropertyChanged(nameof(FirstName)); }
        }

        private string? secondName;

        public string? SecondName
        {
            get { return secondName; }
            set { secondName = value; OnPropertyChanged(nameof(SecondName)); }
        }

        private string? position;

        public string? Position
        {
            get { return position; }
            set { position = value; OnPropertyChanged(nameof(Position)); }
        }


        private string phonework = null!;

        public string PhoneWork
        {
            get { return phonework; }
            set { phonework = value; OnPropertyChanged(nameof(PhoneWork)); }
        }

        private string cabinet = null!;

        public string Cabinet
        {
            get { return cabinet; }
            set { cabinet = value; OnPropertyChanged(nameof(Cabinet)); }
        }

        private string email = null!;

        public string Email
        {
            get { return email; }
            set { email = value; OnPropertyChanged(nameof(Email)); }
        }


        private int iddepartment;

        public int IdDepartment
        {
            get { return iddepartment; }
            set { iddepartment = value; OnPropertyChanged(nameof(IdDepartment)); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
       
}
