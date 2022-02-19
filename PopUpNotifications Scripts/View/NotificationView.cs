using System.Collections.Generic;
using System.Linq;
using PopUpNotifications.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utils.DOTweens;

namespace PopUpNotifications.View
{
    public class NotificationView : MonoBehaviour
    {
        [Header("Image Configuration")]
        [SerializeField] private Image notificationImage;
        [SerializeField] private List<StandardImageNotification> standardImageNotifications;

        [Header("Texts")]
        [SerializeField] private TextMeshProUGUI notificationTitle;
        [SerializeField] private TextMeshProUGUI notificationDescription;

        [Header("Transforms")]
        [SerializeField] private RectTransform contentRect;
        
        [Header("Notification Config")]
        [SerializeField] private float notificationDuration = 3f;
        [SerializeField] private DOTweenSlideAnim doTweenSlideAnim;

        public bool IsShowing => gameObject.activeSelf;
        
        private NotificationContent currentContentInDisplay;
        
        public void ShowNotification(NotificationContent content)
        {
            currentContentInDisplay = content;
            
            SetUpImage();
            SetUpTexts();
            
            LayoutRebuilder.ForceRebuildLayoutImmediate(contentRect);
            
            gameObject.SetActive(true);
            
            Invoke(nameof(SwipeAway), notificationDuration);
        }

        private void SetUpImage()
        {
            var spriteToSet = currentContentInDisplay.HasSprite
                ? currentContentInDisplay.Sprite
                : GetDefaultSprite(currentContentInDisplay.IconType);

            if (spriteToSet == null)
            {
                notificationImage.gameObject.SetActive(false);  
                return;
            }
            
            notificationImage.sprite = spriteToSet;
            notificationImage.gameObject.SetActive(true);
        }

        private Sprite GetDefaultSprite(NotificationIcon icon)
        {
            return standardImageNotifications.FirstOrDefault(i => i.Type.Equals(icon))?.Sprite;
        }

        private void SetUpTexts()
        {
            notificationTitle.text = currentContentInDisplay.Title;
            
            if (currentContentInDisplay.Description.Equals(string.Empty))
            {
                notificationDescription.gameObject.SetActive(false);
                return;
            }
            notificationDescription.text= currentContentInDisplay.Description;
            notificationDescription.gameObject.SetActive(true);
        }

        private void SwipeAway() => doTweenSlideAnim.SlideOut();
    }
}