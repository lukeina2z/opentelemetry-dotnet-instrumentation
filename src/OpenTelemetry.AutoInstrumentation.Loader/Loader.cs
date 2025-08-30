// Copyright The OpenTelemetry Authors
// SPDX-License-Identifier: Apache-2.0

using System.Reflection;
using OpenTelemetry.AutoInstrumentation.Logging;

namespace OpenTelemetry.AutoInstrumentation.Loader;

/// <summary>
/// A class that attempts to load the OpenTelemetry.AutoInstrumentation .NET assembly.
/// </summary>
internal partial class Loader
{
    private static readonly IOtelLogger Logger = OtelLogging.GetLogger("Loader");

    /// <summary>
    /// Initializes static members of the <see cref="Loader"/> class.
    /// This method also attempts to load the OpenTelemetry.AutoInstrumentation .NET assembly.
    /// </summary>
    static Loader()
    {
        string value = Environment.GetEnvironmentVariable("Force_Sleep") ?? string.Empty;
        if (!string.IsNullOrEmpty(value) &&
            string.Equals(value, "true", StringComparison.OrdinalIgnoreCase))
        {
            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(30));
        }

        try
        {
            AppDomain.CurrentDomain.AssemblyResolve += AssemblyResolver.AssemblyResolve_ManagedProfilerDependencies;
        }
        catch (Exception ex)
        {
            Logger.Error(ex, "Unable to register a callback to the CurrentDomain.AssemblyResolve event.");
        }

        TryLoadManagedAssembly();
    }

    private static void TryLoadManagedAssembly()
    {
        Logger.Information("Managed Loader TryLoadManagedAssembly()");

        try
        {
            var assembly = Assembly.Load("OpenTelemetry.AutoInstrumentation");
            if (assembly == null)
            {
                throw new FileNotFoundException("The assembly OpenTelemetry.AutoInstrumentation could not be loaded");
            }

            var type = assembly.GetType("OpenTelemetry.AutoInstrumentation.Instrumentation", throwOnError: false);
            if (type == null)
            {
                throw new TypeLoadException("The type OpenTelemetry.AutoInstrumentation.Instrumentation could not be loaded");
            }

            var method = type.GetRuntimeMethod("Initialize", Type.EmptyTypes);
            if (method == null)
            {
                throw new MissingMethodException("The method OpenTelemetry.AutoInstrumentation.Instrumentation.Initialize could not be loaded");
            }

            method.Invoke(obj: null, parameters: null);
        }
        catch (Exception ex)
        {
            Logger.Error(ex, "Error when loading managed assemblies. {0}", ex.Message);
            throw;
        }
    }
}
