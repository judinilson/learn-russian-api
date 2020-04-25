﻿using System;
using System.ComponentModel.DataAnnotations;

namespace learn_Russian_API.Models.TeacherGroup.Create
{
    public class TeacherGroup
    {
        
        [Required] public long TeacherId { get; set; }
        [Required] public long GroupId { get; set; }
        public TimeSpan teaching_time { get; set; }
    }
}