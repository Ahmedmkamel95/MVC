using System.ComponentModel.DataAnnotations;

namespace folder_structure.Models
{
    public class Employee
    {
        [Required]
        public int Id  { get; set; }
        public string Name  { get; set; }
        public string Description  { get; set; }
        public int Salary  { get; set; }
       
    }
}
