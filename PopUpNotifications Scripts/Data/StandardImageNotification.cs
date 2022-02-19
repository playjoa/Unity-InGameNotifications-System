using System;
using UnityEngine;

namespace PopUpNotifications.Data
{
    [Serializable]
    public class StandardImageNotification
    {
        [SerializeField] private NotificationIcon iconType;
        [SerializeField] private Sprite notificationSprite;

        public NotificationIcon Type => iconType;
        public Sprite Sprite => notificationSprite;
    }
}