using System.ComponentModel.DataAnnotations;

namespace folder_structure.Models
{
    public class Department
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Budget { get; set; }
        public int EmployeeId { get; set; }
        
    }
}
