using Microsoft.Extensions.DependencyInjection;

namespace TestMydiator;

[AttributeUsage(AttributeTargets.Method)]
public sealed class TestMethodDIAttribute : TestMethodAttribute
{
    public override TestResult[] Execute(ITestMethod testMethod)
    {
        var parameters = testMethod?.MethodInfo?.GetParameters();
        var nParameters = parameters?.Length ?? 0;

        if (nParameters != 0)
        {
            var serviceProvider = Hooks.ServiceProvider ?? throw new InvalidOperationException(
                "Hooks.ServiceProvider is not initialized. Ensure AssemblyInitialize ran successfully.");

            // Create a scope and keep it alive while invoking the test so scoped services
            // are not disposed before the test uses them.
            using var scope = serviceProvider.CreateScope();

            object[] injectedArgs = new object[nParameters];

            for (var i = 0; i < nParameters; i++)
            {
                var paramType = parameters![i].ParameterType;
                var resolved = scope.ServiceProvider.GetService(paramType)
                    ?? throw new InvalidOperationException($"Unable to resolve service for parameter type {paramType.FullName}.");
                injectedArgs[i] = resolved;
            }
            // Invoke the test while the scope (and injected services) are still valid.
            var result = testMethod.Invoke(injectedArgs);
            return [result];
        }
        else
            return base.Execute(testMethod);
    }
}