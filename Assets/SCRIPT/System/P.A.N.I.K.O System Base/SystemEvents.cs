using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SystemEvents : MonoBehaviour
{
    [Header("EVENTS")]
    public UnityEvent OnAwakeLevel;
    public UnityEvent OnStartLevel;

    private void Awake()
    {
        OnAwakeLevel.Invoke();
    }

    void Start()
    {
        OnStartLevel.Invoke();
    }

    void Update()
    {
        
    }
}
