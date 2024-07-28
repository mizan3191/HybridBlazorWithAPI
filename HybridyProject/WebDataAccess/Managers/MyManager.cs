namespace WebDataAccess.Managers
{
    public class MyManager : BaseDataManager, IMyClass
    {
        public MyManager(WebContext model) : base(model)
        {
        }

        public bool UpdateMyClass(MyClass myClass)
        {
            return AddUpdateEntity(myClass);
        }

        public int CreateMyClass(MyClass myClass)
        {
            AddUpdateEntity(myClass);
            return myClass.Id;
        }

        public MyClass GetMyClass(int id)
        {
            return _dbContext.MyClasses.SingleOrDefault(c => c.Id == id);
        }

        public IList<MyClass> GetAll()
        {
            return _dbContext.MyClasses.ToList();
        }

        public bool DeleteMyClass(MyClass myClass)
        {
            _dbContext.Remove(myClass);
            _dbContext.SaveChanges();
            return true;
        }
    }
}