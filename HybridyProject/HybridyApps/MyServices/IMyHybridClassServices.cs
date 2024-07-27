using WebDomain;

namespace HybridyApps.MyServices
{
    public interface IMyHybridClassServices
    {
        Task CreateMyClass(MyClass myClass);
        Task UpdateMyClass(MyClass myClass);
        Task DeleteMyClass(int id);
        Task<IEnumerable<MyClass>> GetMyClassess();
        Task<MyClass> GetMyClass(int id);
    }
}
