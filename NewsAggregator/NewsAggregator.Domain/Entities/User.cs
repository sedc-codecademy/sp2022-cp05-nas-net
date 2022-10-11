using NewsAggregator.InterfaceModels.Models.User;

namespace NewsAggregator.Domain.Entities
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public bool IsAdmin { get; set; }
        public User() { }
        public User(string firstName, string lastName, string username, string email, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            Email = email;
            Password = password;
        }

        public void Update(UpdateUserDto model)
        {
            FirstName = model.FirstName;
            LastName = model.LastName;
            Username = model.Username;
            Email = model.Email;
        }

        public void ChangePassword(string hashedPassword)
        {
            Password = hashedPassword;
        }

        public Comment AddComment(string comment, Article article)
        {
            if(article == null)
            {
                throw new Exception("Article not found");
            }

            Comment addComment = new(comment, article.Id, Id, article, this);

            return addComment;
        }
    }
}
