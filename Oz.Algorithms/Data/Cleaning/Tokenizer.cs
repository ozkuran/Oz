using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Databench.ClassLibrary.Data.Cleaning
{
    class Tokenizer
    {
        public List<string> TokenizedList = new List<string>();
        private string _inputString;

        public Tokenizer(string inputString)
        {
            _inputString = inputString;
        }

        public void SetInputString(string inputString)
        {
            _inputString = inputString;
        }

        public List<String> Tokenize()
        {
            TokenizedList = _inputString.Split(',').ToList();
            return TokenizedList;
        }

    }
}
