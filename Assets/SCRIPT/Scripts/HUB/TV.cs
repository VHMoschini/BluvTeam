using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Video;

public class TV : MonoBehaviour, IInteragivel
{
    // [ Pra implementar a interface deve ser feito essa implementação ]
    [Space(10)]
    public bool Interagivel = true;
    public virtual bool interagivel { get; set; }

    public MeshRenderer mr;
    public Material highLightMaterial;
    public Material defaultMaterial;

    [Space(20)]
    public UnityEvent onClick;

    //public bool interagivel { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

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
        onClick.Invoke();
    }
}
