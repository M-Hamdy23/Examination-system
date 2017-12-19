using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{
    enum mode
    {
        none,
        starting,
        queue,
        finished
    }

    abstract class Exam <T> where T : Question
    {
        protected float _time;
        protected int _numberOfQuestion;
        protected List<T> _questions;
        protected mode _examMode;
        protected float _examGrade;
        protected float _studentGrade;
        public List<T> questions
        {
            set
            {
                _questions = value;
            }
            get
            {
                return _questions;
            }
        }

        public Exam(float time,int numberOfQuestion , List<T> questions,mode examMode , float examGrade)
        {
            _time = time;
            _numberOfQuestion = numberOfQuestion;
            _questions = questions;
            _examMode = examMode;
            _examGrade = examGrade;
        }

        
        public abstract void showExam(List<AnswerList> answers);

        public void calculateGrade(List<AnswerList> answers)
        {
            for (int i = 0; i < answers.Count; i++)
            {
                if (answers[i].Equals(questions[i].modleAnswer))
                    _studentGrade += questions[i].marks;
            }
        }

        public void showModelAnswer()
        {
            for (int i = 0; i < questions.Count; i++)
            {
                questions[i].showQuestionAnswer();
            }
        }

    }

    class PracticeExam<T>:Exam<T> where T : Question
    {
        public PracticeExam(float time, int numberOfQuestion, List<T> questions, mode examMode , float examGrade) : base(time, numberOfQuestion, questions, examMode,examGrade) {}

        public override void showExam(List<AnswerList> answers)
        {
            calculateGrade(answers);

            showModelAnswer();

            Console.WriteLine("your Grade=" + _studentGrade + "/" + _examGrade);
        }
        
    }

    class FinalExam<T>: Exam<T> where T : Question
    {
        public FinalExam(float time, int numberOfQuestion, List<T> questions, mode examMode, float examGrade) : base(time, numberOfQuestion, questions, examMode, examGrade) { }

        public override void showExam(List<AnswerList> answers)
        {
            calculateGrade(answers);

            Console.WriteLine("your Grade=" + _studentGrade + "/" + _examGrade);
        }

    }

}
