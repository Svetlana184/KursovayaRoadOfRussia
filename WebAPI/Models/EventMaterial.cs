using System;
using System.Collections.Generic;

namespace WebAPI.Models;

public partial class EventMaterial
{
    public int IdEventMaterial { get; set; }

    public int IdEvent { get; set; }

    public int IdMaterial { get; set; }

    public virtual Event IdEventNavigation { get; set; } = null!;

    public virtual Material IdMaterialNavigation { get; set; } = null!;
}
