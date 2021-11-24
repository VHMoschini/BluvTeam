using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SaveTools))]
public class ColectableItem : InteractionBase
{
    public Colectable coletavel;

    private SaveTools saveTool;
    private ColectableNotification notification;

    void Start()
    {
        saveTool = GetComponent<SaveTools>();
        notification = FindObjectOfType<ColectableNotification>();
    }

    public override void Interaction()
    {
        saveTool.saveColectable(coletavel);

        if (notification != null)
            notification.Notificate((int)coletavel);

        gameObject.SetActive(false); // alterar para fade out mais bonito
    }
}
