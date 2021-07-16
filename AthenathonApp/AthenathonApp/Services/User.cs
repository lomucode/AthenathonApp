using System;
using Newtonsoft.Json;

namespace AthenathonApp.Services
{
    public class User
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("userName")]
        public string UserName { get; set; }

        [JsonProperty("normalizedUserName")]
        public string NormalizedUserName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("normalizedEmail")]
        public string NormalizedEmail { get; set; }

        [JsonProperty("emailConfirmed")]
        public bool EmailConfirmed { get; set; }

        [JsonProperty("passwordHash")]
        public string PasswordHash { get; set; }

        [JsonProperty("securityStamp")]
        public string SecurityStamp { get; set; }

        [JsonProperty("concurrencyStamp")]
        public Guid? ConcurrencyStamp { get; set; }

        [JsonProperty("phoneNumber")]
        public object PhoneNumber { get; set; }

        [JsonProperty("phoneNumberConfirmed")]
        public bool PhoneNumberConfirmed { get; set; }

        [JsonProperty("twoFactorEnabled")]
        public bool TwoFactorEnabled { get; set; }

        [JsonProperty("lockoutEnd")]
        public object LockoutEnd { get; set; }

        [JsonProperty("lockoutEnabled")]
        public bool LockoutEnabled { get; set; }

        [JsonProperty("accessFailedCount")]
        public long AccessFailedCount { get; set; }

        [JsonProperty("bild")]
        public object Bild { get; set; }

        [JsonProperty("universitätszugehörigkeit")]
        public object Universitätszugehörigkeit { get; set; }

        [JsonProperty("tatigkeit")]
        public object Tatigkeit { get; set; }

        [JsonProperty("rolleId")]
        public object RolleId { get; set; }

        [JsonProperty("aspNetUserClaims")]
        public object[] AspNetUserClaims { get; set; }

        [JsonProperty("aspNetUserLogins")]
        public object[] AspNetUserLogins { get; set; }

        [JsonProperty("aspNetUserRoles")]
        public object[] AspNetUserRoles { get; set; }

        [JsonProperty("aspNetUserTokens")]
        public object[] AspNetUserTokens { get; set; }
    }
}

