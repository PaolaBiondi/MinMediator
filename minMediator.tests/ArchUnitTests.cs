namespace minMediator.tests;

using ArchUnitNET.Domain;
using ArchUnitNET.Fluent;
using ArchUnitNET.Loader;
using ArchUnitNET.xUnit;
using System.Diagnostics;
using static ArchUnitNET.Fluent.ArchRuleDefinition;

public class ArchUnitTests
{
    private static readonly Architecture Architecture =
    new ArchLoader().LoadAssemblies(
        typeof(minMediator.api.SimpleMediator).Assembly,
        typeof(minMediator.services.Extensions).Assembly
    ).Build();


    [Fact]
    public void Test1()
    {
        IObjectProvider<IType> serviceLayer = Types().That()
                                                     .ResideInAssembly(typeof(minMediator.services.Extensions).Assembly.FullName)
                                                     .As("service Layer");

        IObjectProvider<IType> apiLayer = Types().That()
                                                   .ResideInAssembly(typeof(minMediator.api.SimpleMediator).Assembly.FullName)
                                                   .As("api Layer");
        
        foreach(var type in typeof(minMediator.api.SimpleMediator).Assembly.GetTypes())
        {
            Debug.WriteLine(type.Name);
        }

        var firstAssembly = serviceLayer.GetObjects(Architecture);



        IArchRule rule = Types().That().Are(serviceLayer)
            .Should()
            .NotDependOnAnyTypesThat().Are(apiLayer);

        rule.Check(Architecture);
    }
}
