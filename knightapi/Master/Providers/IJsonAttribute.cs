using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Master.Providers
{
    public interface IJsonAttribute
    {
        object TryConvert(string modelValue, Type targertType, out bool success);
    }
}
