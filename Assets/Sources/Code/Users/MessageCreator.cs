using Sources.Code.Messages;

namespace Sources.Code.Users
{
    public static class MessageCreator
    {
        public static IMessageFactory MessageFactory { get; set; }
        public static IUIMessageFactory UIMessageFactory { get; set; }
    }
}