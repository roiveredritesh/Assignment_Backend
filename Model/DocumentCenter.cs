using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace Assignment.Model
{

    public class DocumentCenter
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string UploadedFileName { get; set; }
        public string? Type { get; set; }
        public string? Folder { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public int DepartmentId { get; set; }
        
        public DepartmentMaster? departmentMaster { get; set; }

        public int DivisionId { get; set; }
       
        public DivisionMaster? divisionMaster { get; set; }


        public int OfficeId { get; set; }
        
        public  OfficeMaster? officeMaster { get; set; }
    }


    public class Create_DocumentCenter
    {
        public string FileName { get; set; }
        public IFormFile File { get; set; }
        public int DivisionId { get; set; }
        public int DepartmentId { get; set; }
        public int OfficeId { get; set; }
        public string? Folder { get; set; }
        public string ModifiedBy { get; set; }
    }

    public class Update_DocumentCenter
    {
        public string FileName { get; set; }
        public IFormFile? File { get; set; }
        public int DivisionId { get; set; }
        public int DepartmentId { get; set; }
        public int OfficeId { get; set; }
        public string? Folder { get; set; }
        public string ModifiedBy { get; set; }
    }

    public class DocumentCenterList
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string? Type { get; set; }
        public string DivisionName { get; set; }
        public string DepartmentName { get; set; }
        public string OfficeName { get; set; }
        public string? Folder { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedDate { get; set; }
        public string UploadedFileName { get; set; }
    }
}
