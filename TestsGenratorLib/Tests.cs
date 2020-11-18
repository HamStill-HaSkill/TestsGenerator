using System;
using System.Collections.Generic;
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
        public Task Generate(string source, string destination, int maxParallelism)
        {
            var executionOptions = new ExecutionDataflowBlockOptions { MaxDegreeOfParallelism = maxParallelism };
            var linkOptions = new DataflowLinkOptions { PropagateCompletion = true };

            var openFile = new TransformBlock<string, string>(async path =>
                await fileIO.ReadFileAsync(path),
                executionOptions);

            var generateTest = new TransformBlock<string, Dictionary<string, string>>(async text =>
                await Task.Run(() => generator.CreateTest(text)),
                executionOptions);

            var saveTestFile = new ActionBlock<Dictionary<string, string>>(async text =>
            {
                await fileIO.WriteFileAsync(destination, text);
            }, executionOptions);

            openFile.LinkTo(generateTest, linkOptions);
            generateTest.LinkTo(saveTestFile, linkOptions);
            try
            {
                foreach (var file in Directory.GetFiles(source))
                {
                    if (file.EndsWith(".cs"))
                    {
                        openFile.Post(file);
                    }
                }
            }
            catch
            {
                throw;
            }


            openFile.Complete();
            return saveTestFile.Completion;
        }
    }
}
