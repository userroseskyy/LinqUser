using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace LinqUser.Services.Login
{
    public class LoginDto
    {
       
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsPersistent {  get; set; }=false;
    }
}
