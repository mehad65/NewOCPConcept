using NewOCPConcept;
using System.Reflection;
using System.Runtime.InteropServices;

var text = Console.ReadLine();

IHellowWorld hw = new HellowWorld();
var hwproxy = HellowWorldProxy.Create(hw);

hwproxy.SayHellow(text);

public class ProxyService<TService> : DispatchProxy
    where TService : class
{
    public TService Service { get; private set; }

    public static TService Create(TService hello)
    {
        object obj = Create<TService, ProxyService<TService>>();
        ((ProxyService<TService>)obj).SetTarget(hello);

        return (TService) obj;
    }

    protected override object? Invoke(MethodInfo? targetMethod, object?[]? args)
    {
        return targetMethod.Invoke(Service, args);
    }

    private void SetTarget(TService target)
    {
        Service = target;
    }
}

public class HellowWorldProxy : ProxyService<IHellowWorld>
{
    protected override object? Invoke(MethodInfo? targetMethod, object?[]? args)
    {
        if (targetMethod.Name.Equals(nameof(IHellowWorld.SayHellow)))
        {
            if (args[0].ToString().Length > 4)
            {
                Console.WriteLine("Length Exceeded");
                Environment.Exit(0);
            }
        }

        return targetMethod.Invoke(Service, args);
    }
}