namespace WebDataAccess.IFaces
{
    public interface IMyClass
    {
        bool UpdateMyClass(MyClass myClass);
        bool DeleteMyClass(int id);
        int CreateMyClass(MyClass myClass);
        MyClass GetMyClass(int id);
        IList<MyClass> GetAll();
    }
}
