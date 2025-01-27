﻿using AuthApp.Service.DTOs;

namespace AuthApp.Service.Models
{
    public class UserAddGroupPermission
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public List<PermissionGroupDTO> PermissionGroups { get; set; }
    }
}
