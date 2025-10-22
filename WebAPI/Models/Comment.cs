using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
namespace WebAPI.Models;
public partial class Comment
{
    public int IdComment { get; set; }

    public int IdMaterial { get; set; }

    public string CommentText { get; set; } = null!;

    public DateTime DateCreated { get; set; }

    public DateTime? DateUpdated { get; set; }

    public int AuthorOfComment { get; set; }
    [JsonIgnore]
    public virtual Employee AuthorOfCommentNavigation { get; set; } = null!;
    [JsonIgnore]
    public virtual Material IdMaterialNavigation { get; set; } = null!;
}
