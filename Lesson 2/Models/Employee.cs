namespace Lesson_2.Models
{
    public class Employee
    {
        private long _id;
        private string _name;
        public long id
        {
            get => _id;
            set => _id = value;
        }
        public string name
        {
            get => _name;
            set => _name = value;
        }
        public Employee(long id, string name)
        {
            _id = id;
            _name = name;
        }
        public Employee() { }
    }
    public class EmployeeFactory
    {
        public Employee Create(long id, string name) => new Employee(id, name);
    }
}
