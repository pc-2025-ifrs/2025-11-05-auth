Program
- Adicionar UseAuthentication e UseAuthorization

Controller
- Adicionar annotation [Authorize]

Program
- Adicionar Authorization (pretty straightforward)
- Adicionar Authentication exige adicionar AuthenticationScheme, precisa de um AuthenticationHandler (Middleware)

Criar um BearerAuthenticationHandler
- Localizar o header Authorization (qualquer coisa que falte deve retornar fail: Task.FromResult(AuthenticateResult.Fail))
- Obter o Bearer do Header
- Verificar se existe o Bearer na Sessão (mas onde armazenar a Sessão? Precisa de um SessionStoreService)

Criar um SessionStoreService
- Tradeoffs in memory, in sql database, in nosql
- Criar um Session model (assegurar o token como key e indexar o Expires [Index(nameof(ExpiresAt))])
- Adicioná-lo ao DbContext
- No Service disponibilizar métodos para criar, validar (e excluir uma sessão, opcionalmente)
- Não esquecer de registrar o SessionStoreService no Program

Voltando ao BearerAuthenticationHandler
- Verificar o Bearer contra o SessionStoreService
- Se ok, criar um Array de Claims (são fatos, alegações)
- dos claims criar um ClaimsIdentity (o Scheme foi definido no Program)
- dos ClaimsIdentity criar ClaimPrincipal
- isso vair gerar um User no objeto HttpContext
HttpContext.User  →  ClaimsPrincipal
                        └── ClaimsIdentity
                                 └── Claim[]

Autenticar usuário
- Criar um AuthController, como um ApiController
- Implementar um login endpoint
- Recebe um LoginRequest (built-in credential object)
- O método cria uma sessão, devolve o token, ou retorna Unauthorized