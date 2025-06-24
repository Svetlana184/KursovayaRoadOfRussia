using Microsoft.EntityFrameworkCore;
using Session2.Model;
using Session2.Services;
using Session2.Utilits;
using Session2.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Session2.ViewModel
{
    public class PersonViewModel : ViewModelBase
    {
        public Employee SelectedEmployee { get; set; }
        public int SelectedDepartment { get; set; }

        public ObservableCollection<Employee> Employees { get; set; }
        public List<Calendar_> Calendars { get; set; }
        public List<Employee> EmployeeList { get; set; }
        public ObservableCollection<Event> Events { get; set; }
        public bool IsEditable { get; set; }
        public Employee SelectedBoss { get; set; }
        public Employee SelectedHelper { get; set; }

        public string VisibilityButton { get; set; }

        //поля для карточки сотрудника
        private string surname_;
        public string Surname_
        {
            get
            {
                return surname_;
            }
            set
            {
                surname_ = value;

            }
        }
        private string firstname_;
        public string Firstname_
        {
            get { return firstname_; }
            set { firstname_ = value; }
        }
        private string secondname_;
        public string Secondname_
        {
            get { return secondname_; }
            set { secondname_ = value; }
        }
        private string position_;
        public string Position_
        {
            get { return position_; }
            set { position_ = value; }
        }
        private string phonework_;
        public string Phonework_
        {
            get { return phonework_; }
            set { phonework_ = value; }
        }
        private string phone_;
        public string Phone_
        {
            get { return phone_; }
            set { phone_ = value; }
        }
        private string cabinet_;
        public string Cabinet_
        {
            get { return cabinet_; }
            set { cabinet_ = value; }
        }
        private string email_;
        public string Email_
        {
            get { return email_; }
            set { email_ = value; }
        }
        private string other_;
        public string Other_
        {
            get { return other_; }
            set { other_ = value; }
        }

        private DateOnly? birthday_;
        public DateOnly? Birthday_
        {
            get
            {
                if (birthday_ != null)
                {
                    return birthday_;
                }
                else return new DateOnly();

            }
            set
            {
                birthday_ = value;
            }
        }
        private int? bossid_;
        public int? BossId_
        {
            get
            {
                if (bossid_ != null) return (int)bossid_;
                else return null;
            }
            set { bossid_ = value; }
        }
        private int? helperid_;
        public int? HelperId_
        {
            get
            {
                if (helperid_ != null) return (int)helperid_;
                else return null;
            }
            set { helperid_ = value; }
        }

        //поля для календаря сотрудника
        public int IdCalendar
        {
            get;
            set;
        }
        private string typeofevent_;
        public string TypeOfEvent_
        {
            get { return typeofevent_; }
            set { typeofevent_ = value; }
        }
        private int? nameofstudy_;
        public int? NameOfStudy_
        {
            get
            {
                if (nameofstudy_ != null) return (int)nameofstudy_;
                else return null;
            }
            set { nameofstudy_ = value; }
        }
        private string description_;
        public string Description
        {
            get { return description_; }
            set { description_ = value; }
        }
        private int? idalternate_;
        public int? IdAlternate_
        {
            get
            {
                if (idalternate_ != null) return (int)idalternate_;
                else return null;
            }
            set { idalternate_ = value; }
        }
        private DateOnly datestart_;
        public DateOnly DateStart_
        {
            get
            {
                if (datestart_ != null)
                {
                    return datestart_;
                }
                else return new DateOnly();

            }
            set
            {
                datestart_ = value;
            }
        }
        private DateOnly datefinish_;
        public DateOnly DateFinish_
        {
            get
            {
                if (datefinish_ != null)
                {
                    return datefinish_;
                }
                else return new DateOnly();

            }
            set
            {
                datefinish_ = value;
            }
        }




        //СЕРВИСЫ
        public EmployeeService employeeService;
        public CalendarService calendarService;
        public EventService eventService;


        //КОМАНДЫ
        private RelayCommand changeEditability;
        public RelayCommand ChangeEditability
        {
            get
            {
                return changeEditability ??
                  (changeEditability = new RelayCommand((o) =>
                  {
                      if (IsEditable) IsEditable = false;
                      else IsEditable = true;
                  }));
            }
        }
        private RelayCommand addEmp;
        public RelayCommand AddEmp
        {
            get
            {
                return addEmp ??
                  (addEmp = new RelayCommand((o) =>
                  {

                  }));
            }
        }
        public PersonViewModel(Employee employee, int departmentid)
        {
            SelectedEmployee = employee;
            SelectedDepartment = departmentid;
            LoadEmpDep();
            EmployeeList = Employees!.Where(x => x.IdDepartment == SelectedDepartment && x.IdEmployee != SelectedEmployee.IdEmployee).ToList();

            List<string> strings = new List<string>() { "Обучение", "Временное отсутствие", "Отпуск" };
            List<Event> events = Events.Where(p => p.DateOfEvent >= DateTime.Now).ToList();


            if (SelectedEmployee.IdEmployee != 0)
            {
                Surname_ = SelectedEmployee.Surname;
                Firstname_ = SelectedEmployee.FirstName;
                Secondname_ = SelectedEmployee.SecondName;
                Position_ = SelectedEmployee.Position;
                Phonework_ = SelectedEmployee.PhoneWork;
                Phone_ = SelectedEmployee.Phone;
                Cabinet_ = SelectedEmployee.Cabinet;
                Email_ = SelectedEmployee.Email;
                Other_ = SelectedEmployee.Other;
                BossId_ = SelectedEmployee.IdBoss;
                HelperId_ = SelectedEmployee.IdHelper;
                Birthday_ = SelectedEmployee.BirthDay;

                IsEditable = false;



            }
            else
            {
                IsEditable = true;
                SelectedDepartment = 888;
                VisibilityButton = "Hidden";
            }
            int x = 7;

        }
        private void LoadEmpDep()
        {
            employeeService = new EmployeeService();
            eventService = new EventService();
            calendarService = new CalendarService();

            Employees = new ObservableCollection<Employee>(employeeService.GetAll());
            Events = new ObservableCollection<Event>(eventService.GetAll());
        }

        private void UpdateEvents()
        {
            Calendars = new ObservableCollection<Calendar_>(calendarService.GetAll()).Where(x => x.IdEmployee == SelectedEmployee.IdEmployee).ToList();
        }
    }
}
