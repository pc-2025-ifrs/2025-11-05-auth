using Steam.Data;
using WebSteam.Models;

namespace WebSteam.Auth;

public class SessionStoreService(SteamDbContext db,
                                 ILogger<SessionStoreService> logger)
{
    
    // Criar Token
    // Validar Token
    // Invalidar Token

    public Session? Validar(string token)
    {
        logger.LogInformation("Validando o Token {}", token);
        return db.Sessions.Where(s => s.Token == token)
            .FirstOrDefault();
    }

}