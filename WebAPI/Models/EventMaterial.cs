using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebAPI.Models;

public partial class EventMaterial
{
    public int IdEventMaterial { get; set; }

    public int IdEvent { get; set; }

    public int IdMaterial { get; set; }
    [JsonIgnore]
    public virtual Event IdEventNavigation { get; set; } = null!;
    [JsonIgnore]
    public virtual Material IdMaterialNavigation { get; set; } = null!;
}
