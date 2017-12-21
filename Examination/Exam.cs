using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{
    public enum mode
    {
        none,
        starting,
        queue,
        finished
    }

    public class ExamEventArgs : EventArgs
    {
        public  mode State { get; set; }

        
        
    }

    abstract class Exam <T> where T : Question ,new()
    {
        public static void printState(object sender, ExamEventArgs args) { Console.WriteLine("your Exam is :" + args.State); }

        public static EventHandler<ExamEventArgs> ExamEvent;
        protected float _time;
        protected int _numberOfQuestion;
        protected List<T> _questions;
        protected List<AnswerList> answers= new List<AnswerList>();
        protected mode _examMode;
        protected float _examGrade;
        protected float _studentGrade;

        public float time
        {
            set
            {
                _time = value;
            }
            get
            {
                return _time;
            }
        }
        public int numberOfQuestion 
        {
            set
            {
                _numberOfQuestion = value;
            }
            get
            {
                return _numberOfQuestion;
            }
        }
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
        public mode examMode
        {
            set
            {
                _examMode = value;
                OnModeChange();
            }
            get
            {
                return _examMode;
            }
        }
        public float examGrade
        {
            set
            {
                _examGrade = value;
            }
            get
            {
                return _examGrade;
            }
        }
        public float studentGrade
        {
            set
            {
                _studentGrade = value;
            }
            get
            {
                return _studentGrade;
            }
        }

        protected virtual void OnModeChange()
        {
            if (ExamEvent != null)

                ExamEvent(this, new ExamEventArgs() { State=this._examMode});
        }

        public abstract void generateExam();

        protected abstract void showExam();


        protected void loadQuestion(string pattern)
        {
            examMode = mode.starting;
            // all files and random 
            string[] allFiles = System.IO.Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + "\\Question", pattern);
            var rand = new Random();
            for (int i = 0; i < allFiles.Length; i++)
            {
                int x = rand.Next(0,allFiles.Length);
                int y = rand.Next(0,allFiles.Length);
                string temp = allFiles[x];
                allFiles[x] = allFiles[y];
                allFiles[y] = temp;

            }


            for (int i = 0; (i < numberOfQuestion && allFiles.Length>=numberOfQuestion); i++)
            {

                using (StreamReader reader = File.OpenText(allFiles[i]))
                {
                    T t = new T();
                    t.header = (reader.ReadLine());
                    t.body = (reader.ReadLine());
                    int choosesNum = int.Parse(reader.ReadLine());
                    for (int j = 0; j < choosesNum; j++)
                    {
                        t.chooses.Add(new Answer(reader.ReadLine()));
                    }
                    int modelAnswerNum = int.Parse(reader.ReadLine());
                    for (int j = 0; j < modelAnswerNum; j++)
                    {
                        t.modleAnswer.Add(new Answer(reader.ReadLine()));
                    }
                    t.marks = float.Parse(reader.ReadLine());
                    _examGrade += t.marks;
                    _questions.Add(t);

                }

            }

            for (int i = 0; i < _questions.Count; i++)
            {
                Console.Write(_questions[i]);

                getAnswersForQuestion(_questions[i]);

                calculateGradeForQuestion(_questions[i]);
                if (i == 3)
                    examMode = mode.queue;
            }

            examMode = mode.finished;
        }

        protected void getAnswersForQuestion(T question)
        {
            answers.Add(new AnswerList());
            
            for (int i = 0; i < question.modleAnswer.Count; i++)
            {
                answers[answers.Count-1].Add(new Answer(Console.ReadLine()));
            }
            
        }

        protected void calculateGradeForQuestion(T question)
        {
                if (answers[answers.Count - 1].Equals(question.modleAnswer))
                    _studentGrade += question.marks;
        }

        public Exam(float time,int numberOfQuestion ,mode examMode )
        {
            _time = time;
            _numberOfQuestion = numberOfQuestion;
            _examMode = examMode;
            _examGrade = 0;
            _questions = new List<T>();
        }

        protected void showModelAnswer()
        {
            for (int i = 0; i < questions.Count; i++)
            {
                questions[i].showQuestionAnswer();
            }
        }


    }

    

    

}
