using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebAPI.Models;

public partial class Department
{
    public int IdDepartment { get; set; }

    public string DepartmentName { get; set; } = null!;

    public string? Description { get; set; }

    public int? IdEmployee { get; set; }

    public int? IdDepartmentParent { get; set; }
    [JsonIgnore]
    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
    [JsonIgnore]
    public virtual Employee? IdEmployeeNavigation { get; set; }
}
