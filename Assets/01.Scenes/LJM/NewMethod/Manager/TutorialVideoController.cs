using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TutorialVideoController : MonoBehaviour
{

    public VideoClip[] clips;

    private int idx = 0;
    public VideoPlayer videoPlayer;
    public GameObject rawImage;

    public void ResetIdx()
    {
        this.idx = 0;
    }

    public void Play()
    {
        videoPlayer.Stop();
        if(idx == clips.Length) return;
        videoPlayer.clip = clips[idx++];
        videoPlayer.Play();
    }

    public void Close()
    {
        videoPlayer.gameObject.SetActive(false);
        rawImage.SetActive(false);
    }

    public void Open()
    {
        videoPlayer.gameObject.SetActive(true);
        rawImage.SetActive(true);
    }

    public bool IsNull()
    {
        return videoPlayer == null;
    }
}
