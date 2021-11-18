using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveTools : MonoBehaviour
{
    private SaveManager save;
    private void Awake() => save = FindObjectOfType<SaveManager>();

    public void saveColectable(Colectable coletavel) => save.SAVE_COLECIONAVEL(coletavel);
}
