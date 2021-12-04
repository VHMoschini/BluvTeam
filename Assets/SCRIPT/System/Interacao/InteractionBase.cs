using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionBase : MonoBehaviour,IInteragivel
{
    protected Material mat_highlight;
    protected Material mat_default;

    private MeshRenderer _renderer;
    //public virtual bool interagivel => true;

    public virtual bool interagivel { get ; set; }

    void Awake()
    {
        mat_default = Resources.Load<Material>("MATERIALS/INTERACAO_DEFAULT");
        mat_highlight = Resources.Load<Material>("MATERIALS/INTERACAO_HIGHLIGHT");

        _renderer = GetComponent<MeshRenderer>();
    }

    public virtual void DownLight()
    {
        if(_renderer != null)
        _renderer.material = mat_default;
    }

    public virtual void HighLight()
    {
        if (_renderer != null)
            _renderer.material = mat_highlight;
    }

    public virtual void Interaction()
    {
        throw new System.NotImplementedException();
    }
}
