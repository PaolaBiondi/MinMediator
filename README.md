# MinMediator
Minimal custom mediator example  

```mermaid
flowchart TD
	A[Domain] -->|Implements| B[IMediator, IRequestHandler<TRequest, TResponse>, Request: TRequest, Response: TResponse ]
	B --> S
	S[Services] --> |Implements| H[Handler: IRequestHandler<Request, Response>]
	B -->|DI container registration| C[API]
	C -->|Finds Handler| D[SimpleMediator: IMediator]  
	D --> |Sends Request| H
```  

## serilog  

https://github.com/serilog/serilog-aspnetcore

## ArchUnit.Net  
[manual](https://archunitnet.readthedocs.io/en/latest/)  

``` ps1
dotnet add package TngTech.ArchUnitNET
dotnet add package TngTech.ArchUnitNET.xUnit
```  

IObjectProvider<IType> declares collection of all types. It is more generic
as it retrieves all types (classes, interfaces, enums..) .
IObjectProvider<Class> declares collection of all classes, is more specific as it retrieves only classes.  

## Aspire  

- Visual Studio: right click minmediator.api Add -> .Net Aspire Orchestrator Support. Create subfolder `Aspire`.
- CLI: create `Aspire` and inside the subfolder run `dotnet new aspire-apphost -n MinMediator.AppHost` `dotnet new aspire-servicedefaults -n MinMediator.ServiceDefaults`

In appHost -> AppHosts.cs add `builder.AddProject<Projects.minmediator_api>("minmediator-api")`.
In api PRogram.cs add     
```csharp
builder.AddServiceDefaults();
app.MapDefaultEndpoints();
```




