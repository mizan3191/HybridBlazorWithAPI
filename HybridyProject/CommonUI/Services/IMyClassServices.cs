namespace CommonUI.Services
{
    public interface IMyClassServices
    {
        Task CreateMyClass(MyClass myClass);
        Task UpdateMyClass(MyClass myClass);
        Task DeleteMyClass(int id);
        Task<IEnumerable<MyClass>> GetMyClassess();
        Task<MyClass> GetMyClass(int id);
    }
}
