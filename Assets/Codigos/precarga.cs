using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class precarga : MonoBehaviour
{
    public VideoPlayer[] videoPlayers; 
    public VideoClip[] videoClips;    

    void Update()
    {
        for (int i = 0; i < videoPlayers.Length; i++)
        {
            PreloadVideo(videoPlayers[i], videoClips[i]); 
        }
    }

    public void PreloadVideo(VideoPlayer videoPlayer, VideoClip videoClip)
    {
        videoPlayer.playOnAwake = false;
        videoPlayer.Prepare(); 
        videoPlayer.clip = videoClip;
        if(videoPlayer.isPrepared)
        {
            videoPlayer.Play();
        }
        videoPlayer.prepareCompleted += OnVideoPrepared;
    }


    void OnVideoPrepared(VideoPlayer vp)
    {
        Debug.Log("Video preparado: " + vp.clip.name);
    }
}
