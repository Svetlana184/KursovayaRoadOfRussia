using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebAPI.Models;

public partial class Event
{
    public int IdEvent { get; set; }

    public string EventName { get; set; } = null!;

    public string TypeOfEvent { get; set; } = null!;

    public string EventStatus { get; set; } = null!;

    public string EventDescription { get; set; } = null!;

    public DateTime DateOfEvent { get; set; }

    public string EventManagers { get; set; } = null!;

    public string TypeOfClass { get; set; } = null!;
    [JsonIgnore]
    public virtual ICollection<Calendar_> Calendars { get; set; } = new List<Calendar_>();
    [JsonIgnore]
    public virtual ICollection<EventMaterial> EventMaterials { get; set; } = new List<EventMaterial>();
}
