﻿namespace TestDataBase1to1toMany.Models
{
    public class Feature
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Component Component { get; set; }
    }
}
