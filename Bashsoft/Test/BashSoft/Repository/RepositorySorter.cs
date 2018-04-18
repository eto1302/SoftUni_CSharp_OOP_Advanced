using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using BashSoft.Contracts;

namespace BashSoft
{
    public  class RepositorySorter : IDataSorter
    {
        public void OrderAndTake(Dictionary<string, double> studentsWithMarks, string comparison, int studentsToTake)
        {
            comparison = comparison.ToLower();
            if (comparison == "ascending")
            {
                this.PrintStudents(studentsWithMarks.OrderBy(x => x.Value).Take(studentsToTake).ToDictionary(pair => pair.Key, pair => pair.Value));
            }
            else if (comparison == "descending")
            {
                PrintStudents(studentsWithMarks.OrderByDescending(x => x.Value)
                    .Take(studentsToTake)
                    .ToDictionary(pair => pair.Key, pair => pair.Value));
            }
            else
            {
                throw new Exception(ExceptionMessages.InvalidComparisonQuery);
                
            }
        }
        private  void PrintStudents(Dictionary<string, double> studentsSorted)
        {
            
            foreach (var element in studentsSorted)
            {
                OutputWriter.PrintStudent(element);
            }
        }
        
    }
}
