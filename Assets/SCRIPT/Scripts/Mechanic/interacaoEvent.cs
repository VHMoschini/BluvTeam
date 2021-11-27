using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class interacaoEvent : MonoBehaviour, IInteragivel
{
    // [ Pra implementar a interface deve ser feito essa implementação ]
    [Space(10)]
    public bool Interagivel = true;
    //bool IInteragivel.interagivel { get => Interagivel; }
    public virtual bool interagivel { get; set; }


    [SerializeField] private Material defaultMaterial;
    [SerializeField] private Material highlightedMaterial;
    private MeshRenderer mr;
    public UnityEvent onInterect;

    private void Start()
    {
        mr = GetComponent<MeshRenderer>();
    }

    public void DownLight()
    {
        mr.material = defaultMaterial;
    }

    public void HighLight()
    {
        mr.material = highlightedMaterial;
    }

    public void Interaction()
    {
        onInterect.Invoke();
    }
}
