using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{
    class Question
    {
        protected string _header;
        protected string _body;
        protected AnswerList _chooses;
        protected AnswerList _modleAnswer;
        protected float _marks;
        protected string _fileName = "";

        public string header
        {
            set
            {

                _header = value;
            }
            get
            {
                return _header;
            }

        }
        public string body
        {
            set
            {

                _body = value;
            }
            get
            {
                return _body;
            }

        }
        public AnswerList chooses
        {
            set
            {
                _chooses = value;
            }
            get
            {
                return _chooses;
            }
        }
        public AnswerList modleAnswer
        {
            set
            {
                _modleAnswer = value;
            }
            get
            {
                return _modleAnswer;
            }
        }
        public float marks
        {
            set
            {

                _marks = value;
            }
            get
            {
                return _marks;
            }

        }
        public string fileName
        {
            get
            {
                return _fileName;
            }

        }

        public Question() : this("", new AnswerList(), new AnswerList(), 0){}
        public Question(string body, AnswerList chooses, AnswerList modleAnswer, float marks):this("",body, new AnswerList(), new AnswerList(), marks){}
        public Question(string header, string body, AnswerList chooses, AnswerList modleAnswer, float marks)
        {
            _header = header;
            _body = body;
            _marks = marks;
            _chooses = chooses;
            _modleAnswer = modleAnswer;
        }

        
        public void showQuestionAnswer()
        {
            Console.WriteLine(_header);
            Console.WriteLine(_body);
            for (int i = 0; i < _modleAnswer.Count; i++)
            {
                Console.WriteLine(_modleAnswer[i].answer);
            }
            Console.WriteLine("-------------------");
        }

        public override string ToString()
        {
            string str = "";

            str += _header + "\n";
            str += _body + "\n";
            int i = 0;
            for (i = 0; i < chooses.Count; i++)
            {
                str += "   "+(i+1)+")"+chooses[i].answer + "\n";
            }

            str +=  "Enter your choice "+(i-1)+":";
            return str ;
        }
    }

     class TrueOrFalse :Question
    {
        public TrueOrFalse()
        {
            _fileName = "TOF";
            _header = "True or False";
        }
        public TrueOrFalse(string body , AnswerList chooses, AnswerList modleAnswer, float marks):base("True or False",body, chooses, modleAnswer, marks)
        {
            _fileName = "TOF";
        }

    }
     class ChooseOne : Question
    {
        public ChooseOne()
        {
            _fileName = "CO";
            _header = "Choose One";
        }
        public ChooseOne(string body, AnswerList chooses, AnswerList modleAnswer, float marks) : base("Choose One", body, chooses, modleAnswer, marks)
        {
            _fileName = "CO";
        }
        
    }
     class ChooseAll : Question
    {
        public ChooseAll()
        {
            _fileName = "CA";
            _header = "Choose All";
        }

        public ChooseAll(string body, AnswerList chooses, AnswerList modleAnswer, float marks) : base("Choose All", body, chooses, modleAnswer, marks)
        {
            _fileName = "CA";
        }
        
    }

     class QuestionList:List<Question>
    {

        public new void Add(Question question)
        {
            base.Add(question);
            // write in file
            writeInFile(question);
        }

        void writeInFile(Question question)
        {
            Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory+"\\Question");
            using (StreamWriter writer = File.CreateText("Question\\"+question.fileName + Count+".txt"))
            {
                 writer.WriteLineAsync(question.header);
                 writer.WriteLineAsync(question.body);

                 writer.WriteLineAsync(question.chooses.Count.ToString());
                for (int i =0;i< question.chooses.Count;i++)
                {
                    writer.WriteLineAsync(question.chooses[i].answer);
                }

                writer.WriteLineAsync(question.modleAnswer.Count.ToString());
                for (int i = 0; i < question.modleAnswer.Count; i++)
                {
                    writer.WriteLineAsync(question.modleAnswer[i].answer);
                }

                writer.WriteLineAsync(question.marks.ToString());
            }
        }
    }



}
