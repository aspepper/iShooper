using System;
using System.ComponentModel.DataAnnotations;
using FluentValidation;
using Ishooper.Api.Models;
using Newtonsoft.Json;

namespace ishooper.com.Models
{
    public class UserData
    {

        [JsonProperty("id")]
        public string Id { get; set; } = string.Empty;

        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("login")]
        public string UserLogon { get; set; } = string.Empty;

        [JsonProperty("password")]
        public string Password { get; set; } = string.Empty;

        [JsonProperty("email")]
        public string Email { get; set; } = string.Empty;

        [JsonProperty("profile")]
        public int Profile { get; set; } = 0;

        [JsonProperty("occupation")]
        public string Occupation { get; set; } = string.Empty;

        [JsonProperty("url_foto")]
        public string URLPhoto { get; set; } = string.Empty;

        [JsonProperty("telephone")]
        public string Telephone { get; set; } = string.Empty;

        [JsonProperty("gender")]
        public string Gender { get; set; } = string.Empty;

        [JsonProperty("is_deleted")]
        public bool IsDeleted { get; set; } = false;

        [JsonProperty("created_date")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [JsonProperty("modified_date")]
        public DateTime ModifiedDate { get; set; } = DateTime.Now;

        [JsonProperty("deleted_date")]
        public DateTime DeletedDate { get; set; } = DateTime.MinValue;

    }

    public class UserRequest
    {

        [JsonProperty("id")]
        public string Id { get; set; }

        [Required]
        [JsonProperty("name")]
        public string Name { get; set; }

        [Required]
        [JsonProperty("logon")]
        public string Logon { get; set; }

        [Required]
        [JsonProperty("password")]
        public string Password { get; set; }

        [Required]
        [JsonProperty("email")]
        public string Email { get; set; }

        [Required]
        [JsonProperty("gender")]
        public string Gender { get; set; }

        [Required]
        [JsonProperty("telephone")]
        public string Telephone { get; set; }

        [Required]
        [JsonProperty("profile")]
        public int Profile { get; set; }

        [Required]
        [JsonProperty("occupation")]
        public string Occupation { get; set; }

        [JsonProperty("urlphoto")]
        public string UrlPhoto { get; set; }

    }

    public class UserValidator : AbstractValidator<UserRequest>
    {
        public UserValidator()
        {
            RuleFor(data => data.Email)
                .Matches(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$")
                    .WithMessage("Email Inválivo")
                .NotEmpty() // <-- and cant be empty
                    .WithMessage("Email Inválido");
        }
    }

    public class UserResponse
    {

        [JsonProperty("UserID")]
        public string Id { get; set; }

    }


    public class LoginRequest
    {

        [Required]
        [JsonProperty("login")]
        public string Login { get; set; }

        [Required]
        [JsonProperty("password")]
        public string Password { get; set; }

    }

    public class LoginResponse
    {

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("user_data")]
        public UserData User { get; set; }

    }

}
