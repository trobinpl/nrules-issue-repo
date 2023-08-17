namespace IssueTest.Domain;

public class User
{
    public string Id { get; set; } = string.Empty;
    public Dictionary<string, NotificationSettings> NotificationSettings { get; init; }

    public User(string id) 
    {
        Id = id;
        NotificationSettings = new Dictionary<string, NotificationSettings>();
    }
}
