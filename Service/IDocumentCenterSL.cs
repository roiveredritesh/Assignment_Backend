﻿using Assignment.Model;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.Service
{
    public interface IDocumentCenterSL
    {
        Task<List<DocumentCenterList>> GetDocumentCenters();
        Task<DocumentCenter> GetDocumentCenter(int id);
        Task<DocumentCenter> AddDocumentCenter(Create_DocumentCenter create_DocumentCenter);
        Task<DocumentCenter> UpdateDocumentCenter(int id,Update_DocumentCenter update_DocumentCenter);
        Task<bool> DeleteDocumentCenter(int id);



        //get divisions

        Task<List<DivisionMaster>> GetDivisions();

        //get departments

        Task<List<DepartmentMaster>> GetDepartments();

        //get office

        Task<List<OfficeMaster>> GetOffices();
    }
}
