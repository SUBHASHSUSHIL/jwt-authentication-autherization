﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace JWT_Authentication_Autherization.Models;

public partial class Login
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string MobileNo { get; set; }

    public string EmailId { get; set; }

    public string Password { get; set; }

    public int? RoleId { get; set; }

    public virtual Role Role { get; set; }
}