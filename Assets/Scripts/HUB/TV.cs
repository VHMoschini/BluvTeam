using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TV : MonoBehaviour, IInteragivel
{
    #region [ Public ]

    public Material highLightMaterial;
    public Material defaultMaterial;

    public MeshRenderer mr;

    #endregion

    #region [ Private ]



    #endregion

    private void Start()
    {
        //mr = GetComponent<MeshRenderer>();
    }

    public void DownLight()
    {
        mr.material = defaultMaterial;
    }

    public void HighLight()
    {
        mr.material = highLightMaterial;
    }

    public void Interaction()
    {
        Debug.Log(this.name);
    }
}
