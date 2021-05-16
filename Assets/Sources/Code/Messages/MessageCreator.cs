namespace Sources.Code.Messages
{
    public static class MessageCreator
    {
        public static IMessageFactory MessageFactory { get; set; }
        public static IUIMessageFactory UIMessageFactory { get; set; }
    }
}