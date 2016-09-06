/* Взято с гитхаба
 */
using System.Linq;
using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.Events;

// Adding a listener to OnPointerEnter (uGui)
// need for plyRPF_UI mouse detecting
public static class Extensions {

    public static void AddListener(this EventTrigger eventTrigger, EventTriggerType type, UnityAction action) {
        if (eventTrigger.delegates == null) {
            eventTrigger.delegates = new List<EventTrigger.Entry>();
        }
        var entry = eventTrigger.delegates.Find(e => e.eventID == type);

        if (entry == null) {
            entry = new EventTrigger.Entry();
            entry.eventID = type;
            entry.callback = new EventTrigger.TriggerEvent();

            eventTrigger.delegates.Add(entry);
        }
        entry.callback.AddListener((eventData) => action());

    }

    public static void SetSelected(this EventSystem eventSystem, MonoBehaviour selected) {
        var pointer = new BaseEventData(eventSystem);
        eventSystem.SetSelectedGameObject(selected.gameObject, pointer);
    }

    public static void SetSelected(this EventSystem eventSystem, GameObject selected) {
        var pointer = new BaseEventData(eventSystem);
        eventSystem.SetSelectedGameObject(selected, pointer);
    }
}

// Еще можно глянуть http://answers.unity3d.com/questions/781726/how-do-i-add-a-listener-to-onpointerenter-ugui.html   ...хоть там и не работает
// Выдает null , но что-то полезное там есть