using System;
using System.Collections.Generic;

namespace DemoWebAPI.Models;

public partial class JobSystem
{
    public int JobId { get; set; }

    public int SystemId { get; set; }

    public string? Note { get; set; }
}
