using PopUpNotifications.Controller;
using PopUpNotifications.Data;
using UnityEngine;

namespace PopUpNotifications.Components
{
    public class NotificationEventListener : MonoBehaviour
    {
        private void Awake()
        {
            //Subscribe To Your GameEvents Here
            //GameManager.OnSomething += ShowNotification;
        }

        private void OnDestroy()
        {
            //Unsubscribe To Your GameEvents Here
            //GameManager.OnSomething -= ShowNotification;
        }

        private static void ShowNotification()
        {
            var title = "This is a Notification!";
            var description = "This is the Description";
            
            PopUpNotificationsController.ME.ShowNotification(title, description, NotificationIcon.Information);
        }

        //Debug Stuff
       #if UNITY_EDITOR
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha0))
                PopUpNotificationsController.ME.ShowNotification("TROPHY", "THIS IS A TEST", NotificationIcon.Trophy);

            if (Input.GetKeyDown(KeyCode.Alpha1))
                PopUpNotificationsController.ME.ShowNotification("NO IMAGE", "THIS IS A TEST", NotificationIcon.None);

            if (Input.GetKeyDown(KeyCode.Alpha2))
                PopUpNotificationsController.ME.ShowNotification("ERROR MESSAGE", "THIS IS A TEST",
                    NotificationIcon.Error);

            if (Input.GetKeyDown(KeyCode.Alpha3))
                PopUpNotificationsController.ME.ShowNotification("INFO MESSAGE", "THIS IS A TEST",
                    NotificationIcon.Information);

            if (Input.GetKeyDown(KeyCode.Alpha4))
                PopUpNotificationsController.ME.ShowNotification("WARNING MESSAGE", "THIS IS A TEST",
                    NotificationIcon.Warning);

            if (Input.GetKeyDown(KeyCode.Alpha5))
                PopUpNotificationsController.ME.ShowNotification("CHECK MESSAGE", "THIS IS A TEST",
                    NotificationIcon.Check);
        }
        #endif
    }
}