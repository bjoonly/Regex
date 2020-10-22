using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Net.Http.Headers;

namespace Regexs
{
    class Program
    {
        static void Main(string[] args)
        {

            //1
            try
            {
                string line1;
                string patternWord = @"[\S]+";
                using (StreamReader sr = new StreamReader("Text.txt"))
                {
                    line1 = sr.ReadToEnd();
                }
                Match match = Regex.Match(line1, patternWord);

                StringBuilder s;
                using (StreamWriter sw = new StreamWriter(File.Create("ResText1.txt")))
                {
                    while (match.Success)
                    {
                        s = new StringBuilder(match.ToString());
                        if (Char.IsLetter(s[0]))
                        {
                            s[0] = Char.ToUpper(s[0]);
                        }
                        s.Append(".");
                        sw.WriteLine(s);
                        Console.WriteLine(s);
                        match = match.NextMatch();
                    }

                }
                Console.ReadKey();
                Console.Clear();

                //2

                string patternDrob = @"\d+[.,]\d+";
                string line2;
                using (StreamReader sr = new StreamReader("Text.txt"))
                {
                    line2 = sr.ReadToEnd();
                }
                match = Regex.Match(line2, patternDrob);

                var regex = new Regex(patternDrob);

                while (match.Success)
                {
                    Console.WriteLine(match.ToString());
                    match = match.NextMatch();
                }

                Console.ReadKey();
                Console.Clear();

                //3
                string patternObsceneWords = "";
                string line3;
                using (StreamReader sr = new StreamReader("ObsceneWords.txt"))
                {
                    while (!sr.EndOfStream)
                        patternObsceneWords += sr.ReadLine() + @"\w*|";

                }
                patternObsceneWords = patternObsceneWords.Remove(patternObsceneWords.Length - 1);
                using (StreamReader sr = new StreamReader("Text3.txt"))
                {
                    line3 = sr.ReadToEnd();
                }
                match = Regex.Match(line3, patternObsceneWords.ToString());

                using (StreamWriter sw = new StreamWriter(File.Create("Censorhip.txt")))
                {
                    while (match.Success)
                    {
                        line3 = line3.Replace(match.ToString(), "*");
                        match = match.NextMatch();
                    }
                    Console.WriteLine(line3);
                    sw.Write(line3);
                }
                Console.ReadKey();
                Console.Clear();
                //4

                string patternInt = @"^\d+$";
                List<int> listInt = new List<int>();
                string line4;
                using (StreamReader sr = new StreamReader("numbers.txt"))
                {
                    line4 = sr.ReadToEnd();
                }
                var words = line4.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                regex = new Regex(patternInt);
                foreach (String text in words)
                {

                    if (regex.IsMatch(text))
                    {

                        listInt.Add(Convert.ToInt32(text));
                    }
                }
                foreach (var item in listInt)
                {
                    Console.WriteLine(item);
                }
                Console.ReadKey();
                Console.Clear();

                // 5
                string patternEmail = @"^[\w.-]{4,}\@[0-9a-zA-Z]+\.[0-9a-zA-Z]+$";
                string patterPassword = @"^(?=.*[0-9])(?=.*[a-zA-Z])(?=.*[-_])[\w-]{6,}$";
                Console.WriteLine("Enter email:");
                string email = Console.ReadLine();
                Console.WriteLine("Enter password:");
                string password = Console.ReadLine();
                regex = new Regex(patternEmail);
                if (!regex.IsMatch(email))
                    Console.WriteLine("Invalid email.");
                else
                    Console.WriteLine("Correct email.");
                regex = new Regex(patterPassword);
                if (!regex.IsMatch(password))
                    Console.WriteLine("Invalid password.");
                else
                    Console.WriteLine("Correct password.");

                Console.ReadKey();
                Console.Clear();

                //6
                string patternDate = @"\d{4}\/\d{2}\/\d{2}\s+\d{2}:\d{2}(\s|:\d\d)";
                string line6;
                using (StreamReader sr = new StreamReader("Text.txt"))
                {
                    line6 = sr.ReadToEnd();
                }
                match = Regex.Match(line6, patternDate);
                while (match.Success)
                {
                    Console.WriteLine(match.ToString());
                    match = match.NextMatch();
                }
                Console.ReadKey();
                Console.Clear();


                //7

                string patternNumbers9 = @"\b\d{10}\b";
                string line7;
                using (StreamReader sr = new StreamReader("Text.txt"))
                {
                    line7 = sr.ReadToEnd();
                }
                match = Regex.Match(line7, patternNumbers9);

                while (match.Success)
                {
                    Console.WriteLine($"{int.Parse(match.ToString()): +38 (0##) ###-##-##}");
                    match = match.NextMatch();
                }
                Console.ReadKey();
                Console.Clear();


                // 8
                string patternToUp = @"\*[^*]+\*";
                string patternToLower = @"_[^_]+_";
                string line8;
                using (StreamReader sr = new StreamReader("Text.txt"))
                {
                    line8 = sr.ReadToEnd();
                }
                var matchUp = Regex.Match(line8, patternToUp);
                var matchLower = Regex.Match(line8, patternToLower);
                Console.WriteLine("Up:");
                while (matchUp.Success)
                {
                    Console.WriteLine(matchUp.ToString().ToUpper());
                    matchUp = matchUp.NextMatch();
                }
                Console.WriteLine("Lower:");
                while (matchLower.Success)
                {
                    Console.WriteLine(matchLower.ToString().ToLower());
                    matchLower = matchLower.NextMatch();
                }
                Console.ReadKey();
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message) ;
            }
        }
    }
}
