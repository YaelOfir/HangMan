using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangMan
{
    class WordBank
    {
        Random RandomWords = new Random();
        public static string SelectedWord;
        public string Easy()
        {
            string[] Words = new string[] { "cat", "ball", "sun", "moon", "shape" };
            int num = RandomWords.Next(0, Words.Length);
            return Words[num];
        }
        public string Hard()
        {
            string[] Words = new string[] { "remarkable", "regardless", "supersticious", "struggles", "photography" };
            int num = RandomWords.Next(0, Words.Length);
            return Words[num];
        }
    }
}
