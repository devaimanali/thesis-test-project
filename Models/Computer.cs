using System.ComponentModel.DataAnnotations;

namespace thesis_exercise.Models
{
    public class Computer
    {
        public int ComputerID { get; set; }

        [Required(ErrorMessage = "RAM is required")]
        [StringLength(50, ErrorMessage = "RAM cannot be longer than 50 characters")]
        public string RAM { get; set; }

        [Required(ErrorMessage = "Disk Space is required")]
        [StringLength(50, ErrorMessage = "Disk Space cannot be longer than 50 characters")]
        public string DiskSpace { get; set; }

        [Required(ErrorMessage = "Processor is required")]
        [StringLength(100, ErrorMessage = "Processor cannot be longer than 100 characters")]
        public string Processor { get; set; }

        [Required(ErrorMessage = "Ports are required")]
        [StringLength(100, ErrorMessage = "Ports cannot be longer than 100 characters")]
        public string Ports { get; set; }
    }
}
