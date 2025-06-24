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
                OnPropertyChanged(nameof(Surname_));

            }
        }
        private string firstname_;
        public string Firstname_
        {
            get { return firstname_; }
            set { 
                firstname_ = value;
                OnPropertyChanged(nameof(Firstname_));
            }
        }
        private string secondname_;
        public string Secondname_
        {
            get { return secondname_; }
            set { secondname_ = value; OnPropertyChanged(nameof(Secondname_)); }
        }
        private string position_;
        public string Position_
        {
            get { return position_; }
            set { position_ = value; OnPropertyChanged(nameof(Position_)); }
        }
        private string phonework_;
        public string Phonework_
        {
            get { return phonework_; }
            set { phonework_ = value; OnPropertyChanged(nameof(Phonework_)); }
        }
        private string phone_;
        public string Phone_
        {
            get { return phone_; }
            set { phone_ = value; OnPropertyChanged(nameof(Phone_)); }
        }
        private string cabinet_;
        public string Cabinet_
        {
            get { return cabinet_; }
            set { cabinet_ = value; OnPropertyChanged(nameof(Cabinet_)); }
        }
        private string email_;
        public string Email_
        {
            get { return email_; }
            set { email_ = value; OnPropertyChanged(nameof(Email_)); }
        }
        private string other_;
        public string Other_
        {
            get { return other_; }
            set { other_ = value; OnPropertyChanged(nameof(Other_)); }
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
                OnPropertyChanged(nameof(Birthday_));
            }
        }
        private Employee? bossid_;
        public Employee? BossId_
        {
            get
            {
                if (bossid_ != null) return bossid_;
                else return null;
            }
            set { bossid_ = value; OnPropertyChanged(nameof(BossId_)); }
        }
        private Employee? helperid_;
        public Employee? HelperId_
        {
            get
            {
                if (helperid_ != null) return helperid_;
                else return null;
            }
            set { helperid_ = value; OnPropertyChanged(nameof(HelperId_)); }
        }

        //поля для календаря сотрудника

        public List<Calendar_> StudyList { get; set; }
        public List<Calendar_> SkipList { get; set; }
        public List<Calendar_> VacationList { get; set; }
        public int IdCalendar
        {
            get;
            set;
        }
        private string typeofevent_;
        public string TypeOfEvent_
        {
            get { return typeofevent_; }
            set { typeofevent_ = value; OnPropertyChanged(nameof(TypeOfEvent_)); }
        }
        private int? nameofstudy_;
        public int? NameOfStudy_
        {
            get
            {
                if (nameofstudy_ != null) return (int)nameofstudy_;
                else return null;
            }
            set { nameofstudy_ = value; OnPropertyChanged(nameof(NameOfStudy_)); }
        }
        private string description_;
        public string Description_
        {
            get { return description_; }
            set { description_ = value; OnPropertyChanged(nameof(Description_)); }
        }
        private int? idalternate_;
        public int? IdAlternate_
        {
            get
            {
                if (idalternate_ != null) return (int)idalternate_;
                else return null;
            }
            set { idalternate_ = value; OnPropertyChanged(nameof(IdAlternate_)); }
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
                OnPropertyChanged(nameof(DateStart_));
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
                OnPropertyChanged(nameof(DateFinish_));
            }
        }


        //СЕРВИСЫ
        public EmployeeService employeeService;
        public CalendarService calendarService;
        public EventService eventService;


        //КОМАНДЫ
        private RelayCommand? turnoffCommand;

        public RelayCommand TurnoffCommand
        {
            get
            {
                return turnoffCommand ??
                    (turnoffCommand = new RelayCommand((o) =>
                    {
                        var result = MessageBox.Show("робит");
                    }));
            }
        }
        private RelayCommand? changeEditabilitycommand;
        public RelayCommand ChangeEditabilityCommand
        {
            get
            {
                return changeEditabilitycommand ??
                  (changeEditabilitycommand = new RelayCommand((o) =>
                  {
                      if (IsEditable) IsEditable = false;
                      else IsEditable = true;
                  }));
            }
        }
        private RelayCommand? addEmp;
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
        private RelayCommand? resetCommand;
        public RelayCommand ResetCommand
        {
            get
            {
                return resetCommand ??
                  (resetCommand = new RelayCommand((o) =>
                  {
                      var result = MessageBox.Show("Вы уверены, что хотите отменить изменения?","Подтверждение", MessageBoxButton.YesNo);
                      if (result == MessageBoxResult.Yes) BrowseEmployee();

                  }));
            }
        }
        private RelayCommand? deletecalendarCommand;
        public RelayCommand DeleteCalendarCommand
        {
            get
            {
                return deletecalendarCommand ??
                  (deletecalendarCommand = new RelayCommand((o) =>
                  {
                      int calendarid = (int)(o);
                      Calendar_ calendar_ = Calendars.FirstOrDefault(x => x.IdCalendar == calendarid)!;
                      var result = MessageBox.Show("Вы уверены, что хотите удалить это мероприятие?", "Подтверждение", MessageBoxButton.YesNo);
                      if (result == MessageBoxResult.Yes) calendarService.Delete(calendar_);

                  }));
            }
        }



        public PersonViewModel(Employee employee, int departmentid)
        {
            SelectedEmployee = employee;
            SelectedDepartment = departmentid;
            LoadEmpDep();
            EmployeeList = Employees!.Where(x => x.IdDepartment == SelectedDepartment && x.IdEmployee != SelectedEmployee.IdEmployee).ToList();
            
            BrowseEmployee(); 

        }
        private void BrowseEmployee()
        {
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
                BossId_ = EmployeeList.FirstOrDefault(x => x.IdEmployee == SelectedEmployee.IdBoss);
                HelperId_ = EmployeeList.FirstOrDefault(x => x.IdEmployee == SelectedEmployee.IdHelper);
                Birthday_ = SelectedEmployee.BirthDay;
                IsEditable = true;
                //IsEditable = false;
                BrowseEvents();


            }
            else
            {
                Surname_ = "";
                Firstname_ = "";
                Secondname_ = "";
                Position_ = "";
                Phonework_ = "";
                Phone_ = "";
                Cabinet_ = "";
                Email_ = "";
                Other_ = "";
                BossId_ = null;
                HelperId_ = null;
                Birthday_ = null;
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

        private void BrowseEvents()
        {
            List<string> strings = new List<string>() { "Обучение", "Временное отсутствие", "Отпуск" };
            List<Event> events = Events.Where(p => p.DateOfEvent >= DateTime.Now).ToList();
            Calendars = new ObservableCollection<Calendar_>(calendarService.GetAll()).Where(x => x.IdEmployee == SelectedEmployee.IdEmployee).ToList();
            Calendars.Sort();
            var listStudy = Calendars.Where(x => x.TypeOfEvent == "Обучение");
            var listSkip = Calendars.Where(x => x.TypeOfEvent == "Временное отсутствие");
            var listVacation = Calendars.Where(x => x.TypeOfEvent == "Отпуск");
            StudyList = listStudy.ToList();
            SkipList = listSkip.ToList();
            VacationList = listVacation.ToList();
        }
    }
}
