namespace WebDataAccess.Managers
{
    public class PersonManager : BaseDataManager, IPerson
    {
        public PersonManager(WebContext model) : base(model)
        {
        }

        public bool UpdatePerson(Person person)
        {
            return AddUpdateEntity(person);
        }

        public int CreatePerson(Person person)
        {
            AddUpdateEntity(person);
            return person.Id;
        }

        public Person GetPerson(int id)
        {
            return _dbContext.Persons.SingleOrDefault(c => c.Id == id);
        }

        public IList<Person> GetAll()
        {
            return _dbContext.Persons.ToList();
        }

        public bool DeletePerson(Person person)
        {
            _dbContext.Remove(person);
            _dbContext.SaveChanges();
            return true;
        }
    }
}