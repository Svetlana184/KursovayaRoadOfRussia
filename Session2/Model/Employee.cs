using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace Session2.Model;

public partial class Employee : IComparable<Employee>, INotifyPropertyChanged, IDataErrorInfo, ICloneable
{


    private int idemployee;
    public int IdEmployee
    {
        get { return idemployee; }
        set { idemployee = value;  }
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


    private string? phone;

    public string? Phone
    {
        get { return phone; }
        set { phone = value; OnPropertyChanged(nameof(Phone)); }
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


    private int? idhelper;
    public int? IdHelper
    {
        get { return idhelper; }
        set { idhelper = value; OnPropertyChanged(nameof(IdHelper)); }
    }
    private int? idboss;
    public int? IdBoss
    {
        get { return idboss; }
        set { idboss = value; OnPropertyChanged(nameof(IdBoss)); }
    }
    private int? password;
    public int? Password
    {
        get { return password; }
        set { password = value; OnPropertyChanged(nameof(Password)); }
    }
    private string? isFired;
    public string? IsFired
    {
        get { return isFired; }
        set { isFired = value; OnPropertyChanged(nameof(IsFired)); }
    }

    private string? birthday;

    public string? BirthDay
    {
        get { return birthday; }
        set { birthday = value; OnPropertyChanged(nameof(BirthDay)); }
    }
    private string? other;

    public string? Other
    {
        get { return other; }
        set { other = value; OnPropertyChanged(nameof(Other)); }
    }

    public event PropertyChangedEventHandler PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string propName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
    }


    public string Error => throw new NotImplementedException();

    public string this[string columnName]
    {
        get
        {
            string error = String.Empty;
            switch (columnName)
            {
                case "Surname":
                    if (Surname != null)
                    {
                        if (!Regex.IsMatch(Surname!, @"[а-яА-ЯёЁ]+$"))
                            error = "Имя не должно содержать вспомогательных символов";
                    }
                    else
                    {
                        error = "Имя не должно быть пустым";
                    }
                    break;
            }
            return error;
        }
    }

    public virtual ICollection<Calendar_> CalendarIdAlternateNavigations { get; set; } = new List<Calendar_>();

    public virtual ICollection<Calendar_> CalendarIdEmployeeNavigations { get; set; } = new List<Calendar_>();

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<Department> Departments { get; set; } = new List<Department>();

    public virtual Department IdDepartmentNavigation { get; set; } = null!;

    

    public int CompareTo(Employee? other)
    {
        if (other is Employee)
        {
            var emp = other as Employee;
            int comp = this.Surname.CompareTo(emp.Surname);
            if (comp != 0)
            {
                return comp;
            }
            else
            {
                comp = this.FirstName.CompareTo(emp.FirstName);
                if (comp != 0)
                {
                    return comp;
                }
                else if (this.SecondName != null && emp.SecondName != null)
                {
                    return this.SecondName!.CompareTo(emp.SecondName);
                }
                else return 0;
            }
        }
        else
        {
            throw new ArgumentException("Некорректное значение параметра");
        }
    }

    public object Clone()
    {
        Employee newEmployee = (Employee)this.MemberwiseClone();
        return newEmployee;
    }
}
