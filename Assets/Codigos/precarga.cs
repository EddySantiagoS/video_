using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class precarga : MonoBehaviour
{
    public VideoPlayer[] videoPlayers; 

    void Start()
    {
        foreach (VideoPlayer vp in videoPlayers)
        {
            PreloadVideo(vp);
        }
    }


    public void PreloadVideo(VideoPlayer videoPlayer)
    {

        videoPlayer.playOnAwake = true;


        videoPlayer.Prepare();


        videoPlayer.prepareCompleted += OnVideoPrepared;
    }


    void OnVideoPrepared(VideoPlayer vp)
    {
        Debug.Log("Video preparado: " + vp.url);
        
    }
}
