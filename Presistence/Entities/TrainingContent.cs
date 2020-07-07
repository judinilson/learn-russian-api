using System.Collections;
using System.Collections.Generic;

namespace learn_Russian_API.Presistence.Entities
{
    public class TrainingContent
    {
        public  long Id { get; set; }
        public long CategoryId { get; set; }
        public string Title { get; set; }
        public ICollection<Training> Trainings { get; set; }
        public string Author { get; set; }
        public  AnswerType AnswerTypes { get; set;  }
        public string coverImage { get; set; }
    }
}