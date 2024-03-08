
using Assignment.Data;
using Assignment.Model;
using Assignment.Repository;
using Microsoft.EntityFrameworkCore;

namespace Assignment.Service
{
    public class DocumentCenterSL : IDocumentCenterSL
    {

        public readonly IDocumentCenterRL _DocumentCenterRL;
        public DocumentCenterSL(IDocumentCenterRL documentCenterRL)
        {
            _DocumentCenterRL = documentCenterRL;
        }

        public async Task<DocumentCenter> AddDocumentCenter(Create_DocumentCenter create_DocumentCenter)
        {
            DocumentCenter documentCenter = await _DocumentCenterRL.AddDocumentCenter(create_DocumentCenter);
            return documentCenter;
        }

        public async Task<bool> DeleteDocumentCenter(int id)
        {
            bool result = await _DocumentCenterRL.DeleteDocumentCenter(id);
            return result;
        }

       

       

        public async Task<DocumentCenter> GetDocumentCenter(int id)
        {
            var documentCenter = await _DocumentCenterRL.GetDocumentCenter(id);
            return documentCenter;
        }

        public async Task<List<DocumentCenterList>> GetDocumentCenters()
        {
            return await _DocumentCenterRL.GetDocumentCenters();
        }

        public async Task<DocumentCenter> UpdateDocumentCenter(int id, Update_DocumentCenter update_DocumentCenter)
        {
            var documentCenter = await _DocumentCenterRL.UpdateDocumentCenter(id, update_DocumentCenter);
            return documentCenter;
        }

        #region Get Division, Department, Offices

        public async Task<List<DepartmentMaster>> GetDepartments()
        {
            return await _DocumentCenterRL.GetDepartments();
        }
        public async Task<List<DivisionMaster>> GetDivisions()
        {
            return await _DocumentCenterRL.GetDivisions();
        }
        public async Task<List<OfficeMaster>> GetOffices()
        {
            return await _DocumentCenterRL.GetOffices();
        } 
        #endregion
    }
}
