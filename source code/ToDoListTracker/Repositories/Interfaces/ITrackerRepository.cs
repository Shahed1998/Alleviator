﻿using Web.Models.Business_Entities;
using Web.Models.General_Entities;

namespace Web.Repositories.Interfaces
{
    public interface ITrackerRepository
    {
        Task<bool> Add(Tracker model);
        Task<(Pager<Tracker>, decimal?)> GetAll(int pageNumber = 1, int pageSize = 10, string? userId=null);
        Task<Tracker?> GetById(int id);
        Task<int> Delete(int Id);
        Task<int> Edit(Tracker model);
        Task<bool> DeleteAll(string? userId=null);
    }
}
