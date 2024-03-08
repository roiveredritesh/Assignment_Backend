using Assignment.Data;
using Assignment.Model;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace Assignment.Repository
{
    public class DocumentCenterRL : IDocumentCenterRL
    {
        public readonly AppDBContext _appDBContext;

        public DocumentCenterRL(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
        public async Task<DocumentCenter> AddDocumentCenter(Create_DocumentCenter create_DocumentCenter)
        {
            #region Save File
            string foldername = Path.Combine("Resource", "DocumentCenter");
            string directorypath = Path.Combine(Directory.GetCurrentDirectory(), foldername);
            if (!Directory.Exists(directorypath))
            {
                Directory.CreateDirectory(directorypath);
            }
            string filename = create_DocumentCenter.File.FileName;
            string fullpath = Path.Combine(directorypath, filename);
            string dbpath = Path.Combine(foldername, filename);
            string fileType = Path.GetExtension(fullpath).Replace(".", "");

            using (var stream = new FileStream(fullpath, FileMode.Create))
            {
                create_DocumentCenter.File.CopyTo(stream);
            }
            #endregion

            DocumentCenter documentCenter = new DocumentCenter
            {
                Id = 0,
                FileName = create_DocumentCenter.FileName,
                FilePath = dbpath,
                DivisionId = create_DocumentCenter.DivisionId,
                DepartmentId = create_DocumentCenter.DepartmentId,
                OfficeId = create_DocumentCenter.OfficeId,
                Folder = create_DocumentCenter.Folder,
                ModifiedBy = create_DocumentCenter.ModifiedBy,
                ModifiedDate = DateTime.UtcNow,
                Type = fileType,
                UploadedFileName = filename
            };
            _appDBContext.DocumentCenters.Add(documentCenter);
            await _appDBContext.SaveChangesAsync();
            return documentCenter;
        }

        public async Task<bool> DeleteDocumentCenter(int id)
        {
            var documentCenter = await _appDBContext.DocumentCenters.FirstOrDefaultAsync(p => p.Id == id);
            if (documentCenter == null)
                return false;

            _appDBContext.DocumentCenters.Remove(documentCenter);
            _appDBContext.SaveChanges();
            return true;
        }

        public async Task<DocumentCenter> GetDocumentCenter(int id)
        {
            var documentCenter = await _appDBContext.DocumentCenters.FirstOrDefaultAsync(p => p.Id == id);
            if (documentCenter == null)
                return null;
            return documentCenter;
        }

        public async Task<List<DocumentCenterList>> GetDocumentCenters()
        {
            var item = await (from dc in _appDBContext.DocumentCenters
                              join depart in _appDBContext.DepartmentMasters on dc.DepartmentId equals depart.DepartmentId
                              join division in _appDBContext.DivisionMasters on dc.DivisionId equals division.DivisionId
                              join office in _appDBContext.OfficeMasters on dc.OfficeId equals office.OfficeId
                              select new DocumentCenterList
                              {
                                  Id = dc.Id,
                                  FileName = dc.FileName,
                                  FilePath = dc.FilePath,
                                  Type = dc.Type,
                                  Folder = dc.Folder,
                                  ModifiedBy = dc.ModifiedBy,
                                  ModifiedDate = dc.ModifiedDate,
                                  DepartmentName = depart.DepartmentName,
                                  DivisionName = division.DivisionName,
                                  OfficeName = office.OfficeName,
                                  UploadedFileName=dc.UploadedFileName,
                              }).ToListAsync();
            return item;
        }

        public async Task<DocumentCenter> UpdateDocumentCenter(int id, Update_DocumentCenter update_DocumentCenter)
        {
            var documentCenter = await _appDBContext.DocumentCenters.FirstOrDefaultAsync(p => p.Id == id);
            if (documentCenter == null)
                return null;


            #region Save File

            if (update_DocumentCenter.File != null)
            {
                string foldername = Path.Combine("Resource", "DocumentCenter");
                string directorypath = Path.Combine(Directory.GetCurrentDirectory(), foldername);
                if (!Directory.Exists(directorypath))
                {
                    Directory.CreateDirectory(directorypath);
                }
                string filename = update_DocumentCenter.File.FileName;
                string fullpath = Path.Combine(directorypath, filename);
                string dbpath = Path.Combine(foldername, filename);
                string fileType = Path.GetExtension(fullpath).Replace(".", "");

                using (var stream = new FileStream(fullpath, FileMode.Create))
                {
                    update_DocumentCenter.File.CopyTo(stream);
                }

                documentCenter.Type = fileType;
                documentCenter.FilePath = dbpath;
                documentCenter.UploadedFileName = filename;
            }

            #endregion

            documentCenter.DivisionId = update_DocumentCenter.DivisionId;
            documentCenter.OfficeId = update_DocumentCenter.OfficeId;
            documentCenter.DepartmentId = update_DocumentCenter.DepartmentId;
            documentCenter.FileName = update_DocumentCenter.FileName;
            documentCenter.Folder = update_DocumentCenter.Folder;
            documentCenter.ModifiedBy = update_DocumentCenter.ModifiedBy;
            documentCenter.ModifiedDate = DateTime.UtcNow;
            await _appDBContext.SaveChangesAsync();
            return documentCenter;
        }


        #region Get Division, Department, Offices

        public async Task<List<DepartmentMaster>> GetDepartments()
        {
            return await _appDBContext.DepartmentMasters.ToListAsync();
        }
        public async Task<List<DivisionMaster>> GetDivisions()
        {
            return await _appDBContext.DivisionMasters.ToListAsync();
        }
        public async Task<List<OfficeMaster>> GetOffices()
        {
            return await _appDBContext.OfficeMasters.ToListAsync();
        }
        #endregion
    }
}
