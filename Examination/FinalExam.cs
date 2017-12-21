using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{
    class FinalExam<T> : Exam<T> where T : Question, new()
    {
        public FinalExam(float time, int numberOfQuestion, mode examMode) : base(time, numberOfQuestion, examMode) { }

        public override void generateExam()
        {
            T temp = new T();


            if (temp.fileName != "")
            {
                loadQuestion(temp.fileName + "*");
            }
            else
            {
                loadQuestion("*.txt");
            }

            showExam();
        }

        protected override void showExam()
        {
            //calculateGrade();

            Console.WriteLine("your Grade=" + _studentGrade + "/" + _examGrade);

            
        }

    }
}
