using Sources.Code.Massages;
using UnityEngine;

namespace Sources.Code.Chat
{
    public class UIChatAnimations : MonoBehaviour
    {
        public static void MassageAppear(IUIMassage massage)
        {
            massage.UIRootGameObject.transform.localScale = new Vector3(1, 0);
            massage.UIMassageGo.transform.localScale = new Vector3(0, 0);
            massage.UIRootGameObject.LeanScale(Vector3.one, 0.1f).setEaseOutCirc().setOnComplete(() =>
            {
                massage.UIMassageGo.LeanScale(Vector3.one, 0.2f).setEaseOutCirc();
            });
        }
    }
}
