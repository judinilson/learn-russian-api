using System.Collections.Generic;
using learn_Russian_API.Presistence.Entities;

namespace learn_Russian_API.Models.TrainingContent.Create
{
    public class TrainingRequest
    {
        public  string[] Questions { get; set;  }
        public  ICollection<AnswersRequest> Answers { get; set; }
    }
}