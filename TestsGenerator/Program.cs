using System;
using System.IO;
using TestsGeneratorLib;

namespace TestsGenerator 
{ 
    class Program
    {
        static void Main(string[] args)
        {
            var test = new Tests();
            test.Generate("code.txt", "codetest.txt");
        }
    }
}
