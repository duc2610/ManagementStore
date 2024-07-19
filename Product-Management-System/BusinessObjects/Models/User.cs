﻿using System;
using System.Collections.Generic;

namespace BusinessObjects.Models;

public partial class User
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Fullname { get; set; } = null!;

    public string Email { get; set; } = null!;

    public bool IsActive { get; set; }

    public int RoleId { get; set; }

    public virtual Role Role { get; set; } = null!;
}
