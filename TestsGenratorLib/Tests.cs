using System;
using System.IO;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace TestsGeneratorLib
{
    public class Tests
    {
        private FileIO fileIO;
        private TestGenerator generator;
        public Tests()
        {
            fileIO = new FileIO();
            generator = new TestGenerator();
        }
        public Task Generate(string source, string destination)
        {
            
            var openFile = new TransformBlock<string, string>(path =>
            {               
                return fileIO.ReadFileAsync(path);                
            });

            var generateTest = new TransformBlock<string, string>(text =>
            {
                generator.CreateTest(text);
                return "TEST" + text;
            });

            var saveTestFile = new ActionBlock<string>(async text =>
            {
                await fileIO.WriteFileAsync(destination, text);          
            });


            var linkOptions = new DataflowLinkOptions { PropagateCompletion = true };

            openFile.LinkTo(generateTest, linkOptions);
            generateTest.LinkTo(saveTestFile, linkOptions);

            foreach(var file in Directory.GetFiles(source))
            {
                openFile.Post(file);
            }
            
            openFile.Complete();
            return openFile.Completion;
        }
    }
}
