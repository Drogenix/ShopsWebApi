using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ShopsWebApi.Models
{
    public class AuthUser
    {
        [BindRequired]
        [StringLength(14, MinimumLength = 5)]
        public string Login { get; set; }

        [BindRequired]
        [StringLength(24, MinimumLength = 8)]
        public string Password { get; set; }
    }
}