using System.ComponentModel.DataAnnotations;

namespace WebSteam.Models;

public class Session
{

    [Key]
    public string Token { get; set; } = string.Empty;

    public string User { get; set; } = string.Empty;

    // Universal Coordinated Time: 00:00
    // Greenwich Meridian Time
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime ExpiresAt { get; set; } = DateTime.UtcNow.AddMinutes(1);


}