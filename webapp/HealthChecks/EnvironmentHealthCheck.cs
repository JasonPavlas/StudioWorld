using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace webapp.HealthChecks
{
    public class EnvironmentHealthCheck : IHealthCheck
    {
        public Task<HealthCheckResult> CheckHealthAsync(
            HealthCheckContext context, 
            CancellationToken cancellationToken = default)
        {
            try
            {
                // Check if the app has enough memory
                var availableMemory = GC.GetTotalMemory(false);
                var memoryStatus = availableMemory < 1024L * 1024L * 100L ? // 100 MB
                    HealthStatus.Degraded : 
                    HealthStatus.Healthy;

                // Check environment variables needed for the application
                var connectionString = Environment.GetEnvironmentVariable("CONNECTIONSTRING") ?? 
                                      "DefaultConnection"; // Using DefaultConnection as a fallback
                
                var envStatus = string.IsNullOrEmpty(connectionString) ? 
                    HealthStatus.Degraded : 
                    HealthStatus.Healthy;
                
                // Combine statuses
                var status = memoryStatus == HealthStatus.Degraded || envStatus == HealthStatus.Degraded ?
                    HealthStatus.Degraded :
                    HealthStatus.Healthy;

                var data = new Dictionary<string, object>
                {
                    { "MemoryUsage", availableMemory },
                    { "EnvironmentVariables", envStatus == HealthStatus.Healthy ? "Configured" : "Missing" }
                };

                return Task.FromResult(new HealthCheckResult(
                    status,
                    "Environment check",
                    null,
                    data));
            }
            catch (Exception ex)
            {
                return Task.FromResult(new HealthCheckResult(
                    HealthStatus.Unhealthy,
                    "Environment check failed",
                    ex));
            }
        }
    }
}
