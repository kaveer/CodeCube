using SQLite;

namespace CubeNotes.Models;

[Table("notes")]
public class Note
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    [MaxLength(200)]
    public string Title { get; set; } = string.Empty;

    public string Content { get; set; } = string.Empty;

    [MaxLength(100)]
    public string Tags { get; set; } = string.Empty;

    public DateTime CreatedDate { get; set; } = DateTime.Now;

    public DateTime ModifiedDate { get; set; } = DateTime.Now;

    [MaxLength(50)]
    public string Color { get; set; } = "#FFFFFF";

    public bool IsPinned { get; set; } = false;

    public bool IsArchived { get; set; } = false;

    // Helper property for displaying tags as list
    [Ignore]
    public List<string> TagList
    {
        get => string.IsNullOrEmpty(Tags)
   ? new List<string>()
        : Tags.Split(',').Select(t => t.Trim()).ToList();
     set => Tags = string.Join(", ", value);
    }

    // Helper property for formatted date
    [Ignore]
    public string FormattedDate
    {
        get
        {
        var timeSpan = DateTime.Now - ModifiedDate;
  if (timeSpan.TotalMinutes < 1)
      return "Just now";
   if (timeSpan.TotalHours < 1)
          return $"{(int)timeSpan.TotalMinutes}m ago";
            if (timeSpan.TotalDays < 1)
     return $"{(int)timeSpan.TotalHours}h ago";
         if (timeSpan.TotalDays < 7)
        return $"{(int)timeSpan.TotalDays}d ago";
   return ModifiedDate.ToString("MMM dd, yyyy");
        }
  }

    // Helper property for preview
    [Ignore]
    public string Preview =>  string.IsNullOrEmpty(Content) 
   ? "No content" 
   : Content.Length > 100 
          ? Content.Substring(0, 100) + "..." 
          : Content;
}
