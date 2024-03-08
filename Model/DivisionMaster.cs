using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment.Model
{
    public class DivisionMaster
    {
        [Key]
        public int DivisionId { get; set; }
        public string DivisionName { get; set; }

        [ForeignKey("DivisionId")]
        public ICollection<DocumentCenter> DocumentCenters { get; set; }
    }
}
