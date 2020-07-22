# SynchronizationContext in .NET

A [recommendation](https://docs.microsoft.com/en-us/archive/msdn-magazine/2013/march/async-await-best-practices-in-asynchronous-programming#configure-context) when writing async code in .NET is to use `ConfigureAwait(false)` whenever possible.
Whether or not `ConfigureAwait(false)` actually has an effect depends on what context the code runs in.
In general, use `ConfigureAwait(false)` unless you know that you need to capture the current context.
General-purpose library code typically do not need to return back to the original context, while UI applications typically needs to be in the correct context to make changes to UI elements.
See [here](https://devblogs.microsoft.com/dotnet/configureawait-faq/) for more details.

Not all environments publish a custom context by default.
There is a custom context if `SynchronizationContext.Current` is not null, or if `TaskScheduler.Current` is not the thread pool context.
The table below shows whether or not the environments have a custom context by default.
For those environments where both columns have a :white_check_mark:, you might consider skipping `ConfigureAwait(false)`.
Note that even though a custom context is not set by default, it is still possible for library code to override this.


| Environment                                        | `SynchronizationContext.Current` is `null` | `TaskScheduler.Current` is Thread Pool |
| -------------------------------------------------- | :----------------------------------------: | :------------------------------------: |
| ASP.NET Core (.NET Core)                           | :white_check_mark:                         | :white_check_mark:                     |
| ASP.NET Core (.NET Framework)                      | :white_check_mark:                         | :white_check_mark:                     |
| ASP.NET Core gRPC Service                          | :white_check_mark:                         | :white_check_mark:                     |
| ASP.NET MVC                                        | :x:                                        | :white_check_mark:                     |
| ASP.NET Web API                                    | :x:                                        | :white_check_mark:                     |
| ASP.NET Web Forms                                  | :x:                                        | :white_check_mark:                     |
| Azure Durable Functions v2 Orchestrators           | :x:                                        | :x:                                    |
| Azure Functions v1                                 | :white_check_mark:                         | :white_check_mark:                     |
| Azure Functions v2                                 | :white_check_mark:                         | :white_check_mark:                     |
| Azure Functions v3                                 | :white_check_mark:                         | :white_check_mark:                     |
| Blazor Server                                      | :x:                                        | :white_check_mark:                     |
| Blazor WebAssembly                                 | :white_check_mark:                         | :white_check_mark:                     |
| Console App (.NET Core)                            | :white_check_mark:                         | :white_check_mark:                     |
| Console App (.NET Framework)                       | :white_check_mark:                         | :white_check_mark:                     |
| MSTest (.NET Core)                                 | :white_check_mark:                         | :white_check_mark:                     |
| MSTest (.NET Framework)                            | :white_check_mark:                         | :white_check_mark:                     |
| NUnit (.NET Core)                                  | :white_check_mark:                         | :white_check_mark:                     |
| WCF Service                                        | :white_check_mark:                         | :white_check_mark:                     |
| Windows Forms (.NET Core)                          | :x:                                        | :white_check_mark:                     |
| Windows Forms (.NET Framework)                     | :x:                                        | :white_check_mark:                     |
| WPF (.NET Core)                                    | :x:                                        | :white_check_mark:                     |
| WPF (.NET Framework)                               | :x:                                        | :white_check_mark:                     |
| Xamarin Forms (Android)                            | :x:                                        | :white_check_mark:                     |
| xUnit (.NET Core)                                  | :x:                                        | :white_check_mark:                     |
