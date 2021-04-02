using System.Collections;
using System.Collections.Generic;
using UnityEngine.Video;
using UnityEngine;

public class tv_manager : MonoBehaviour
{
    public GameObject screen;
    public GameObject Portal1;

    public VideoPlayer videoPlayer;
    public VideoClip[] clips;

    public bool watchMemory;
    public bool isOff;
    public bool playerNear;

    private void Awake()
    {
        videoPlayer = screen.GetComponent<VideoPlayer>();
    }

    void Start()
    {
        videoPlayer.clip = clips[0];
        Portal1.SetActive(false);
    }

    void Update()
    {
        if(playerNear == true && watchMemory == false)
        {
            if (Input.GetMouseButton(0))
            {
                watchMemory = true;
                videoPlayer.clip = clips[1];
            }
        }

        if(videoPlayer.clip == clips[1] && videoPlayer.isPlaying == false)
        {
            isOff = true;
            Portal1.SetActive(true);
        }

        if(videoPlayer.clip == clips[0] && videoPlayer.isPlaying == false)
        {
            videoPlayer.Play();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            playerNear = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            playerNear = false;
        }
    }
}
