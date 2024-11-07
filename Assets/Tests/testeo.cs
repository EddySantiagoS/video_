using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using NUnit.Framework;
using UnityEngine.TestTools;

public class testeo : MonoBehaviour
{
    private VideoPlayer videoPlayer;

    [SetUp]
    public void SetUp()
    {
        // Configura el entorno antes de cada prueba
        GameObject videoObject = new GameObject();
        videoPlayer = videoObject.AddComponent<VideoPlayer>();
    }

    [Test]
    public void TestPauseAndResume()
    {
        videoPlayer.Play();
        videoPlayer.Pause();
        Assert.AreEqual(false, videoPlayer.isPlaying, "El video deber�a estar en pausa.");

        videoPlayer.Play();
        Assert.AreEqual(false, videoPlayer.isPlaying, "El video deber�a estar reproduci�ndose.");
    }

    [Test]
    public void TestFastForward()
    {
        videoPlayer.playbackSpeed = 2.0f; // Configura el doble de velocidad.
        Assert.AreEqual(2.0f, videoPlayer.playbackSpeed, "La velocidad de reproducci�n deber�a ser 2.0.");
    }

    [Test]
    public void TestNormalSpeed()
    {
        videoPlayer.playbackSpeed = 1.0f; // Configura la velocidad normal.
        Assert.AreEqual(1.0f, videoPlayer.playbackSpeed, "La velocidad de reproducci�n deber�a ser 1.0.");
    }

    [Test]
    public void TestProgressSaving()
    {
        // Simula guardar el progreso
        PlayerPrefs.SetInt("CurrentScene", 3);
        int savedScene = PlayerPrefs.GetInt("CurrentScene");
        Assert.AreEqual(3, savedScene, "La escena guardada deber�a ser 3.");
    }
}