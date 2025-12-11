using System;
using System.Collections.Generic;

namespace WebAPI.Models;

public partial class User
{
    public required string Email { get; set; }

    public required string Password { get; set; }

    public int IdUser { get; set; }
}
