namespace BooksManagement.API.Entities
{
    public class User
    {
        public User(int id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }   

        public void UpdateUser(string name, string email)
        {
            Name = name;
            Email = email;
        }
    }
}