using System.Collections;
using System.Collections.Generic;
using UnityEditor;
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
        videoPlayer.Prepare(); 
        videoPlayer.clip = videoClip;
        if(videoPlayer.isPrepared)
        {
            videoPlayer.playOnAwake = false;
        }
        videoPlayer.prepareCompleted += OnVideoPrepared;
        //videoPlayer.loopPointReached += OnVideoFinished;
    }


    void OnVideoPrepared(VideoPlayer vp)
    {
        Debug.Log("Video preparado: " + vp.clip.name);
    }

    //void OnVideoFinished(VideoPlayer vp)
    //{
    //    Debug.Log("Video terminado: " + vp.clip.name);
    //    vp.Stop();
    //}
}
