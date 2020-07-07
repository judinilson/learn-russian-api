using System;

namespace learn_Russian_API.Presistence.Entities
{
    public class Statistic
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public  int PercentageCorrectAnswers { get; set; }
        public int PercentageIncorrectAnswers { get; set; }
        public  DateTime TrainingDate { get; set; }
        public  int BackToArticleCount { get; set; }
    }
}