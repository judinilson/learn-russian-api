namespace learn_Russian_API.Presistence.Entities
{
    public class Answer
    {
        public  long Id { get; set; }
        public  bool State { get; set;  }
        public  string Answers { get; set; }
        public long TrainingId { get; set; } 

    }
}