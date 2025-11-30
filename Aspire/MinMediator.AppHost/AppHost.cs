var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.minMediator_api>("minmediator-api");
builder.AddProject<Projects.minMediator_tests>("minmediator-tests");

builder.Build().Run();
