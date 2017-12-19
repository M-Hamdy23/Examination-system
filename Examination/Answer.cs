using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{
    class Answer
    {
        string _answer;
        public string answer
        {
            set
            {
                _answer = value;
            }
            get
            {
                return _answer;
            }
        }
        public Answer( string ans)
        {
            _answer = ans;
        }
        public override bool Equals(object obj)
        {
            Answer ans = (Answer)obj;
            return _answer == ans._answer;
        }
    }

    class AnswerList : List<Answer>
    {
        public new void Add(Answer answer)
        {
            base.Add(answer);
        }

        public override bool Equals(object obj)
        {
            AnswerList ans = (AnswerList)obj;
            if (ans.Count == Count)
            {
                for (int i = 0; i < Count; i++)
                {
                    if (this[i].answer != ans[i].answer)
                        return false;
                }
                return true;
            }
            return false;

        }
    }

}
