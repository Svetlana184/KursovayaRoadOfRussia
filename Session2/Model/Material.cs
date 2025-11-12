using System;
using System.Collections.Generic;

namespace Desktop.Model;

public partial class Material
{
    public int IdMaterial { get; set; }

    public string MaterialName { get; set; } = null!;

    public string DateApproval { get; set; } = null!;

    public string DateChanges { get; set; } = null!;

    public string Status { get; set; } = null!;

    public string TypeOfMaterial { get; set; } = null!;

    public string Domain { get; set; } = null!;

    public string Author { get; set; } = null!;

    public int Comments { get; set; }

  
}
