// using System.ComponentModel.DataAnnotations;
// using System.ComponentModel.DataAnnotations.Schema;

namespace efCourse.Models;

// [Table("Tasks")]
public class Task
{
    // [Key]
    public Guid TaskId { get; set; }

    // [ForeignKey("CategoryId")]
    public Guid CategoryId { get; set; }

    // [Required]
    // [MaxLength(200)]
    public string Title { get; set; }
    public string Description { get; set; }
    public Priority TaskPriority { get; set; }
    public DateTime CreationDate { get; set; }

    // relationship
    public virtual Category Category { get; set; }

    // This property is not mapped to the database
    // It can be used in code but will not be persisted
    // [NotMapped]
    public string Summary { get; set; }
}

public enum Priority
{
    Low,
    Medium,
    High
}