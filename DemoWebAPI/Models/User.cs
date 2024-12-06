using System;
using System.Collections.Generic;

namespace DemoWebAPI.Models;

public partial class User
{
    public int Id { get; set; }

    public string? CreateBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? Password { get; set; }

    public string? UpdateBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? Username { get; set; }

    public int? Status { get; set; }

    public string? Email { get; set; }
}
