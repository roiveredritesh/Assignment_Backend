using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment.Model
{
    public class DepartmentMaster
    {
        [Key]
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string? DepartmentDescription { get; set; } = string.Empty;

        [ForeignKey("DepartmentId")]
        public ICollection<DocumentCenter> DocumentCenters { get; set; }
    }
}
