using UnityEngine;

namespace PopUpNotifications.Data
{
    public class NotificationContent
    {
        public Sprite Sprite { get; private set; }
        public NotificationIcon IconType { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public bool HasSprite => Sprite != null;
        
        public NotificationContent(string title, string description = "", NotificationIcon iconType = NotificationIcon.None)
        {
            Title = title;
            Description = description;
            IconType = iconType;
        }

        public NotificationContent(string title, string description = "", Sprite sprite = null)
        {
            Title = title;
            Description = description;
            Sprite = sprite;
        }
    }
}