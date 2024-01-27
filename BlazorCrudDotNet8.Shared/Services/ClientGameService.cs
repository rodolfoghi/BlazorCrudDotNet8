using BlazorCrudDotNet8.Shared.Entities;
using System.Net.Http.Json;

namespace BlazorCrudDotNet8.Shared.Services;
public class ClientGameService : IGameService
{
    private readonly HttpClient _httpClient;

    public ClientGameService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Game> AddGame(Game game)
    {
        var result = await _httpClient.PostAsJsonAsync<Game>("api/game", game);
        return await result.Content.ReadFromJsonAsync<Game>();
    }

    public async Task<bool> DeleteGame(int id)
    {
        var result = await _httpClient.DeleteAsync($"api/game/{id}");
        return await result.Content.ReadFromJsonAsync<bool>();
    }

    public async Task<Game> EditGame(int id, Game game)
    {
        var result = await _httpClient.PutAsJsonAsync<Game>($"api/game/{id}", game);
        return await result.Content.ReadFromJsonAsync<Game>();
    }

    public Task<List<Game>> GetAllGames()
    {
        throw new NotImplementedException();
    }

    public async Task<Game> GetGameById(int id)
    {
        var game = await _httpClient.GetFromJsonAsync<Game>($"api/game/{id}");
        return game!;
    }
}
