using Desktop.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace Desktop.Model;

public partial class User : IDataErrorInfo, INotifyPropertyChanged
{
    private string email = null!;

    public string Email
    {
        get { return email; }
        set { email = value; OnPropertyChanged(nameof(Email)); }
    }

    private string password=null!;
    public string Password
    {
        get { return password; }
        set { password = value; OnPropertyChanged(nameof(Password)); }
    }
    private int iduser;
    public int IdUser
    {
        get { return iduser; }
        set { iduser = value; }
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

            if (string.IsNullOrEmpty(Email?.Trim()))
                return "Email обязателен для заполнения";

            if (string.IsNullOrEmpty(Password?.Trim()))
                return "Email обязателен для заполнения";

            var properties = new[] {"Email", "Password" };
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
                case "Password":
                    if (Password != null)
                    {
                        if (Password.Length < 8)
                            error = "Пароль должен быть минимум 8 символов";
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
}
