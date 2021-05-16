namespace Sources.Code.Messages
{
    public interface IMessageContent
    {
        object Content { get; set; } //Possible realisation for ImageContent or VideoContent 
    }
}