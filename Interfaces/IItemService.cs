using Microsoft.AspNetCore.Mvc;
using Siemens.Internship2026.GradeBook.Models;

namespace Siemens.Internship2026.GradeBook.Interfaces
{
    public interface IItemService
    {
        Task<Grade> GetByIdAsync(int id);
        Task<IEnumerable<Grade>> GetFirstNGrades(int n); 
        Statistics GetStatistics(IEnumerable<Grade> passingGrades);
    }
}

