using Microsoft.Extensions.DependencyInjection;

namespace TestMydiator;

internal class TestMethodDIAttribute : TestMethodAttribute
{
    public override TestResult[] Execute(ITestMethod testMethod)
    {
        var nParameters = testMethod.ParameterTypes?.Length ?? 0;
        if (nParameters != 0)
        {
            object?[] injectedArgs = new object[nParameters];
            var serviceProvider = Hooks.ServiceProvider;
            using (var scope = serviceProvider!.CreateScope())
            {
                for (var i = 0; i < nParameters; i++)
                    injectedArgs[i] = scope.ServiceProvider.GetService(testMethod.ParameterTypes![i].ParameterType)!;
            }
            return [testMethod.Invoke(injectedArgs!)];
        }
        else
            return base.Execute(testMethod);
    }
}
