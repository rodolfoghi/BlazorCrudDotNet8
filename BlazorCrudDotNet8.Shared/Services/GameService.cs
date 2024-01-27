using BlazorCrudDotNet8.Shared.Data;
using BlazorCrudDotNet8.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorCrudDotNet8.Shared.Services;

public class GameService : IGameService
{
    private readonly DataContext _context;

    public GameService(DataContext context)
    {
        _context = context;
    }

    public async Task<Game> AddGame(Game game)
    {
        _context.Games.Add(game);
        await _context.SaveChangesAsync();

        return game;
    }

    public async Task<bool> DeleteGame(int id)
    {
        var dbGame = await _context.Games.FindAsync(id);
        if (dbGame == null)
        {
            return false;
        }

        _context.Remove(dbGame);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<Game> EditGame(int id, Game game)
    {
        var dbGame = await _context.Games.FindAsync(id) ?? throw new Exception("Game not found");
        dbGame.Name = game.Name;
        await _context.SaveChangesAsync();
        return dbGame;
    }

    public async Task<List<Game>> GetAllGames()
    {
        await Task.Delay(1000);
        var games = await _context.Games.ToListAsync();
        return games;
    }

    public async Task<Game> GetGameById(int id)
    {
        var game = await _context.Games.FindAsync(id);
        return game!;
    }
}