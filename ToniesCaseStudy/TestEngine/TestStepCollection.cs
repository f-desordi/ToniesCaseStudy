using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEngine
{
    public class TestStepCollection : List<TestStep>
    {
        private TestInterface? @interface;

        public TestStepCollection()
        {
        }

        public TestStepCollection(IEnumerable<TestStep> collection) : base(collection)
        {
        }

        public TestStepCollection(int capacity) : base(capacity)
        {
        }

        public TestInterface? Interface
        {
            get => @interface; set
            {
                @interface = value;

                foreach(var item in this)
                {
                    item.Interface = value;
                }
            }
        }

        public TestResult Result
        {
            get
            {
                if (this.Any(x => x.Verdict == TestResult.Error))
                {
                    return TestResult.Error;
                }
                else if (this.Any(x => x.Verdict == TestResult.Fail))
                {
                    return TestResult.Fail;
                }
                else if (this.All(x => x.Verdict == TestResult.Pass))
                {
                    return TestResult.Pass;
                }
                return TestResult.None;
            }
        }
    }
}
