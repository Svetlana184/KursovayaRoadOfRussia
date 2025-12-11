using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebAPI.Models;

public partial class Employee
{
    public int IdEmployee { get; set; }

    public string Surname { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string? SecondName { get; set; }

    public string Position { get; set; } = null!;

    public string PhoneWork { get; set; } = null!;

    public string? Phone { get; set; }

    public string Cabinet { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int IdDepartment { get; set; }

    public int? IdHelper { get; set; }

    public string? Other { get; set; }

    public DateOnly? BirthDay { get; set; }

    public int? IdBoss { get; set; }

    public string? Password { get; set; }

    public DateTime? IsFired { get; set; }
    [JsonIgnore]
    public virtual ICollection<Calendar_> CalendarIdAlternateNavigations { get; set; } = new List<Calendar_>();
    [JsonIgnore]
    public virtual ICollection<Calendar_> CalendarIdEmployeeNavigations { get; set; } = new List<Calendar_>();
    [JsonIgnore]
    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
    [JsonIgnore]
    public virtual ICollection<Department> Departments { get; set; } = new List<Department>();
    [JsonIgnore]
    public virtual Department? IdDepartmentNavigation { get; set; }
}
