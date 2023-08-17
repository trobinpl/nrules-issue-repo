using NRules.Fluent.Dsl;
using IssueTest.Domain;

namespace IssueTest.Rules;

public class NewsPostedSlackNotificationRule : Rule
{
    public override void Define()
    {
        User? User = null;

        When()
            .Match(() => User, e => e.NotificationSettings["NewsPosted"].Slack);

        Then()
            .Do(_ => Console.WriteLine($"Notify {User!.Id} via Slack"));
    }
}
