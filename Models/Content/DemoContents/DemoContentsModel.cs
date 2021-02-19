namespace learn_Russian_API.Models.Content.DemoContents
{
    public class DemoContentsModel
    {
        public long Id { get; set; }
        public string title { get; set; }
        public string src { get; set;  }
        public long ?DemonstrationContentsId { get; set; }
    }
}