using NServiceBus.Pipeline;

#region RegisterStep
class ThrottlingRegistration :
    RegisterStep
{
    public ThrottlingRegistration()
        : base("GitHubApiThrottling", typeof(ThrottlingBehavior), "Implements API throttling for GitHub APIs")
    {
        InsertBefore(WellKnownStep.InvokeHandlers);
    }
}
#endregion