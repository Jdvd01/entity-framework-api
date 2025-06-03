using System.ComponentModel.DataAnnotations;

namespace efCourse.Models;

public class Category
{
    [Key]
    public Guid CategoryId { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; }

    public string Description { get; set; }

    // relationship
    public virtual ICollection<Task> Tasks { get; set; }

}