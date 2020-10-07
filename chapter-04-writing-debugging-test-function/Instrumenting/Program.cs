using System.IO;
using System.Diagnostics;
using Microsoft.Extensions.Configuration;

namespace Instrumenting
{
    class Program
    {
        static void Main(string[] args)
        {
            Trace.Listeners.Add(new TextWriterTraceListener(File.CreateText("Log.txt")));

            Trace.AutoFlush = true;
            Debug.WriteLine("Debugs says, Im watching!");
            Trace.WriteLine("Trace says, Im watching!");

            // Criando o builder de configuraçao do appsettings.json
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            var ts = new TraceSwitch(
                displayName: "PacktSwitch",
                description: "Esse switch é setado via JSON config"
            );

            configuration.GetSection("PacktSwitch").Bind(ts);
            Trace.WriteLineIf(ts.TraceError, "Trace error");
            Trace.WriteLineIf(ts.TraceWarning, "Trace Warning");
            Trace.WriteLineIf(ts.TraceInfo, "Trace info");
            Trace.WriteLineIf(ts.TraceVerbose, "Trace Verbose");

        }
    }
}
