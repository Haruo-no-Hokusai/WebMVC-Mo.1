﻿namespace TestDataBase1to1toMany.Models
{
    public class Component
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int FeatureId { get; set; }
        public Feature Feature { get; set; }
    }
}
