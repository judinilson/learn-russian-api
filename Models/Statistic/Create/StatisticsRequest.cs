using System;

namespace learn_Russian_API.Models.Statistic.Create
{
    public class StatisticsRequest
    {
        public long UserId { get; set; }
        public  int PercentageCorrectAnswers { get; set; }
        public int PercentageIncorrectAnswers { get; set; }
        public  DateTime TrainingDate { get; set; }
        public  int BackToArticleCount { get; set; }
    }
}