using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEngine
{
    public class ConfirmTestStep : TestStep
    {
        public override void Execute()
        {
            if (this.Interface == null)
            {
                throw new InvalidOperationException($"{nameof(Interface)} must be set prior to execution.");
            }

            if (!this.Interface.SendConfirm(out string response))
            {
                this.Verdict = TestResult.Error;
                throw new Exception($"Test interface command \"confirm\" failed with response: " + response);
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
