using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Win2Utf
{
    class Program
    {
        static void Main(string[] args)
        {
            EncodingInfo[] inf = Encoding.GetEncodings();
            if (args.Length != 3)
            {
                Console.WriteLine("Convert any encoding file to UTF8");
                Console.WriteLine("Useful for difrent non-unicode settings of your OS");
                Console.WriteLine("for example Read windows-1250 on windows-1251 system.");
                Console.WriteLine("");
                Console.WriteLine("win2UTF.exe full_path_in_file.txt out_name.txt encoding");                                
                Console.WriteLine("");
                Console.WriteLine("Encodings: ");
                Console.WriteLine("");
             
                Array.Sort(inf, (x, y) => x.Name[0] - y.Name[0] );
                foreach (var i in inf)
                {
                    Console.WriteLine(i.Name);
                }
                return; 
            }
            byte[] inputText = File.ReadAllBytes(args[0]);
            FileInfo fi = new FileInfo(args[0]);
            string outText = Encoding.GetEncoding(args[2]).GetString(inputText);            
            File.WriteAllText(Path.Combine( fi.Directory.FullName, args[1]),outText,Encoding.UTF8);


        }
    }
}
