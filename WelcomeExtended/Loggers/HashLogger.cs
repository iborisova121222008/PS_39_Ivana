using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;


namespace WelcomeExtended.Loggers
{
    public class HashLogger : ILogger
    {
        private readonly ConcurrentDictionary<int, string> _logMessages;

        //        - readonly се използва за деклариране на поле, чиято стойност може да бъде
        //задавана/променяне еднократно, по време на декларацията или в
        //конструктора на класа.
        //- ConcurrentDictionary е структура от данни, която позволява паралелна
        //работа със стойности, съхранявани в речник.Създадена е като аналог на
        //обикновените речници в C#, но е по-сигурна при работа от множество
        //нишки, като позволява едновременна работа от много места. <int, string> са
        //типовете които ConcurrentDictionary използва за ключа и стойността
        //които ще се запаметяват в речника.


        private string _name;

        public HashLogger(string name)
        {
            _name = name;
            _logMessages = new ConcurrentDictionary<int, string>();
        }

        public IDisposable BeginScope<TState>(TState state)
        {

            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            var message = formatter(state, exception);

            switch (logLevel)
            {
                case LogLevel.Critical:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;

                case LogLevel.Error:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    break;

                case LogLevel.Warning:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;

            }

            Console.WriteLine("- LOGGER -");
            var messageToBeLogged = new StringBuilder();
            messageToBeLogged.Append($"[{logLevel}]");
            messageToBeLogged.AppendFormat(" [{0}]", _name);
            Console.WriteLine(messageToBeLogged);
            Console.WriteLine($" {formatter(state, exception)}");
            Console.WriteLine("- LOGGER -");
            Console.ResetColor();
            _logMessages[eventId.Id] = message;


        }

        public void PrintAllMessages()
        {
            Console.WriteLine("\n--- Всички логове ---");
            if (_logMessages.Count == 0)
            {
                Console.WriteLine("Няма записани съобщения.");
                return;
            }

            foreach (var log in _logMessages)
            {
                Console.WriteLine($"EventId: {log.Key}, Message: {log.Value}");
            }
            Console.WriteLine("--- Край на логовете ---\n");
        }
        public void PrintEventById(int eventId)
        {
            if (_logMessages.TryGetValue(eventId, out string message))
            {
                Console.WriteLine($"\n--- Лог за EventId {eventId} ---");
                Console.WriteLine(message);
                Console.WriteLine("--- Край на лога ---\n");
            }
            else
            {
                Console.WriteLine($"Няма събитие с EventId {eventId}.");
            }
        }

        public void DeleteEventById(int eventId)
        {
            if (_logMessages.TryRemove(eventId, out _))
            {
                Console.WriteLine($"Събитие с EventId {eventId} беше успешно изтрито.");
            }
            else
            {
                Console.WriteLine($"Не беше намерено събитие с EventId {eventId}.");
            }
        }
    }
}
