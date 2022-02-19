using MissionSystem.Controller;
using MissionSystem.Data;
using PopUpNotifications.Controller;
using PopUpNotifications.Data;
using TranslationSystem.Components;
using TranslationSystem.Controller;
using UnityEngine;

namespace PopUpNotifications.Components
{
    public class NotificationEventListener : MonoBehaviour
    {
        private void Awake()
        {
            MissionController.OnMissionComplete += ShowMissionCompleteNotification;
        }

        private void OnDestroy()
        {
            MissionController.OnMissionComplete -= ShowMissionCompleteNotification;
        }

        private static void ShowMissionCompleteNotification(MissionHolder missionComplete)
        {
            var title = Translate.GetText("missionComplete", TranslateFormat.ToUpper);
            var description = missionComplete.Description;
            
            PopUpNotificationsController.ME.ShowNotification(title, description, NotificationIcon.Trophy);
        }

        //Testing Stuff
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
                PopUpNotificationsController.ME.ShowNotification("WARNING MESSAGE", "THIS IS A TEST",
                    NotificationIcon.Warning);

            if (Input.GetKeyDown(KeyCode.Alpha6))
                PopUpNotificationsController.ME.ShowNotification("WARNING MESSAGE", "THIS IS A TEST",
                    NotificationIcon.Check);
        }
        #endif
    }
}