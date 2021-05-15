using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.Code.Massages
{
    public class UITextMassage : MonoBehaviour, IUIMassage
    {
        [SerializeField] private Image userLogo;
        [SerializeField] private TextMeshProUGUI nameText;
        [SerializeField] private TextMeshProUGUI contentText;
        [SerializeField] private TextMeshProUGUI dateText;

        [SerializeField] private Image massageImage;
        [SerializeField] private Sprite rootImage;
        [SerializeField] private Sprite nestedImage;

        public GameObject UIRootGameObject { get; set; }
        public GameObject UIMassageGo { get; set; }

        public void Initialize(Massage massage)
        {
            UIRootGameObject = gameObject;
            UIMassageGo = massageImage.gameObject;
            
            nameText.SetText(massage.Author.UserName);
            userLogo.sprite = massage.Author.UserAvatar;
            contentText.SetText(massage.Content.Content as string);
            var dayPassed = DateTime.Now > massage.SendedDate.AddDays(1);
            dateText.SetText(massage.SendedDate.ToString(dayPassed ? "M/d/yy" : "HH:mm"));
        }

        public void SetNameVisibility(bool to)
        {
            nameText.gameObject.SetActive(to);
        }

        public void SetImageType(UIMassageImageType to)
        {
            switch (to)
            {
                default: //Root
                    massageImage.sprite = rootImage;
                    break;
                case UIMassageImageType.Nested:
                    massageImage.sprite = nestedImage;
                    break;
            }
        }
    }
}
