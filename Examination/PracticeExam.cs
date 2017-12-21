using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{
    class PracticeExam<T> : Exam<T> where T : Question, new()
    {

        public PracticeExam(float time, int numberOfQuestion, mode examMode) : base(time, numberOfQuestion, examMode) { }



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
            Console.Clear();
            showModelAnswer();
            Console.WriteLine("your Grade=" + _studentGrade + "/" + _examGrade);
        }

    }
}
