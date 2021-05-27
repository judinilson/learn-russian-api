using System.Collections;
using System.Collections.Generic;

namespace learn_Russian_API.Presistence.Entities
{
    public class Training
    {
        public  long Id { get; set; }
        public  string[] Questions { get; set;  }
        public  ICollection<Answer> Answers { get; set; }
        public long TrainingContentId { get; set; } 

        
    }
}