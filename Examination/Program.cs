using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            QuestionList Qlist = new QuestionList();

            AnswerList tof = new AnswerList();
                tof.AddRange(new Answer[] { new Answer("true"), new Answer("false") });

            AnswerList ans = new AnswerList();
                ans.Add( new Answer("true"));

            Question tf = new TrueOrFalse("is that you", tof, ans, 10);
            Qlist.Add( tf);
            Qlist.Add(new TrueOrFalse("is that ", tof, ans, 30));

        }

        
    }
}
