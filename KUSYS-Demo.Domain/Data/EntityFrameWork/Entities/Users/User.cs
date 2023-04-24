using KUSYS_Demo.Infrasturcture.Enums;

namespace KUSYS_Demo.Domain.Data.EntityFrameWork.Entities.Users;

/// <summary>
/// 
/// </summary>
public class User : BaseEntity
{
    public string Name { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    
    // That column must be encrypted.
    public string Password { get; set; }
    public UserTypeEnum Type { get; set; }
}