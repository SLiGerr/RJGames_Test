namespace Sources.Code.Messages
{
    class MessageTextContent : IMessageContent
    {
        public object Content { get; set; }

        public MessageTextContent(string text)
        {
            Content = text;
        }
    }
}