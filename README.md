# SynchronizationContext in .NET

A [recommendation](https://docs.microsoft.com/en-us/archive/msdn-magazine/2013/march/async-await-best-practices-in-asynchronous-programming#configure-context) when writing async code in .NET is to use `ConfigureAwait(false)` whenever possible.
Whether or not `ConfigureAwait(false)` actually has an effect depends on what context the code runs in.
In general, use `ConfigureAwait(false)` unless you know that you need to capture the current context.
General-purpose library code typically do not need to return back to the original context, while UI applications typically needs to be in the correct context to make changes to UI elements.
See [here](https://devblogs.microsoft.com/dotnet/configureawait-faq/) for more details.

Not all environments publish a custom context by default.
There is a custom context if `SynchronizationContext.Current` is not null, or if `TaskScheduler.Current` is not the thread pool context.
The table below shows whether or not the environments have a custom context by default.
For those environments where both columns have a ✅, you might consider skipping `ConfigureAwait(false)`.
Note that even though a custom context is not set by default, it is still possible for library code to override this.


| Environment                       | `SynchronizationContext.Current` is `null` | `TaskScheduler.Current` is Thread Pool |
| --------------------------------- | :----------------------------------------: | :------------------------------------: |
| ASP.NET Core (.NET Core)          | ✅                                         | ✅                                    |                  
| ASP.NET Core (.NET Framework)     | ✅                                         | ✅                                    |
| ASP.NET MVC                       | ❌                                         | ✅                                    |
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
| Windows Forms (.NET Core)         | ❌                                         | ✅                                    |
| Windows Forms (.NET Framework)    | ❌                                         | ✅                                    |
| WPF (.NET Core)                   | ❌                                         | ✅                                    |
| WPF (.NET Framework)              | ❌                                         | ✅                                    |
| xUnit (.NET Core)                 | ❌                                         | ✅                                    |
