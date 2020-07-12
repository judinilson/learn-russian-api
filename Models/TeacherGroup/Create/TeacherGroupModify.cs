using System;

namespace learn_Russian_API.Models.TeacherGroup.Create
{
    public class TeacherGroupModify
    {
        public long Id { get; set; }
        public long TeacherId { get; set; }
         public long GroupId { get; set; }
         public TimeSpan teaching_time { get; set; }
    }
}