using System;
using System.Collections.Generic;

namespace WebAPI.Models;

public partial class User
{
    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int IdUser { get; set; }
}
