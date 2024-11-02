using Microsoft.Extensions.Logging;

namespace POO_A3_Pet.Domain
{
    // Implementado o design pattern de singleton para garantir que haja apenas uma instancia da classe de log
    public sealed class Logger
    {
        private Logger()
        { }

        private static ILogger _instance;
        private static readonly object _lock = new object();

        public static ILogger GetInstance()
        {
            if (_instance == null)
            {
                // usando lock para assegurar que a instância de _instance seja criada uma vez,
                // mesmo em um ambiente com múltiplas threads.
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        // Cria e configura o LoggerFactory para gerar o logger
                        var loggerFactory = LoggerFactory.Create(builder =>
                        {
                            builder
                                .AddConsole()           // Adiciona logging no console
                                .AddDebug()             // Adiciona logging de debug
                                .SetMinimumLevel(LogLevel.Information); // Nível mínimo de log
                        });

                        // Cria a instância do logger
                        _instance = loggerFactory.CreateLogger("ApplicationLogger");
                    }
                }
            }
            return _instance;
        }

        public static void Warn(string text)
        {
            GetInstance().LogWarning(text);
        }

        public static void Error(string text)
        {
            GetInstance().LogError(text);
        }

        public static void Info(string message)
        {
            GetInstance().LogInformation(message);
        }
    }
}