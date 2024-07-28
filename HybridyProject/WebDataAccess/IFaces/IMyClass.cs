namespace WebDataAccess.IFaces
{
    public interface IMyClass
    {
        bool UpdateMyClass(MyClass myClass);
        bool DeleteMyClass(MyClass myClass);
        int CreateMyClass(MyClass myClass);
        MyClass GetMyClass(int id);
        IList<MyClass> GetAll();
    }
}
