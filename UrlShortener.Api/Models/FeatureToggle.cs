﻿namespace UrlShortener.Api.Models
{
    public class FeatureToggle
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool Status { get; set; }
    }
}
