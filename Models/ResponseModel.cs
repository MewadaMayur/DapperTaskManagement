namespace SilveOakDemo.Models
{
    public class ResponseModel
    {
        public bool Flag { get; set; }
        public string Message { get; set; } = string.Empty;
        public object Data { get; set; } = null!;
        public int Result { get; set; }
        

       
    }
}
