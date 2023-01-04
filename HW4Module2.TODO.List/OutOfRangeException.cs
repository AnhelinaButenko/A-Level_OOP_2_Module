using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW4Module2.TODO.List
{
    public class OutOfRangeForTasksException : Exception
    {
        public int LowerBound => 0;
        public int UpperBound => 3;
        public override string Message => "Task outside of bounds";
        public override Dictionary<string, int> Data => new Dictionary<string, int>
        {
            { nameof(LowerBound), LowerBound },
            { nameof(UpperBound), UpperBound }
        };
    }
}
