﻿using System;
using System.Collections.Generic;
using System.Text;
using BashSoft.Attributes;
using BashSoft.Contracts;
using BashSoft.Exceptions;

namespace BashSoft.IO.Commands
{
    [Alias("show")]
    class ShowCourseCommand : Command
    {
        [Inject]
        private IDatabase Repository;
        public ShowCourseCommand(string input, string[] data) : base(input, data)
        {

        }

        public override void Execute()
        {
            if (this.Data.Length != 2 && this.Data.Length != 3)
            {
                throw new InvalidCommandException(this.Input);
            }
            if (this.Data.Length == 2)
            {
                string courseName = this.Data[1];
                this.Repository.GetAllStudentsFromCourse(courseName);
            }
            else if (this.Data.Length == 3)
            {
                string courseName = this.Data[1];
                string userName = this.Data[2];
                this.Repository.GetStudentScoresFromCourse(courseName, userName);
            }
            
        }
    }
}
