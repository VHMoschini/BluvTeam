using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;
using UnityEngine.Video;

public class VideoEvents : MonoBehaviour
{
    private VideoPlayer videoPlayer;
    public UnityEvent OnFinished;
    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            OnFinished.Invoke();

        Debug.Log(videoPlayer.frame + "  " + ((long)videoPlayer.frameCount));
        if (videoPlayer.frame == (((long)videoPlayer.frameCount) - 2))
        {
            OnFinished.Invoke();
        }
    }
}
