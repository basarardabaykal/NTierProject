﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Dto;

public class UserDTO
{
    public Guid Id { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Tcnumber { get; set; }
    public string Email { get; set; }
    public Guid? CompanyId { get; set; }
    public List<string> Roles { get; set; }
}
