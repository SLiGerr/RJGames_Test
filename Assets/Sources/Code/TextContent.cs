using UnityEngine;

namespace Sources.Code
{
    class TextMassageContent : IMassageContent
    {
        public Vector2 RequiredRectSize { get; set; }
        public object Content { get; set; }

        public TextMassageContent(string text)
        {
            
            Content = text;
        }
    }
}