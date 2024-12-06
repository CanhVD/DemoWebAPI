using System;
using System.Collections.Generic;

namespace DemoWebAPI.Models;

public partial class Job
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Decription { get; set; }
}
