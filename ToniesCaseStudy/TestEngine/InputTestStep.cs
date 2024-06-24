using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace TestEngine
{
    public class InputTestStep : TestStep
    {
        public required string Input {  get; set; }

        public override void Execute()
        {
            if (this.Interface == null)
            {
                throw new InvalidOperationException($"{nameof(Interface)} must be set prior to execution.");
            }

            if (!this.Interface.ClearEntry(out string response))
            {
                this.Verdict = TestResult.Error;
                throw new Exception($"Test interface command \"clear\" failed with response: " + response);
            }
            if (!this.Interface.Write(this.Input, out response))
            {
                this.Verdict = TestResult.Error;
                throw new Exception($"Test interface command \"write\" failed with response: " + response);
            }
            if (!this.Interface.Read(out string vLabel, out string vEntry, out response))
            {
                this.Verdict = TestResult.Error;
                throw new Exception($"Test interface command \"read\" failed with response: " + response);
            }
            this.LabelResult = vLabel;
            this.EntryResult = vEntry;

            if (this.LabelResult == this.LabelExpected && this.EntryResult == this.EntryExpected)
            {
                this.Verdict = TestResult.Pass;
            }
            else
            {
                this.Verdict = TestResult.Fail;
            }
        }
    }
}
