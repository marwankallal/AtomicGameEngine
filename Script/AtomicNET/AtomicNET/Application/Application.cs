
namespace AtomicEngine
{

    public interface IAtomicSDLSurface
    {
        void Remove();
        bool IsAlive { get; }
    }

    public partial class Application : AObject
    {
        
    }

}
