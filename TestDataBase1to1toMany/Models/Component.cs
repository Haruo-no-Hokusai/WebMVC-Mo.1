﻿namespace TestDataBase1to1toMany.Models
{
    public class Component
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ProductExtend ProductExtend { get; set; }
        public int FeatureId { get; set; }
        public Feature Feature { get; set; }
        public List<ComponentToProduct> Connection { get; set; }
    }
}
