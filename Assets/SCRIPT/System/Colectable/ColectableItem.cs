using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SaveTools))]
public class ColectableItem : InteractionBase
{
    public Colectable coletavel;

    private SaveTools saveTool;
    private ColectableNotification notification;

    [Header("EVENTS")]
    public UnityEvent OnInteraction;

    void Start()
    {
        saveTool = GetComponent<SaveTools>();
        notification = FindObjectOfType<ColectableNotification>();

        interagivel = true;
    }

    public override void Interaction()
    {
        OnInteraction.Invoke();

        saveTool.saveColectable(coletavel);

        if (notification != null)
            notification.Notificate((int)coletavel);

        gameObject.SetActive(false); // alterar para fade out mais bonito
    }
}
