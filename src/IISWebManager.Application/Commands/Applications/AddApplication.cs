﻿namespace IISWebManager.Application.Commands.Applications
{
    public class AddApplication : ICommand
    {
        public string Name { get; set; }
        public string PhysicalPath { get; set; }
        public string ApplicationPoolName { get; set; }
        public string SiteName { get; set; }
    }
}