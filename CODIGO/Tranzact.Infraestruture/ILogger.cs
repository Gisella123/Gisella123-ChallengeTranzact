using System;
using System.Collections.Generic;
using System.Text;

namespace Tranzact.Infraestruture
{
    public interface ILogger
    {
        void Configure();
        void Info(object message);
    }
}
