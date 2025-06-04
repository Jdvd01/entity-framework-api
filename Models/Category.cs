// using System.ComponentModel.DataAnnotations;
// using System.ComponentModel.DataAnnotations.Schema;

namespace efCourse.Models;

// [Table("Categories")]
public class Category
{
    // [Key]
    public Guid CategoryId { get; set; }

    // [Required]
    // [MaxLength(50)]
    public string Name { get; set; }

    public string Description { get; set; }

    // relationship
    public virtual ICollection<Task> Tasks { get; set; }

}