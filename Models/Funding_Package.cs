﻿namespace ReGenerationProjectAssignment_FundRaiser.Models
{
    public class Funding_Package
    {
        public int PackageID { get; set; }
        public Project Project { get; set; }
        public string PackageName { get; set; }
        public int PackageValue { get; set; }
        public string PackageRewared { get; set; }
    }
}
