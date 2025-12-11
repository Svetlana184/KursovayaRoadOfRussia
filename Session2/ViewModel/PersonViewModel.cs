using Desktop.Model;
using Desktop.Services;
using Desktop.Utilits;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Eventing.Reader;
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
        private string windowstate;
        public string WindowState
        {
            get { return windowstate; }
            set
            {
                windowstate = value;
                OnPropertyChanged(nameof(WindowState));
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
        public ObservableCollection<Calendar_> Calendars_collection { get; set; }
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
        private ObservableCollection<WorkingCalendar> holidays;
        public ObservableCollection<WorkingCalendar> Holidays
        {
            get => holidays;
            set
            {
                holidays = value;
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

        //СОБЫТИЯ
        public static event Action EmployeeUpdated;
        public static event Action EmployeeAdded;

        //СЕРВИСЫ
        public EmployeeService employeeService;
        public CalendarService calendarService;
        public EventService eventService;
        public WorkingCalendarService workingCalendarService;

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
                    (turnoffCommand = new RelayCommand(async (o) =>
                    {
                        var result = MessageBox.Show("Вы уверены, что хотите уволить данного сотрудника?", "Подтверждение", MessageBoxButton.YesNo);
                        if (result == MessageBoxResult.Yes)
                        {
                            List<Calendar_> calendarPresent = StudyList.Where(x => x.DateFinish > DateOnly.FromDateTime((DateTime.Now))).ToList();
                            if (calendarPresent.Count != 0)
                            {
                                var result1 = MessageBox.Show("Вы не можете уволить данного сотрудника из-за запланированного обучения", "Подтверждение", MessageBoxButton.OKCancel);
                            }
                            else
                            {
                                try
                                {
                                    SelectedEmployee.IsFired = DateTime.Now;

                                    var updateResult = await Task.Run(() => employeeService.Update(SelectedEmployee));

                                    if (updateResult == true)
                                    {
                                        MessageBox.Show("Сотрудник уволен", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                                        EmployeeUpdated?.Invoke();
                                    }
                                    else
                                    {
                                        MessageBox.Show($"Ошибка при увольнении: {updateResult}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show($"Ошибка при увольнении: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                }
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
                  (addEmp = new RelayCommand(async (o) =>
                  {
                      if (!string.IsNullOrEmpty(SelectedEmployee.Error))
                      {
                          MessageBox.Show(SelectedEmployee.Error, "Ошибка валидации",
                              MessageBoxButton.OK, MessageBoxImage.Error);
                          return;
                      }
                      if (BossId_ != null) 
                      { 
                          SelectedEmployee.IdBoss = BossId_.IdEmployee;
                      }
                      if (HelperId_ != null) 
                      { 
                           SelectedEmployee.IdHelper = HelperId_.IdEmployee;
                          
                      }

                      try
                      {
                          bool result;
                          if (SelectedEmployee.IdEmployee == 0)
                          {
                              result = await employeeService.Add(SelectedEmployee);
                              if (result)
                              {
                                  MessageBox.Show("Сотрудник добавлен", "Успешно");
                                  
                                  EmployeeAdded?.Invoke();
                                  CloseWindow(); 
                              }
                          }
                          else
                          {
                              result = await employeeService.Update(SelectedEmployee);
                              if (result)
                              {
                                  MessageBox.Show("Изменения сохранены", "Успешно");
                                  IsEditable = false;
                                  EmployeeUpdated?.Invoke();
                                  CloseWindow(); 
                              }
                          }
                      }
                      catch (Exception ex)
                      {
                          MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка");
                      }
                     
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
                      var result = MessageBox.Show("Вы уверены, что хотите отменить изменения?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Warning);
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
                  (deletecalendarCommand = new RelayCommand(async (o) =>
                  {
                      int calendarid = (int)(o);
                      Calendar_ calendar_ = Calendars.FirstOrDefault(x => x.IdCalendar == calendarid)!;
                      var result = MessageBox.Show("Вы уверены, что хотите удалить это мероприятие?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                      if (result == MessageBoxResult.Yes)
                      {
                          await calendarService.Delete(calendar_);
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
                      var result = MessageBox.Show("Вы уверены, что хотите отменить изменения?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Warning);
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
                  (saveEvent = new RelayCommand(async (o) =>
                  {
                      var result = MessageBox.Show("Cохранить мероприятие?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                      if (result == MessageBoxResult.Yes)
                      {
                          if (TypeOfEvent_ == null || DateStart_ == null || DateFinish_ == null)
                          {
                              MessageBox.Show("Заполните поле названия мероприятия и даты его проведения",
                                  "Обязательные поля", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                          }
                          else
                          {
                              List<DateTime> dateRange = GenerateDateRange(DateStart_.Value, DateFinish_.Value);
                              if (DateStart_ <= DateFinish_)
                              {
                                  switch (TypeOfEvent_)
                                  {
                                      case "Отпуск":
                                      case "Обучение":
                                          {
                                              List<Calendar_> conflictingEvents = GetConflictingEvents(dateRange, skipList.ToList());
                                              if (conflictingEvents.Any())
                                              {
                                                  ShowConflictMessage(conflictingEvents);
                                                  return;
                                              }
                                              break;
                                          }    
                                      case "Временное отсутствие":
                                          {
                                              List<Calendar_> conflictingEvents = new List<Calendar_>();
                                              List<DateTime> conflictHolidays = new List<DateTime>();
                                              conflictingEvents.AddRange(GetConflictingEvents(dateRange, vacationList.ToList()));
                                              var x = GenerateHolidayRange();
                                              conflictingEvents.AddRange(GetConflictingEvents(dateRange, studyList.ToList()));
                                              conflictHolidays.AddRange(GetConflictingEventsWithHolidays(dateRange, GenerateHolidayRange()));
                                              if (conflictingEvents.Any())
                                              {
                                                  ShowConflictMessage(conflictingEvents);
                                                  return;
                                              }
                                              if (conflictHolidays.Any())
                                              {
                                                  MessageBox.Show("Отгул нельзя запланировать на праздничный день", "Конфликт планирования",
                                                      MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                                                  return;
                                              }
                                              break;
                                          }     
                                  }
                                  Calendar_ newCalendar = new Calendar_();
                                  newCalendar.IdEmployee = SelectedEmployee.IdEmployee;
                                  newCalendar.TypeOfEvent = TypeOfEvent_;
                                  if (NameOfStudy_ != null) newCalendar.IdEvent = NameOfStudy_.IdEvent;
                                  newCalendar.TypeOfAbsense = Typeofabsence_;
                                  if (IdAlternate_ != null) newCalendar.IdAlternate = IdAlternate_.IdEmployee;
                                  newCalendar.DateStart = DateOnly.FromDateTime((DateTime)DateStart_!);
                                  newCalendar.DateFinish = DateOnly.FromDateTime((DateTime)DateFinish_!);

                                  await calendarService.Add(newCalendar);

                                  LoadCalendars();
                                  BrowseEvents();
                                  TypeOfEvent_ = " ";
                                  NameOfStudy_ = null;
                                  Typeofabsence_ = " ";
                                  IdAlternate_ = null;
                                  DateStart_ = null;
                                  DateFinish_ = null;


                              }
                              else
                              {
                                  MessageBox.Show("Дата окончания мероприятия не может быть раньше даты начала", "Даты мероприятия",
                                      MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                              }
                          }
                          
                      }

                  }));
            }
        }

        private void ShowConflictMessage(List<Calendar_> conflicts)
        {
            StringBuilder message = new StringBuilder();

            message.AppendLine("Обнаружены конфликтующие события:");

            foreach (var conflict in conflicts)
            {
                message.AppendLine($"• {conflict.TypeOfEvent}: {conflict.DateStart} - {conflict.DateFinish}"); 
            }

            MessageBox.Show(message.ToString(), "Конфликт планирования",
                MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private List<DateTime> GetConflictingEventsWithHolidays(List<DateTime> dateRange,
                                          List<DateTime> days)
        {
            List<DateTime> conflicts = new List<DateTime>();

            foreach (var calendar in days)
            {
                DateTime calStart = calendar;
                DateTime calEnd = calendar;
                bool hasConflict = false;
                hasConflict = dateRange.Any(date => date >= calStart && date <= calEnd);
                if (hasConflict)
                {
                    conflicts.Add(calendar);
                }
            }

            return conflicts;
        }

        private List<Calendar_> GetConflictingEvents(List<DateTime> dateRange,
                                           List<Calendar_> calendars)
        {
            List<Calendar_> conflicts = new List<Calendar_>();

            foreach (var calendar in calendars)
            {
                DateTime calStart = DateTime.Parse(calendar.DateStart.ToString());
                DateTime calEnd = DateTime.Parse(calendar.DateFinish.ToString());
                bool hasConflict = false;
                hasConflict = dateRange.Any(date => date >= calStart && date <= calEnd);
                if (hasConflict)
                {
                    conflicts.Add(calendar);
                }
            }

            return conflicts;
        }
        private List<DateTime> GenerateHolidayRange()
        {
            List<DateTime> dates = new List<DateTime>();

            foreach (WorkingCalendar day in Holidays)
            {
                if(day.IsWorkingDay == false)
                {
                    dates.Add(DateTime.Parse(day.ExceptionDate.ToString()));
                }
                
            }

            return dates;
        }
        private List<DateTime> GenerateDateRange(DateTime startDate, DateTime endDate)
        {
            List<DateTime> dates = new List<DateTime>();

            for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
            {
                dates.Add(date);
            }

            return dates;
        }

        private RelayCommand? stateminCommand;
        public RelayCommand StateminCommand
        {
            get
            {
                return stateminCommand ??
                  (stateminCommand = new RelayCommand((o) =>
                  {
                      WindowState = "Minimized";
                  }));
            }
        }
        private RelayCommand? statemaxCommand;
        public RelayCommand StatemaxCommand
        {
            get
            {
                return statemaxCommand ??
                  (statemaxCommand = new RelayCommand((o) =>
                  {
                      if (WindowState == "Normal")
                      {
                          WindowState = "Maximized";
                      }
                      else
                      {
                          WindowState = "Normal";
                      }
                  }));
            }
        }

        public PersonViewModel(Employee employee, int departmentid)
        {
            WindowState = "Normal";
            BackUpEmployee = (Employee)employee.Clone();
            SelectedEmployee = employee;
            
            SelectedDepartment = departmentid;

            Employees = new ObservableCollection<Employee>();
            EmployeeList = new List<Employee>();

            LoadData();

           

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
                VisibilityButton = "Hidden";
            }
            

        }
        
        private async void LoadData()
        {
            try
            {
                await LoadEmpDep();
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
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private async Task LoadEmpDep()
        {
            employeeService = new EmployeeService();
            eventService = new EventService();
            calendarService = new CalendarService();
            workingCalendarService = new WorkingCalendarService();
            try
            {
                Employees = null;
                Task<List<Employee>> task_emp = Task.Run(() => employeeService.GetAll());
                
                Events = null;
                Task<List<Event>> task_ev = Task.Run(() => eventService.GetAll());
                Holidays = null;
                Task<List<WorkingCalendar>> task_h = Task.Run(() => workingCalendarService.GetAll());

                await Task.WhenAll(task_emp, task_ev, task_h);
                Employees = new ObservableCollection<Employee>(task_emp.Result);
                Events = new ObservableCollection<Event>(task_ev.Result);
                Holidays = new ObservableCollection<WorkingCalendar>(task_h.Result);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка загрузки",
                MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void LoadCalendars()
        {
            try
            {
                Calendars_collection = null;
                Task<List<Calendar_>> task_c = Task.Run(() => calendarService.GetAll());
                Calendars_collection = new ObservableCollection<Calendar_>(task_c.Result);
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void BrowseEvents()
        {
            Types = new List<string>() { "Обучение", "Временное отсутствие", "Отпуск" };
            NamesEvent = Events.Where(p => DateTime.Parse(p.DateOfEvent) >= DateTime.Now).ToList();
            NamesEvent.Add(new Event());
            LoadCalendars();    
            Calendars = Calendars_collection.Where(x => x.IdEmployee == SelectedEmployee.IdEmployee).ToList();
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
                    if ((item.DateFinish) < DateOnly.FromDateTime((DateTime.Now)))
                    {
                        listAll.Add(item);
                    }
                }
            }
            if (PresentShow)
            {
                foreach (Calendar_ item in Calendars)
                {
                    if ((item.DateStart) <= DateOnly.FromDateTime((DateTime.Now)) && (item.DateFinish) >= DateOnly.FromDateTime((DateTime.Now)))
                    {
                        listAll.Add(item);
                    }
                }
            }
            if (FutureShow)
            {
                foreach (Calendar_ item in Calendars)
                {
                    if ((item.DateStart) > DateOnly.FromDateTime((DateTime.Now)))
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
