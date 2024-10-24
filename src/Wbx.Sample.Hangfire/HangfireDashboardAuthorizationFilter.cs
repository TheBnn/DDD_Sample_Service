using Hangfire.Dashboard;

namespace Wbx.Sample.Hangfire;

public  class HangfireDashboardAuthorizationFilter: IDashboardAuthorizationFilter
{
    public bool Authorize(DashboardContext context)
    {
        return true;
    }
}
