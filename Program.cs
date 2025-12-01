using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;



namespace hashCracker
{
    internal class Program
    {
        public static string ComputeSHA256(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(input);
                byte[] hash = sha256.ComputeHash(bytes);

                StringBuilder sb = new StringBuilder();
                foreach (byte b in hash)
                {
                    sb.Append(b.ToString("x2")); // hex format
                }

                return sb.ToString();
            }
        }

        static void Main(string[] args)
        {
            Console.Write("generate a new wordlist? (y/n): ");
            char choice = Convert.ToChar(Console.ReadLine().ToLower());

            if (choice == 'y')
            {
                createWordlist createWordlist = new createWordlist();
                Console.Write("word length: ");
                int length = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("\n[+] generating wordlist...");
                createWordlist.wordlistGenerator(length);
                Console.WriteLine("[+] wordlist created.\n");
            }

            Console.Write("target sha256 hash: ");
            string targetHash = Console.ReadLine();

            if (!File.Exists("wordlist.txt"))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n[!] error: wordlist.txt not found");
                Console.ResetColor();
                return;
            }

            Console.WriteLine("\n[+] starting hash check...\n");

            var lines = File.ReadAllLines("wordlist.txt");

            foreach (var line in lines)
            {
                string hash = ComputeSHA256(line);

                if (hash == targetHash)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"[+] match found → password: {line}");
                    Console.ResetColor();
                    return;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"[-] tried: {line}");
                    Console.ResetColor();
                }
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n[!] no match found in the wordlist");
            Console.ResetColor();
        }


    }
}

