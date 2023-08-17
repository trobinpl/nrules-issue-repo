using IssueTest.Domain;
using NRules.Fluent.Dsl;

namespace IssueTest.Rules;

public class NewsPostedInAppNotificationRule : Rule
{
    public override void Define()
    {
        User? User = null;

        When()
            .Match(() => User, e => e.NotificationSettings["NewsPosted"].InApp);

        Then()
            .Do(_ => Console.WriteLine($"Notify {User!.Id} via InApp"));
    }
}
