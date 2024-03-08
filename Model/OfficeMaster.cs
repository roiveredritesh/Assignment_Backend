
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment.Model
{
    public class OfficeMaster
    {
        [Key]
        public int OfficeId { get; set; }
        public string OfficeName { get; set;}
        public string? OfficeDescription { get; set;}

        [ForeignKey("OfficeId")]
        public ICollection<DocumentCenter> DocumentCenters { get; set; }
    }
}
