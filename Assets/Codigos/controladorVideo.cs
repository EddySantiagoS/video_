using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using System.Collections.Generic;

public class controladorVideo : MonoBehaviour
{
    public VideoPlayer videoPlayer;   
    public Button pauseButton1;       
    public Button pauseButton2;       
    public Button fastForwardButton;   
    public Button rewindButton;        
    public Button audioButton;         

    public Button speedButton05;    
    public Button speedButton1;     
    public Button speedButton15;   

     public Button toggleButton; 

    public Image progressBar;

    public GameObject targetObject;
    public GameObject control;



    private bool isPaused = false;
    private bool isMuted = false;
    private bool isVisible = false; 

    void Start()
    {
        // Asignar los eventos de clic para los botones
        pauseButton1.onClick.AddListener(TogglePause);
        pauseButton2.onClick.AddListener(TogglePause);
        fastForwardButton.onClick.AddListener(FastForward);
        rewindButton.onClick.AddListener(Rewind);
        audioButton.onClick.AddListener(ToggleAudio);  // Asigna el botón de audio

        toggleButton.onClick.AddListener(ToggleVisibility);

        speedButton05.onClick.AddListener(() => SetPlaybackSpeed(0.5f));
        speedButton1.onClick.AddListener(() => SetPlaybackSpeed(1.0f));
        speedButton15.onClick.AddListener(() => SetPlaybackSpeed(1.5f));


        progressBar.fillAmount = 0;

        targetObject.SetActive(isVisible);
    }


    void Update()
    {
        // Actualizar el fillAmount de la barra basado en el progreso del video
        if (videoPlayer.isPlaying)
        {
            // El valor de fillAmount va de 0 (vacío) a 1 (lleno), por eso usamos la fracción del tiempo actual respecto al total
            progressBar.fillAmount = (float)(videoPlayer.time / videoPlayer.clip.length);
        }

    }

    void TogglePause()
    {
        if (isPaused)
        {
            videoPlayer.Play();
        }
        else
        {
            videoPlayer.Pause();
        }
        isPaused = !isPaused;
    }

    void FastForward()
    {
        if (videoPlayer.canSetTime)
        {
            videoPlayer.time = Mathf.Min((float)(videoPlayer.time + 5f), (float)videoPlayer.length);
        }
    }

    void Rewind()
    {
        if (videoPlayer.canSetTime)
        {
            videoPlayer.time = Mathf.Max((float)(videoPlayer.time - 5f), 0f);
        }
    }

    void ToggleAudio()
    {
        if (isMuted)
        {
            videoPlayer.SetDirectAudioMute(0, false);  // Activa el audio
        }
        else
        {
            videoPlayer.SetDirectAudioMute(0, true);   // Mutea el audio
        }
        isMuted = !isMuted;
    }


    void ToggleVisibility()
    {
        // Cambiar el estado de visibilidad
        isVisible = !isVisible;

        // Aplicar el nuevo estado al objeto
        targetObject.SetActive(isVisible);
    }

     void SetPlaybackSpeed(float speed)
    {
        videoPlayer.playbackSpeed = speed;
    }

    public void controlador()
    {
        if(!control.activeSelf)
        {
            control.SetActive(true);
        }
        else
        {
            control.SetActive(false);
        }
    }
}