using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using System.Collections.Generic;

public class controladorVideo : MonoBehaviour
{
    public VideoPlayer videoPlayer;    // Asigna el componente VideoPlayer en el inspector
    public Button pauseButton1;        // Asigna el primer botón de pausa en el inspector
    public Button pauseButton2;        // Asigna el segundo botón de pausa en el inspector
    public Button fastForwardButton;   // Asigna el botón para adelantar en el inspector
    public Button rewindButton;        // Asigna el botón para retroceder en el inspector
    public Button audioButton;         // Asigna el botón para mutear/activar el audio en el inspector

    public Image progressBar;

    private bool isPaused = false;
    private bool isMuted = false;

    void Start()
    {
        // Asignar los eventos de clic para los botones
        pauseButton1.onClick.AddListener(TogglePause);
        pauseButton2.onClick.AddListener(TogglePause);
        fastForwardButton.onClick.AddListener(FastForward);
        rewindButton.onClick.AddListener(Rewind);
        audioButton.onClick.AddListener(ToggleAudio);  // Asigna el botón de audio

          progressBar.fillAmount = 0;
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
}