namespace MVC_Depency.Models
{
    public class TEST : ITEST
    {
        public Data Data { get; set; }
        public TEST() 
        { 
            Data = new Data();
            GenerateData();
        }
        public Data GenerateData()
        {
            Data.Id = GetHashCode();
            Data.Massege = "Test";
            return Data;
        }
    }
}
