using Microsoft.Extensions.Logging;

namespace POO_A3_Pet.Domain
{
    // A classe Logger implementa o design pattern **Singleton**, garantindo que apenas uma instância do logger seja criada.
    // Isso é importante para garantir a consistência dos logs em toda a aplicação e evitar a criação de múltiplas instâncias desnecessárias.
    public sealed class Logger
    {
        // O construtor é privado para impedir a criação de instâncias externas.
        // Isso garante que a única forma de acessar a instância do logger seja através do método GetInstance().
        private Logger()
        { }

        // A instância do logger é armazenada em um campo estático para garantir que apenas uma instância seja criada.
        private static ILogger _instance;

        // O objeto _lock é usado para garantir a segurança de threads, evitando que múltiplas threads criem instâncias simultaneamente.
        private static readonly object _lock = new object();

        // Método para obter a instância única do logger.
        public static ILogger GetInstance()
        {
            if (_instance == null)
            {
                // Usando o bloqueio (lock) para garantir que apenas uma thread crie a instância do logger.
                // Isso é essencial em um ambiente multi-threaded para evitar criação simultânea de instâncias.
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        // Cria e configura o LoggerFactory para gerar o logger com as configurações desejadas.
                        var loggerFactory = LoggerFactory.Create(builder =>
                        {
                            builder
                                .AddConsole()           // Adiciona logging no console.
                                .AddDebug()             // Adiciona logging de debug.
                                .SetMinimumLevel(LogLevel.Information); // Define o nível mínimo de log (informações de nível "Informational" ou superior).
                        });

                        // Cria a instância do logger com o nome "ApplicationLogger".
                        _instance = loggerFactory.CreateLogger("ApplicationLogger");
                    }
                }
            }
            return _instance; // Retorna a instância única do logger.
        }

        // Método para registrar mensagens de aviso (warning).
        public static void Warn(string text)
        {
            // Chama o método LogWarning da instância do logger para registrar uma mensagem de aviso.
            GetInstance().LogWarning(text);
        }

        // Método para registrar mensagens de erro (error).
        public static void Error(string text)
        {
            // Chama o método LogError da instância do logger para registrar uma mensagem de erro.
            GetInstance().LogError(text);
        }

        // Método para registrar mensagens de informação (informational).
        public static void Info(string message)
        {
            // Chama o método LogInformation da instância do logger para registrar uma mensagem informativa.
            GetInstance().LogInformation(message);
        }
    }
}