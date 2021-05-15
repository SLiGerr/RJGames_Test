using UnityEngine;

namespace Sources.Code.Massages
{
    public interface IUIMassage
    {
        GameObject UIRootGameObject { get; set; }
        GameObject UIMassageGo { get; set; }
        void Initialize(Massage massage);
        void SetNameVisibility(bool to);
        void SetImageType(UIMassageImageType to);
    }

    public enum UIMassageImageType
    {
        Root,
        Nested
    }
}