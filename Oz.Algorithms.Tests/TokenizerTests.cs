using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Oz.Algorithms.Data.Cleaning;
using System.Collections.Generic;

namespace Oz.Algorithms.Tests
{
    [TestClass]
    public class TokenizerTests 
    {
        private Tokenizer tokenizer;

        public TokenizerTests()
        {
            tokenizer = new Tokenizer("");
        }

        [TestMethod]
        public void CheckIfTokenize214_1234()
        {
            tokenizer.SetInputString("214 1234");
            List<String> actual = tokenizer.Tokenize();
            var expected = new List<string>();
            expected.Add("214");
            expected.Add("1234");
            CollectionAssert.AreEqual(expected, actual,"+ not tokenized");
        }
    }
}
