using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using api_filmes_senai.Domains;
using api_filmes_senai.DTO;
using api_filmes_senai.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace api_filmes_senai.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public LoginController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpPost]

        public IActionResult Login(LoginDTO LoginDTO)
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepository.BuscarPorEmailESenha(LoginDTO.Email, LoginDTO.Senha);

                    if (usuarioBuscado == null)
                {
                    return NotFound("Usuario nao encontrado, email ou senha invalidos!");
                }

                // 1 passo- 
                var claims = new[]
                {

                    new Claim (JwtRegisteredClaimNames.Jti,usuarioBuscado.IdUsuario.ToString()),
                    new Claim (JwtRegisteredClaimNames.Email,usuarioBuscado.Email!),
                    new Claim (JwtRegisteredClaimNames.Name,usuarioBuscado.Nome!),

                    new Claim("Nome da Claim","Valor da Claim")
                };

                // definir a chave de acesso do token
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("filmes-chave-autentificacao-webapi-dev"));


                // Definir as credenciais do token (HEADER)
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                // Gerar o Token
                var token = new JwtSecurityToken
                (
                    //emissor 
                    issuer: "api_filmes_senai",

                    //destinatario
                    audience: "api_filmes_senai",

                    //dados definidos nas claims
                    claims: claims,

                    //tempo de expiracao do teken
                    expires: DateTime.Now.AddMinutes(5),

                    signingCredentials: creds

                );

                return Ok(
                    new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token)
                    });



            }
            catch (Exception)
            {

                throw;
            }
        }

    }

}
