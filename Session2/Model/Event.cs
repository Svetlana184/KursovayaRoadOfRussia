using System;
using System.Collections.Generic;

namespace Desktop.Model;

public partial class Event
{
    public int IdEvent { get; set; }

    public string EventName { get; set; } = null!;

    public string TypeOfEvent { get; set; } = null!;

    public string EventStatus { get; set; } = null!;

    public string EventDescription { get; set; } = null!;

    public string DateOfEvent { get; set; } = null!;

    public string EventManagers { get; set; } = null!;

    public string TypeOfClass { get; set; } = null!;

    
}
