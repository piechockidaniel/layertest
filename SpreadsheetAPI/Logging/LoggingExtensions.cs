using Owin;

namespace SpreadsheetAPI.Logging
{
    public static class LoggingExtensions
    {
        public static void AddUniqueIdHeader(this IAppBuilder appBuilder)
        {
            appBuilder.Use<UniqueIDComponent>();
        }

    }
}