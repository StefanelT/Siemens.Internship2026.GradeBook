using Siemens.Internship2026.GradeBook.Interfaces;
using Siemens.Internship2026.GradeBook.Models;

namespace Siemens.Internship2026.GradeBook.Repositories;

public class ItemRepository : IItemReader
{
    private readonly HttpClient _httpClient;
    private const string Url = "https://gist.githubusercontent.com/ArdeleanTudor/8ea407832cd9794960e0e6bbd1319f6e/raw";

    public ItemRepository(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<Grade>> GetAllAsync()
    {
        var response = await _httpClient.GetFromJsonAsync<Response>(Url);
        if (response == null)
        {
            return new List<Grade>();
        }
        return response.Items;
    }

    public async Task<Grade?> GetByIdAsync(int id)
    {
        var items = await GetAllAsync();
        return items.FirstOrDefault(i => i.Id == id);
    }
}
