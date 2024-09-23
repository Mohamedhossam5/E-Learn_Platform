using System;
using System.Collections.Generic;

namespace Core.Entities;

public partial class TextContent
{
    public int TextId { get; set; }

    public int? ContentId { get; set; }

    public string? Body { get; set; }

    public virtual CourseContent? Content { get; set; }
}
