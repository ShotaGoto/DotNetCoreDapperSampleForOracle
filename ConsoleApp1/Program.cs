using Dao;

namespace ConsoleApp1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var sql = "select * from hoge where Id = :Id";
            var person = new Person();
            person.Id = 1;

            var result = new DbClient().Select<Person>(sql, person);
        }
    }
}