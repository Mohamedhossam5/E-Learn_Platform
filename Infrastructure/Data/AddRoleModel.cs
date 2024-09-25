using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Data;
public class AddRoleModel
{
        [Required , StringLength(100)]
        public string UserId { get; set; }
        
        [Required , StringLength(100)]
        public string Role { get; set; }
        
}