using System;
using System.Collections.Generic;

namespace Core.Entities;

public partial class Course
{
    public int CourseId { get; set; }

    public string CourseName { get; set; } = null!;

    public string? Description { get; set; }

    public int? CategoryId { get; set; }

    public string? Level { get; set; }

    public decimal? Price { get; set; }

    public int? Duration { get; set; }

    public string? ThumbnailUrl { get; set; }

    public string? Language { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Category? Category { get; set; }

    public virtual ICollection<CourseContent> CourseContents { get; set; } = new List<CourseContent>();

    public virtual ICollection<CourseMaterial> CourseMaterials { get; set; } = new List<CourseMaterial>();
}
