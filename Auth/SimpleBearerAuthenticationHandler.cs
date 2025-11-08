using System.Security.Claims;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;

namespace WebSteam.Auth;

class Animal { }
class Mamifero : Animal { }
class Gato : Mamifero { }

public class SimpleBearerAuthenticationHandler(
    ILogger<SimpleBearerAuthenticationHandler> logger,
    IOptionsMonitor<AuthenticationSchemeOptions> options,
    ILoggerFactory loggerFactory,
    UrlEncoder urlEncoder,
    SessionStoreService sessionStoreService
)
    : AuthenticationHandler<AuthenticationSchemeOptions>(options, loggerFactory, urlEncoder)
{

    protected override Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        //                       TOKEN
        // Authorization: Bearer 61f76126a8b6e8778f87d8
        // 0123456789012...
        // Existe o header Authorization
        if (!Request.Headers.ContainsKey("Authorization"))
        {
            return Task.FromResult(AuthenticateResult.Fail("Falta o header Authorization"));
        }

        var bearer = Request.Headers.Authorization.ToString() ?? "";

        if (!bearer.StartsWith("Bearer"))
        {
            return Task.FromResult(AuthenticateResult.Fail("Falta o Bearer"));
        }

        var token = bearer[7..];

        var session = sessionStoreService.Validar(token);
        // checar o token em "algum" lugar: memória, banco de dados (sql, chave-valor -- redis), outro sistema

        if (session == null)
        {
            return Task.FromResult(AuthenticateResult.Fail("Sessão não existente"));
        }

        if (session.ExpiresAt < DateTime.UtcNow)
        {
            return Task.FromResult(AuthenticateResult.Fail("Sessão expirada"));
        }
        // claim: alegação -> fato
        var claims = new Claim[]
        {
            new(ClaimTypes.Role, "USER"),
            new(ClaimTypes.Name, session.User),
            new("id", Guid.NewGuid().ToString())
        };
        // identidade
        var claimsIdentity = new ClaimsIdentity(claims);
        // principal (user)
        var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
        // ticket
        var ticket = new AuthenticationTicket(claimsPrincipal, Scheme.Name);

        logger.LogInformation("Iniciando sessão com o Ticket {}", ticket);
        return Task.FromResult(AuthenticateResult.Success(ticket));
    }
}