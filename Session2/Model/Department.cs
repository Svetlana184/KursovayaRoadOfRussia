using System;
using System.Collections.Generic;

namespace Desktop.Model;

public partial class Department
{
    public int IdDepartment { get; set; }

    public string DepartmentName { get; set; } = null!;

    public string? Description { get; set; }

    public int? IdEmployee { get; set; }

    public int? IdDepartmentParent { get; set; }

   
}
