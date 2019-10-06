namespace BlazorApp.Models
{
    public interface IRollRange
    {
        int From { get; set; }
        int To { get; set; }
    }
    public class RollRange : IRollRange
    {
        public int From { get; set; }
        public int To { get; set; }
        public string ActionTaken { get; set; }
    }
}
