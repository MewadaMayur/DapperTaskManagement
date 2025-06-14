namespace SilveOakDemo.Models
{
    public class Tasks
    {
        public int taskid { get; set; }
        public string title { get; set; } = string.Empty;
        public string description { get; set; } = string.Empty;
        
        public string status { get; set; } = string.Empty; 
        public int assignedid { get; set; } // Foreign key to User
    }
}
