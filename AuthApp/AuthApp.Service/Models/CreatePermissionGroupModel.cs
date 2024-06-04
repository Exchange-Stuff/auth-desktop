﻿namespace AuthApp.Service.Models
{
    public class CreatePermissionGroupModel
    {
        public string Name { get; set; }
        public List<ResourceRecordPermissionValueModel> ResourceRecords { get; set; }
        public List<Guid>? UserIds { get; set; }
    }
    public record ResourceRecordPermissionValueModel(Guid ResourceId, int PermissionValue);

}