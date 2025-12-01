using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace hashCracker
{
    internal class createWordlist
    {
        public List<string> passwords = new List<string>();
        public void wordlistGenerator(int length)
        {
            char[] chars = "abcdefghijklmnopqrstuvwxyz0123456789".ToCharArray();

            void recursiveBuild(string current)
            {
                if (current.Length == length)
                {
                    passwords.Add(current);
                    return;
                }

                foreach (char c in chars)
                {
                    recursiveBuild(current + c);
                }


            }

            recursiveBuild("");

            foreach (string item in passwords)
            {
                File.AppendAllText("wordlist.txt", item);

            }

            
        }
    }
}
