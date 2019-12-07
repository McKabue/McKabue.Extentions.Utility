using System;
using System.Runtime.CompilerServices;

namespace McKabue.Extentions.Utility.Enums
{
    [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = false)]
    public sealed class OrderAttribute : Attribute
    {
        private int order_;
        public OrderAttribute([CallerLineNumber] int order = 0)
        {
            order_ = order;
        }
        public int Order { get { return order_; } set { order_ = value; } }
    }
}