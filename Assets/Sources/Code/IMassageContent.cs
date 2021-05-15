using UnityEngine;

namespace Sources.Code
{
    public interface IMassageContent
    {
        Vector2 RequiredRectSize { get; set; }
        object Content { get; set; }
    }
}