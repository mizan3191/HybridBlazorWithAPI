namespace WebDataAccess.IFaces
{
    public interface IPerson
    {
        bool UpdatePerson(Person person);
        bool DeletePerson(Person person);
        int CreatePerson(Person person);
        Person GetPerson(int id);
        IList<Person> GetAll();
    }
}
