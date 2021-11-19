using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SaveTools))]
public class ColectableItem : MonoBehaviour, IInteragivel
{
    [HideInInspector]
    public bool interagivel => true;

    public Colectable coletavel;

    private SaveTools saveTool;
    private ColectableNotification notification;

    void Start()
    {
        saveTool = GetComponent<SaveTools>();
        notification = FindObjectOfType<ColectableNotification>();

    }

    public void DownLight()
    {
    }

    public void HighLight()
    {
    }

    public void Interaction()
    {
        saveTool.saveColectable(coletavel);
        //Debug.Log( PlayerPrefs.GetString(Constantes.COLECTABLE_LIST));

        if (notification != null)
            notification.Notificate((int)coletavel);

        gameObject.SetActive(false); // alterar para fade out mais bonito
    }


    void Update()
    {
        
    }
}
