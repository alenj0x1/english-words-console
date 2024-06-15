using english_words_console.Classes;

Core core = new();
ConsoleLogs consoleLogs = new ConsoleLogs();

consoleLogs.Info("Iniciando la aplicación");

if (!await core.CheckWordsBase()) return;

core.Welcome();
