using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PopUpNotifications.Data;
using PopUpNotifications.View;
using UnityEngine;

namespace PopUpNotifications.Controller
{
    public class PopUpNotificationsController : MonoBehaviour
    {
        public static PopUpNotificationsController ME { get; private set; }
        
        [Header("Notification")]
        [SerializeField] private NotificationView notificationView;
        
        [Header("Notification Config")]
        [SerializeField] private float waitTimeBetweenNotifications = 1;
        
        private readonly List<NotificationContent> notificationLine = new List<NotificationContent>();
        
        private Coroutine showNotificationCoroutine;
        private WaitForSeconds WaitBetweenNotifications => new WaitForSeconds(waitTimeBetweenNotifications);
        private WaitUntil WaitForNotification => new WaitUntil(() => !notificationView.IsShowing);
        
        private void Awake()
        {
            if (ME == null)
            {
                ME = this;
                DontDestroyOnLoad(this);
                return;
            }
            DestroyImmediate(this);
        }

        public void ShowNotification(string title, string desc = "", NotificationIcon iconType = NotificationIcon.None)
        {
            var confirmPopUpInitializeData = new NotificationContent(title, desc, iconType);
            EnqueueNotification(confirmPopUpInitializeData);
        }
        
        public void ShowNotification(string title, string desc = "", Sprite sprite = null)
        {
            var confirmPopUpInitializeData = new NotificationContent(title, desc, sprite);
            EnqueueNotification(confirmPopUpInitializeData);
        }

        private void EnqueueNotification(NotificationContent initializeData)
        {
            notificationLine.Add(initializeData);

            if (showNotificationCoroutine != null) return;
            showNotificationCoroutine = StartCoroutine(ShowNotification());
        }

        private IEnumerator ShowNotification()
        {
            var hasToWaitToShowNotification = false;
            
            while (notificationLine.Count > 0)
            {
                yield return WaitForNotification;

                if (hasToWaitToShowNotification)
                    yield return WaitBetweenNotifications;
                
                notificationView.ShowNotification(RequestInitializeData());
                hasToWaitToShowNotification = true;
            }
            
            showNotificationCoroutine = null;
        }
        
        private NotificationContent RequestInitializeData()
        {
            var candidateData = notificationLine.FirstOrDefault();
            notificationLine.RemoveAt(0);
            return candidateData;
        }
    }
}