using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEngine
{
    public abstract class TestStep
    {
        public required string Name {  get; init; }
        public string LabelResult { get; protected set; } = string.Empty;
        public string EntryResult { get; protected set; } = string.Empty;
        public string LabelExpected { get; init; } = string.Empty;
        public string EntryExpected { get; init; } = string.Empty;
        public TestResult Verdict { get; protected set; } = TestResult.None;


        public TestInterface? Interface { get; set; }

        public override string ToString()
        {
            return $"{Name,-40}: {Verdict,6}; {EntryResult,8}=={EntryExpected,-8}; {LabelResult,8}=={LabelExpected,-8}";
        }

        /// <summary>
        /// Executes the test step and sets the verdict.
        /// </summary>
        public abstract void Execute();
    }
}
