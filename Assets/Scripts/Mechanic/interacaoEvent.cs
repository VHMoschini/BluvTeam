using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class interacaoEvent : MonoBehaviour, IInteragivel
{
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
