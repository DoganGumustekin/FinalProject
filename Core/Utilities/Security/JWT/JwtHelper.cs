using Core.Entities.Concrete;
using Core.Extensions;
using Core.Utilities.Security.Encryption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.JWT
{
    public class JwtHelper : ITokenHelper
    {
        public IConfiguration Configuration { get; } //apideki appsettings i okur. 
        private TokenOptions _tokenOptions; //appsettings ten okuduğum değerleri bir nesneye atayacağım.
        private DateTime _accessTokenExpiration; //accestoken nezaman geçersizleşecek 
        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>(); //configuration(appsettings) bölümü tokenoptions bölümünü al.
                                                                                          //appsettings teki nesneleri tokenoptionstaki objelere tek tek at.
        }

        public AccessToken CreateToken(User user, List<OperationClaim> operationClaims) //bana user ve claimleri ver ben bunlara göre bir token oluşturayım.
        {
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration); //10 dk yazmıştık appsettingse onu atıyoruz.
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey); //benim bi securitykey e ihtiyacım var tokenoptions taki securitykeyi kullanarak keyi oluşturabilrisin.
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey); //burada da hangi algoritma ve anahtar nedir sorusunu cevaplıyoruz.
            var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials, operationClaims); //aşşağıdaki metthod ile biz tokenoptionları kullanarak ilgili kullanıcı için ilgili cridential leri kullanarak bu adama atanacak claimleri yetkileri içeren bir method yazmışım.
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };
        }

        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, User user,
            SigningCredentials signingCredentials, List<OperationClaim> operationClaims)
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,         //burada bulunan bütün bilgileri oluşturuyoruz. 
                expires: _accessTokenExpiration,
                notBefore: DateTime.Now,                 //şu andan önceki bir değer verilemez.
                claims: SetClaims(user, operationClaims), //claimler bizim için önemli onlar içinde bir method yaptım. setclaims kullanıcı bilgisi ve claimlerini alarak bana bir tane claim listesi oluştur.
                signingCredentials: signingCredentials
            );
            return jwt;
        }

        //claimlerin oluşturulması: 

        private IEnumerable<Claim> SetClaims(User user, List<OperationClaim> operationClaims)
        {
            var claims = new List<Claim>(); //Claim .net içinde olan birşey
            claims.AddNameIdentifier(user.Id.ToString()); //kullanıcı idi
            claims.AddEmail(user.Email); //emaili
            claims.AddName($"{user.FirstName} {user.LastName}");//burdaki kullanım iki tane str yi yanyana göstermek için kullanılır başına $ eklersem içine kod yazabiliyorum. 
            claims.AddRoles(operationClaims.Select(c => c.Name).ToArray()); //kullanıcının veritabanından çektiğim claimlerinin(rolleri) namelerini çekip arreye basıp rolleri ekliyorum.

            return claims;
        }
    }
}
