
using System;
using System.IO;
using System.Reflection;

namespace AtomicEngine
{

    public interface IAtomicSDLSurface
    {
        void Remove();
        bool IsAlive { get; }
    }

}
