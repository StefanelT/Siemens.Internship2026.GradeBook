using Siemens.Internship2026.GradeBook.Interfaces;
using Siemens.Internship2026.GradeBook.Models;

namespace Siemens.Internship2026.GradeBook.Repositories;

public class ItemRepository : IItemReader
{
    private readonly HttpClient _httpClient;
    private readonly string Url;

    public ItemRepository(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        Url = configuration["ExternalEndpoint"]!;
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
