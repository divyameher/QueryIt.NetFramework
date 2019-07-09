using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectIt
{
    public class Container
    {
        public Container For<T>()
        {
            return this;
        }
        public Container Use<T>()
        {
            return this;
        }
        public Container Resolve<T>()
        {
            return this;
        }
    }
}
