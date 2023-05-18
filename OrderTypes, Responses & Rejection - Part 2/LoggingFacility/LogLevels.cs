namespace EngineForTradingServer.Logging
{
    //23) The goal here is to build an extensible logging system/library where we can create various different types of
    //logs, like text logger or console logger or maybe database logger.

    //24) We are going to create an enum that represents different levels of priority levels
    public enum LogLevels
    {
        Error,
        Warning,
        Information,
        Debug

    }
}