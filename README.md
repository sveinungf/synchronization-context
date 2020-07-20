# SynchronizationContext in .NET

AKA when should I use `ConfigureAwait(false)` when writing async code?

In general, use `ConfigureAwait(false)` unless you know that you need to capture the current context. General-purpose library code typically do not need to return back to the original context. UI applications typically needs to be in the correct context to make changes to UI elements. See [here](https://devblogs.microsoft.com/dotnet/configureawait-faq/) for more details.

However, not all environments publishes a custom `SynchronizationContext` or a custom `TaskScheduler`.
In that case, calling `ConfigureAwait(false)` will have no effect.


| Environment                       | `SynchronizationContext.Current` is `null` | `TaskScheduler.Current` is Thread Pool |
| --------------------------------- | :----------------------------------------: | :------------------------------------: |
| ASP.NET Core (.NET Core)          | ✅                                         | ✅                                    |                  
| ASP.NET Core (.NET Framework)     | ✅                                         | ✅                                    |
| ASP.NET Web Forms                 | ❌                                         | ✅                                    |
| Azure Functions v1                | ✅                                         | ✅                                    |
| Azure Functions v2                | ✅                                         | ✅                                    |
| Azure Functions v3                | ✅                                         | ✅                                    |
| Blazor Server                     | ❌                                         | ✅                                    |
| Blazor WebAssembly                | ✅                                         | ✅                                    |
| Console App (.NET Core)           | ✅                                         | ✅                                    |
| Console App (.NET Framework)      | ✅                                         | ✅                                    |
| MSTest (.NET Core)                | ✅                                         | ✅                                    |
| MSTest (.NET Framework)           | ✅                                         | ✅                                    |
| NUnit (.NET Core)                 | ✅                                         | ✅                                    |
| xUnit                             | ❌                                         | ✅                                    |
