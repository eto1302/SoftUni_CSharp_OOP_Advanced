using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BashSoft.Contracts;

namespace BashSoft
{
    public  class RepositoryFilter : IDataFilter
    {
        public  void FilterAndTake(Dictionary<string, double> studentsWithMarks, string wantedFilter,
            int studentsToTake)
        {
            if (wantedFilter == "excellent")
            {
                FilterAndTake(studentsWithMarks,x => x >= 5,studentsToTake);
            }
            else if (wantedFilter == "average")
            {
                FilterAndTake(studentsWithMarks, x => x < 5 && x >= 3.5, studentsToTake);
            }
            else if (wantedFilter == "poor")
            {
                FilterAndTake(studentsWithMarks, x => x < 3.5, studentsToTake);
            }
            else
            {
                throw new Exception(ExceptionMessages.InvalidStudentFilter);
                
            }
        }

        private  void FilterAndTake(Dictionary<string, double> studentsWithMarks, Predicate<double> givenFilter,
            int studentstToTake)
        {
            int counterForPrinted = 0;
            foreach (var studentMark in studentsWithMarks)
            {
                if (counterForPrinted == studentstToTake)
                {
                    break;
                }
                
                if (givenFilter(studentMark.Value))
                {
                    OutputWriter.PrintStudent(new KeyValuePair<string, double>(studentMark.Key,studentMark.Value));
                    
                    counterForPrinted++;
                }
            }
        }

        

        private  double Average(List<int> scoresOnTasks)
        {
            int totalScore = 0;
            foreach (var score in scoresOnTasks)
            {
                totalScore += score;

            }
            double percentageOfAll = totalScore / (scoresOnTasks.Count * 100.0);
            double mark = percentageOfAll * 4 + 2;
            
            return mark;
        }
    }
}
