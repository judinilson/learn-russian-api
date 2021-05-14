using System.Collections.Generic;
using learn_Russian_API.Presistence.Entities;

namespace learn_Russian_API.Models.TrainingContent.Create
{
    public class TrainingContentRequest
    {
        public long CategoryId { get; set; }
        public string Title { get; set; }
        public ICollection<Training> Trainings { get; set; }
        public string Author { get; set; }
        public  AnswerType AnswerTypes { get; set;  }
        public string coverImage { get; set; }

    }
}