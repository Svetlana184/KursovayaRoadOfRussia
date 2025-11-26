using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace Desktop.Model;

public partial class Employee : IComparable<Employee>, IDataErrorInfo, INotifyPropertyChanged, ICloneable, IEquatable<Employee>
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
    private string? password;
    public string? Password
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


    public string Error
    {
        get
        {
            if (string.IsNullOrEmpty(Surname?.Trim()))
                return "Фамилия обязательна для заполнения";

            if (string.IsNullOrEmpty(FirstName?.Trim()))
                return "Имя обязательно для заполнения";

            if (string.IsNullOrEmpty(PhoneWork?.Trim()))
                return "Рабочий телефон обязателен для заполнения";

            if (string.IsNullOrEmpty(Email?.Trim()))
                return "Email обязателен для заполнения";


            var properties = new[] { "Surname", "FirstName", "SecondName", "Position", "PhoneWork", "Cabinet", "Email" };
            var errors = properties
                .Select(prop => this[prop])
                .Where(error => !string.IsNullOrEmpty(error))
                .ToArray();

            return string.Join(Environment.NewLine, errors);
        }
    }

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
                            error = "Фамилия должна быть написана кириллицей";
                    }
                    else
                    {
                        error = "Поле не должно быть пустым";
                    }
                    break;
                case "FirstName":
                    if (FirstName != null)
                    {
                        if (!Regex.IsMatch(FirstName!, @"[а-яА-ЯёЁ]+$"))
                            error = "Имя должно быть написано кириллицей";
                    }
                    else
                    {
                        error = "Поле не должно быть пустым";
                    }
                    break;
                case "SecondName":
                    if (SecondName != null)
                    {
                        if (!Regex.IsMatch(SecondName!, @"[а-яА-ЯёЁ]+$"))
                            error = "Отчество должно быть написано кириллицей";
                    }
                    break;
                case "Position":
                    if (Position != null)
                    {
                        if (!Regex.IsMatch(Position!, @"[а-яА-ЯёЁ]+$"))
                            error = "Должность должна быть написана кириллицей";
                    }
                    break;
                case "PhoneWork":
                    if (PhoneWork != null)
                    {
                        if (!Regex.IsMatch(PhoneWork!, @"^[\+\d\s\-\(\)]{5,20}$"))
                            error = "Телефон может содержать только цифры, дефисы, скобки и плюс";
                    }
                    else
                    {
                        error = "Поле не должно быть пустым";
                    }
                    break;

                case "Cabinet":
                    if (Cabinet != null)
                    {
                        if (!Regex.IsMatch(Cabinet!, @"^[a-zA-Zа-яА-ЯёЁ0-9\s\-]{1,10}$"))
                            error = "Номер кабинета может содержать только буквы и цифры";
                    }
                    break;
                case "Email":
                    if (Email != null)
                    {
                        if (!Regex.IsMatch(Email!, @"^[a-zA-Zа-яА-ЯёЁ0-9._%+-]+@[a-zA-Zа-яА-ЯёЁ0-9.-]+\.[a-zA-Zа-яА-ЯёЁ]{2,}$"))
                            error = "Напишите корректную почту";
                    }
                    else
                    {
                        error = "Поле не должно быть пустым";
                    }
                    break;
            }
            return error;
        }
    }



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

    public bool Equals(Employee? other)
    {
        return IdEmployee == other.IdEmployee;
    }
}
