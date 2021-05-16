using System;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.Code.Messages
{
    [Serializable]
    public class StyleLayoutCorrections
    {
        public RectOffset textContentNested;
        public RectOffset textContentRoot;
        public RectOffset messageBodyNested;
        public RectOffset messageBodyRoot;
        
        public void SetLayoutNested(VerticalLayoutGroup textContent, VerticalLayoutGroup messageBody)
        {
            textContent.padding = textContentNested;
            messageBody.padding = messageBodyNested;
        }
        
        public void SetLayoutRoot(VerticalLayoutGroup textContent, VerticalLayoutGroup messageBody)
        {
            textContent.padding = textContentRoot;
            messageBody.padding = messageBodyRoot;
        }
    }
}