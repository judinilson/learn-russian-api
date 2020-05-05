using System;
using System.ComponentModel.DataAnnotations;

namespace learn_Russian_API.Models.TeacherGroup.Create
{
    public class TeacherGroup
    {
        public long Id { get; set; }
        public long TeacherId { get; set; }
        public long GroupId { get; set; }
        public TimeSpan teaching_time { get; set; }
    }
}