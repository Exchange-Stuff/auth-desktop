﻿namespace AuthApp.Service.DTOs
{
    public class PermissionDTO
    {
        public Guid Id { get; set; }
        public int PermissionValue { get; set; }
        public PermissionGroupDTO PermissionGroup { get; set; }
        public ResourceDTO Resource { get; set; }
    }
}
