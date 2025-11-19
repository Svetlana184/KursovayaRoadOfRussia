using Desktop.Model;
using Desktop.Services;
using Desktop.Utilits;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Desktop.ViewModel
{
    public class PersonViewModel : ViewModelBase
    {
        private Employee _employee;
        public Employee SelectedEmployee 
        {
            get { return _employee; }
            set
            {
                _employee = value;
                OnPropertyChanged(nameof(SelectedEmployee));
            }
        }
        private Employee BackUpEmployee;
        private Event newEvent;
        public Event NewEvent
        {
            get { return newEvent;  }
            set
            {
                newEvent = value;
                OnPropertyChanged(nameof(NewEvent));
            }
        }
        public int SelectedDepartment { get; set; }

        public ObservableCollection<Employee> Employees { get; set; }
        public List<Calendar_> Calendars { get; set; }
        private List<Employee> employeelist;
        public List<Employee> EmployeeList 
        {
            get {  return employeelist; }
            set
            {
                employeelist = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Event> Events { get; set; }
        private bool iseditable;
        public bool IsEditable 
        {
            get {return iseditable; }
            set
            {
                iseditable = value;
                OnPropertyChanged(nameof(iseditable));
            }
        }
        

        
        private string visibilitybutton;
        public string VisibilityButton
        {
            get { return visibilitybutton; }
            set
            {
                visibilitybutton = value;
                OnPropertyChanged(nameof(visibilitybutton));
            }
        }

        

        //КАЛЕНДАРЬ

        private List<string> types;
        public List<string> Types
        {
            get
            {
                return types;
            }
            set
            {
                types = value;
                OnPropertyChanged();
            }
        }
        private List<Event> namesEvent;
        public List<Event> NamesEvent
        {
            get
            {
                return namesEvent;
            }
            set
            {
                namesEvent = value;
                OnPropertyChanged();
            }
        }

        //фильтры событий
        private bool presentShow;
        public bool PresentShow
        {
            get => presentShow; 
            set 
            {
                presentShow = value;
                OnPropertyChanged(nameof(PresentShow));
            }
        }
        private bool lastShow;
        public bool LastShow
        {
            get => lastShow;
            set
            {
                lastShow = value;
                OnPropertyChanged(nameof(LastShow));
            }
        }
        private bool futureShow;
        public bool FutureShow
        {
            get => futureShow;
            set
            {
                futureShow = value;
                OnPropertyChanged(nameof(FutureShow));
            }
        }
        private string colorLast;
        public string ColorLast 
        {
            get
            {
                return colorLast;
            }
            set
            {
                colorLast = value;
                OnPropertyChanged(nameof(ColorLast));
            }
        }
        private string colorPresent;
        public string ColorPresent
        {
            get
            {
                return colorPresent;
            }
            set
            {
                colorPresent = value;
                OnPropertyChanged(nameof(ColorPresent));
            }
        }
        private string colorFuture;
        public string ColorFuture
        {
            get
            {
                return colorFuture;
            }
            set
            {
                colorFuture = value;
                OnPropertyChanged(nameof(ColorFuture));
            }
        }

        //списки событий
        private ObservableCollection<Calendar_> studyList;
        public ObservableCollection<Calendar_> StudyList
        {
            get => studyList;
            set
            {
                studyList = value;
                OnPropertyChanged(); 
            }
        }
        private ObservableCollection<Calendar_> skipList;
        public ObservableCollection<Calendar_> SkipList
        {
            get => skipList;
            set
            {
                skipList = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<Calendar_> vacationList;
        public ObservableCollection<Calendar_> VacationList
        {
            get => vacationList;
            set
            {
                vacationList = value;
                OnPropertyChanged();
            }
        }


        //поля для карточки сотрудника
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
        private Event? nameofstudy_;
        public Event? NameOfStudy_
        {
            get
            {
                if (nameofstudy_ != null) return nameofstudy_;
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
        private string typeofabsence_;
        public string Typeofabsence_
        {
            get { return typeofabsence_; }
            set { typeofabsence_ = value; OnPropertyChanged(nameof(Typeofabsence_)); }
        }
        private Employee? idalternate_;
        public Employee? IdAlternate_
        {
            get
            {
                if (idalternate_ != null) return idalternate_;
                else return null;
            }
            set { idalternate_ = value; OnPropertyChanged(nameof(IdAlternate_)); }
        }
        private DateTime? datestart_;
       
        public DateTime? DateStart_
        {
            get
            {
                if (datestart_ != null)
                {
                    return datestart_;
                }
                else return (DateTime.Now);

            }
            set
            {
                datestart_ = value;
                OnPropertyChanged(nameof(DateStart_));
            }
        }
        private DateTime? datefinish_;
        public DateTime? DateFinish_
        {
            get
            {
                if (datefinish_ != null)
                {
                    return datefinish_;
                }
                else return (DateTime.Now);

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

        public event Action WindowClosed;
        private void CloseWindow()
        {
            WindowClosed?.Invoke();
        }


        //КОМАНДЫ
        private RelayCommand? turnoffCommand;

        public RelayCommand TurnoffCommand
        {
            get
            {
                return turnoffCommand ??
                    (turnoffCommand = new RelayCommand((o) =>
                    {
                        var result = MessageBox.Show("Вы уверены, что хотите уволить данного сотрудника?", "Подтверждение", MessageBoxButton.YesNo);
                        if (result == MessageBoxResult.Yes)
                        {
                            List<Calendar_> calendarPresent = StudyList.Where(x => DateTime.Parse(x.DateFinish) > (DateTime.Now)).ToList();
                            if (calendarPresent.Count != 0)
                            {
                                var result1 = MessageBox.Show("Вы не можете уволить данного сотрудника из-за запланированного обучения", "Подтверждение", MessageBoxButton.OKCancel);
                            }
                            else
                            {
                                SelectedEmployee.IsFired = DateTime.Now.ToString();
                                employeeService.Update(SelectedEmployee);
                            }
                        }

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

                      if (BossId_ != null) 
                      { 
                          SelectedEmployee.IdBoss = BossId_.IdEmployee;
                      }
                      if (HelperId_ != null) 
                      { 
                           SelectedEmployee.IdHelper = HelperId_.IdEmployee;
                          
                      } 

                      if (SelectedEmployee.IdEmployee == 0)
                      {
                          employeeService.Add(SelectedEmployee);
                      }
                      else employeeService.Update(SelectedEmployee);
                      
                      IsEditable = false;
                      var result = MessageBox.Show("для обновления списка сотрудников перезагрузите окно, нажав на кнопку перезагрузки в верхней правой части главного окна", "подтверждение", MessageBoxButton.OKCancel);
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
                      var result = MessageBox.Show("Вы уверены, что хотите отменить изменения?", "Подтверждение", MessageBoxButton.YesNo);
                      if (result == MessageBoxResult.Yes)
                      {
                          SelectedEmployee = (Employee)BackUpEmployee.Clone();
                          BrowseEmployee();

                      }

                  }));
            }
        }
        private RelayCommand deletecalendarCommand;
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
                      if (result == MessageBoxResult.Yes)
                      {
                          calendarService.Delete(calendar_);
                          Calendars.Remove(calendar_);
                          UpdateEvents();
                      }
                  }));
            }
        }

        private RelayCommand activePresent;
        public RelayCommand ActivePresent
        {
            get
            {
                return activePresent ??
                  (activePresent = new RelayCommand((o) =>
                  {
                      if (PresentShow)
                      {
                          PresentShow = false;
                          ColorPresent = "LightGreen";
                      }
                      else
                      {
                          PresentShow = true;
                          ColorPresent = "Green";
                      }
                      UpdateEvents();
                  }));
            }
        }
        private RelayCommand activeLast;
        public RelayCommand ActiveLast
        {
            get
            {
                return activeLast ??
                  (activeLast = new RelayCommand((o) =>
                  {
                      if (LastShow)
                      {
                          LastShow = false;
                          ColorLast = "LightGreen";
                      }
                      else
                      {
                          LastShow = true;
                          ColorLast = "Green";
                      }
                      UpdateEvents();
                  }));
            }
        }
        private RelayCommand activeFuture;
        public RelayCommand ActiveFuture
        {
            get
            {
                return activeFuture ??
                  (activeFuture = new RelayCommand((o) =>
                  {
                      if (FutureShow)
                      {
                          FutureShow = false;
                          ColorFuture = "LightGreen";
                      }
                      else
                      {
                          FutureShow = true;
                          ColorFuture = "Green";
                      }
                      UpdateEvents();
                  }));
            }
        }

        private RelayCommand resetEvent;
        public RelayCommand ResetEvent
        {
            get
            {
                return resetEvent ??
                  (resetEvent = new RelayCommand((o) =>
                  {
                      var result = MessageBox.Show("Вы уверены, что хотите отменить изменения?", "Подтверждение", MessageBoxButton.YesNo);
                      if (result == MessageBoxResult.Yes)
                      {
                          TypeOfEvent_ = "";
                          NameOfStudy_ = null;
                          Description_ = "";
                          Typeofabsence_ = "";
                          IdAlternate_ = null;
                          DateStart_ = null;
                          DateFinish_ = null;
                      }

                  }));
            }
        }

        public RelayCommand saveEvent;
        public RelayCommand SaveEvent
        {
            get
            {
                return saveEvent ??
                  (saveEvent = new RelayCommand((o) =>
                  {
                      var result = MessageBox.Show("Вы уверены, что хотите сохранить мероприятие?", "Подтверждение", MessageBoxButton.YesNo);
                      if (result == MessageBoxResult.Yes)
                      {
                          
                          Calendar_ newCalendar = new Calendar_();
                          newCalendar.IdEmployee = SelectedEmployee.IdEmployee;
                          newCalendar.TypeOfEvent = TypeOfEvent_;
                          if(NameOfStudy_ != null) newCalendar.IdEvent = NameOfStudy_.IdEvent;
                          newCalendar.TypeOfAbsense = Typeofabsence_;
                          if(IdAlternate_ != null) newCalendar.IdAlternate = IdAlternate_.IdEmployee;
                          newCalendar.DateStart = DateOnly.FromDateTime((DateTime)DateStart_!).ToString();
                          newCalendar.DateFinish = DateOnly.FromDateTime((DateTime)DateFinish_!).ToString();

                          calendarService.Add(newCalendar);
                          BrowseEvents();
                          TypeOfEvent_ = " ";
                          NameOfStudy_ = null;
                          Typeofabsence_ = " ";
                          IdAlternate_ = null;
                          DateStart_ = null;
                          DateFinish_ = null;
                      }

                  }));
            }
        }



        public PersonViewModel(Employee employee, int departmentid)
        {
            BackUpEmployee = (Employee)employee.Clone();
            SelectedEmployee = employee;
            
            SelectedDepartment = departmentid;
            LoadEmpDep();
            EmployeeList = Employees!.Where(x => x.IdDepartment == SelectedDepartment && x.IdEmployee != SelectedEmployee.IdEmployee).ToList();
            EmployeeList.Sort();
            EmployeeList.Add(new Employee());
            LastShow = false;
            PresentShow = true;
            FutureShow = true;
            ColorPresent = "Green";
            ColorLast = "LightGreen";
            ColorFuture = "Green";
            BrowseEmployee(); 

        }
        private void BrowseEmployee()
        {
            if (SelectedEmployee.IdEmployee != 0)
            {
                BossId_ = EmployeeList.FirstOrDefault(x => x.IdEmployee == SelectedEmployee.IdBoss);
                HelperId_ = EmployeeList.FirstOrDefault(x => x.IdEmployee == SelectedEmployee.IdHelper);
                IsEditable = false;
                VisibilityButton = "Visible";
                BrowseEvents();
            }
            else
            {
                BackUpEmployee.IdDepartment = SelectedDepartment;
                SelectedEmployee.IdDepartment = SelectedDepartment;
                BossId_ = null;
                HelperId_ = null;
                IsEditable = true;
                SelectedDepartment = 888;
                VisibilityButton = "Hidden";
            }
            

        }
        private void LoadEmpDep()
        {
            employeeService = new EmployeeService();
            eventService = new EventService();
            calendarService = new CalendarService();

            Employees = new ObservableCollection<Employee>(employeeService.GetAll().Result);
            Events = new ObservableCollection<Event>(eventService.GetAll().Result);
        }

        private void BrowseEvents()
        {
            Types = new List<string>() { "Обучение", "Временное отсутствие", "Отпуск" };
            NamesEvent = Events.Where(p => DateTime.Parse(p.DateOfEvent) >= DateTime.Now).ToList();
            NamesEvent.Add(new Event());
            Calendars = new ObservableCollection<Calendar_>(calendarService.GetAll().Result).Where(x => x.IdEmployee == SelectedEmployee.IdEmployee).ToList();
            Calendars.Sort();
            
            UpdateEvents();
            
        }
        private void UpdateEvents()
        {
            List<Calendar_> listAll = new List<Calendar_>();
            if (LastShow)
            {
                foreach (Calendar_ item in Calendars)
                {
                    if (DateTime.Parse(item.DateFinish) < (DateTime.Now))
                    {
                        listAll.Add(item);
                    }
                }
            }
            if (PresentShow)
            {
                foreach (Calendar_ item in Calendars)
                {
                    if (DateTime.Parse(item.DateStart) <= DateTime.Now && DateTime.Parse(item.DateFinish) >= DateTime.Now)
                    {
                        listAll.Add(item);
                    }
                }
            }
            if (FutureShow)
            {
                foreach (Calendar_ item in Calendars)
                {
                    if (DateTime.Parse(item.DateStart) > DateTime.Now)
                    {
                        listAll.Add(item);
                    }
                }
            }
            StudyList = new ObservableCollection<Calendar_>(listAll.Where(x => x.TypeOfEvent == "Обучение"));
            SkipList = new ObservableCollection<Calendar_>(listAll.Where(x => x.TypeOfEvent == "Временное отсутствие"));
            VacationList = new ObservableCollection<Calendar_>(listAll.Where(x => x.TypeOfEvent == "Отпуск"));
        }
    }
}
