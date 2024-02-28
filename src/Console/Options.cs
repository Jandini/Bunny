using CommandLine;

class Options
{

    [Verb("send", isDefault: false, HelpText = "Send text message.")]
    internal class Send
    {
        [Option('t', "text", HelpText = "Text message.", Required = false)]
        public string Text { get; set; }
    }

    [Verb("receive", isDefault: false, HelpText = "Receive text message.")]
    internal class Receive
    {
    
    }
}
