using System;
using System.Collections.Generic;

namespace Desktop.Model;

public partial class Comment
{
    public int IdComment { get; set; }

    public int IdMaterial { get; set; }

    public string CommentText { get; set; } = null!;

    public string DateCreated { get; set; } = null!;

    public string? DateUpdated { get; set; }

    public int AuthorOfComment { get; set; }

}
