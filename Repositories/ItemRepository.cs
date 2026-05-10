using Siemens.Internship2026.GradeBook.Interfaces;
using Siemens.Internship2026.GradeBook.Models;

namespace Siemens.Internship2026.GradeBook.Repositories;

public class ItemRepository : IItemReader
{
    private readonly HttpClient _httpClient;
    private const string Url = "https://pastebin.com/raw/deL5hc3p";

    public ItemRepository(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<Grade>> GetAllAsync()
    {
        var items = await _httpClient.GetFromJsonAsync<List<Grade>>(Url);
        if (items == null)
        {
            return new List<Grade>();
        }
        return items;
    }

    public async Task<Grade?> GetByIdAsync(int id)
    {
        var items = await GetAllAsync();
        return items.FirstOrDefault(i => i.Id == id);
    }
}
