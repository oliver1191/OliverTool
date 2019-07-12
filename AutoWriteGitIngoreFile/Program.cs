using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Collections.Specialized;

namespace AutoWriteGitIngoreFile
{
     class Program
    {
        static void Main(string[] args)
        {
            GitIgnoreControll gitIgnore = new GitIgnoreControll();
            gitIgnore.WriteIgnoreFile();
            Console.WriteLine("success");
            Console.ReadKey();
        }
    }
}
