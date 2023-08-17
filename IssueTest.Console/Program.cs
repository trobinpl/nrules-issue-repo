using IssueTest.Domain;
using IssueTest.Rules;
using NRules;
using NRules.Fluent;

var repository = new RuleRepository();
repository.Load(x => x.From(typeof(NewsPostedInAppNotificationRule).Assembly));
var factory = repository.Compile();
var session = factory.CreateSession();

session.Events.LhsExpressionEvaluatedEvent += (sender, args) =>
{
    Console.WriteLine($"LHS expression evaluated: {args.Expression}, result: {args.Result}");
};

var bothOn = new User("bothOn")
{
    NotificationSettings = new Dictionary<string, NotificationSettings>
    {
        ["NewsPosted"] = new NotificationSettings { InApp = true, Slack = true }
    }
};

var onlyInApp = new User("onlyInApp")
{
    NotificationSettings = new Dictionary<string, NotificationSettings>
    {
        ["NewsPosted"] = new NotificationSettings { InApp = true, Slack = false }
    }
};

var onlySlack = new User("onlySlack")
{
    NotificationSettings = new Dictionary<string, NotificationSettings>
    {
        ["NewsPosted"] = new NotificationSettings { InApp = false, Slack = true }
    }
};

var none = new User("none")
{
    NotificationSettings = new Dictionary<string, NotificationSettings>
    {
        ["NewsPosted"] = new NotificationSettings { InApp = false, Slack = false }
    }
};

var users = new List<User> { bothOn, onlyInApp, onlySlack, none };

session.InsertAll(users);

session.Fire();