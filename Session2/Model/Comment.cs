﻿using System;
using System.Collections.Generic;

namespace Session2.Model;

public partial class Comment
{
    public int IdComment { get; set; }

    public int IdMaterial { get; set; }

    public string CommentText { get; set; } = null!;

    public string DateCreated { get; set; } = null!;

    public string? DateUpdated { get; set; }

    public int AuthorOfComment { get; set; }

    public virtual Employee AuthorOfCommentNavigation { get; set; } = null!;

    public virtual Material IdMaterialNavigation { get; set; } = null!;
}
