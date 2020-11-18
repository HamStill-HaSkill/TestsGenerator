using System;
using System.IO;
using System.Threading.Tasks;
using TestsGeneratorLib;

namespace TestsGenerator 
{ 
    class Program
    {
        static void Main(string[] args)
        {
            var test = new Tests();
            string dest = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName, "TestGeneratorClassTest");
            string source = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName, "TestClasses");
            test.Generate(source, dest, 5).Wait();
        }
    }
}
