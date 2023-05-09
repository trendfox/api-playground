using ApiPlayground.P03.Auth;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;

internal class BearerAuthenticationHandler
    : AuthenticationHandler<AuthenticationSchemeOptions>
{
    public BearerAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock)
        : base(options, logger, encoder, clock)
    {
    }

    protected override Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        var authHeader = Request.Headers.Authorization
            .ToString();

        if (string.IsNullOrEmpty(authHeader))
            return Task.FromResult(
                AuthenticateResult
                    .Fail("Missing authorization header."));

        if (!authHeader.StartsWith($"{AuthSchemas.Basic} ", StringComparison.OrdinalIgnoreCase))
            return Task.FromResult(
                AuthenticateResult
                    .Fail($"Authorization header not supported, use '{AuthSchemas.Basic}'"));

        var encodedHeader = authHeader
            .Replace($"{AuthSchemas.Basic} ", "", StringComparison.OrdinalIgnoreCase);

        var encodedBytes = Convert.FromBase64String(encodedHeader);
        var decodedHeader = Encoding.UTF8.GetString(encodedBytes);

        var parts = decodedHeader.Split(":");

        if (parts.Length != 2)
            return Task.FromResult(
                AuthenticateResult.Fail("Invalid authorization header."));

        var user = parts[0];
        var pass = parts[1];

        // Use service/configuration/database here
        if (user == "max" && pass == "asdf")
            return Task.FromResult(
                AuthenticateResult.Success(CreateTicket(user)));

        return Task
            .FromResult(AuthenticateResult.Fail("User or password incorrect."));
    }

    private AuthenticationTicket CreateTicket(string user)
    {
        var claims = new[] {
            new Claim(ClaimTypes.Name, user)
        };

        var id = new ClaimsIdentity(claims, AuthSchemas.Basic);
        var principal = new ClaimsPrincipal(id);

        return new AuthenticationTicket(principal, AuthSchemas.Basic);
    }
}