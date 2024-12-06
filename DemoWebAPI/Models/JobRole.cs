using System;
using System.Collections.Generic;

namespace DemoWebAPI.Models;

public partial class JobRole
{
    public int JobId { get; set; }

    public int RoleId { get; set; }

    public string? Note { get; set; }
}
