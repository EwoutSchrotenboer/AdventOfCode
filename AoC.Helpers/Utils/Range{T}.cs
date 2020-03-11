using System;
using System.Collections.Generic;
using System.Text;

namespace AoC.Helpers.Utils
{
    public class Range<T> where T : IComparable<T>
    {
        public T Lower { get; set; }
        public T Upper { get; set; }
    }
}
