using Proiect_DAW.Models.Base;
using Proiect_DAW.Models.Enums;
using System.Text.Json.Serialization;

namespace Proiect_DAW.Models
{
    public class User: BaseEntity
    {
        public string Name { get; set; }
        public string Nickname { get; set; } 
        
        public string Email { get; set; }   
        public string PhoneNumber { get; set; }
        public Role Role { get; set; }

        [JsonIgnore]
        public string PasswordHash { get; set; }
    }
}
