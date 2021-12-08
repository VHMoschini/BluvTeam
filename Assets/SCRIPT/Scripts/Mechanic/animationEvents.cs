using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class animationEvents : MonoBehaviour
{
    private PlayableDirector director;
    void Start()
    {
        director = GetComponent<PlayableDirector>();
    }

    public void rebobinar()
    {
        director.time = 0;
        director.Stop();
        director.Evaluate();
    }
}
