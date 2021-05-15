namespace Sources.Code.Massages
{
    class MassageTextContent : IMassageContent
    {
        public object Content { get; set; }

        public MassageTextContent(string text)
        {
            Content = text;
        }
    }
}