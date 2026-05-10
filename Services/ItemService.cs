using Microsoft.AspNetCore.Mvc;
using Siemens.Internship2026.GradeBook.Interfaces;
using Siemens.Internship2026.GradeBook.Models;

namespace Siemens.Internship2026.GradeBook.Services;

public class ItemService : IItemService
{
    private readonly IItemReader _reader;
    public ItemService(IItemReader reader)
    {
        _reader = reader;
    }

    public async Task<IEnumerable<Grade>> GetFirstNGrades(int n)
    {
        var grades = await _reader.GetAllAsync();
        var result = new List<Grade>();

        foreach (Grade grade in grades)
        {
            if (n <= 0) break;
            if(grade.IsActive && grade.Value >= 5)
            {  
                result.Add(grade);
                n--;
            }
        }
        return result;

    }

    public Statistics GetStatistics(IEnumerable<Grade> passingGrades)
    {
        var grades = passingGrades.ToList();
 
        return new Statistics
        {
            TotalCount = grades.Count,
            AverageValue = grades.Count > 0 ? grades.Average(g => g.Value) : 0,
            RetrievedAt = DateTime.UtcNow
        };
    }

    public async Task<Grade> GetByIdAsync(int id)
    {
        return await _reader.GetByIdAsync(id);
    }
}
