using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class precarga : MonoBehaviour
{
    // Objetos de la historia (p�ginas o secciones que se activan)
    public GameObject[] objetosHistoria;

    // Botones del men� de inicio correspondientes a cada p�gina o secci�n
    public GameObject[] botonesInicio;

    void Start()
    {
        // Inicializamos el estado de los botones en funci�n de los datos guardados
        for (int i = 0; i < botonesInicio.Length; i++)
        {
            // Si el progreso est� guardado, desbloqueamos el bot�n correspondiente
            if (PlayerPrefs.GetInt("BotonDesbloqueado_" + i, 0) == 1)
            {
                botonesInicio[i].SetActive(false);
            }
            else
            {
                botonesInicio[i].SetActive(true);
            }
        }
    }

    void Update()
    {
        // Revisamos el estado de los objetos de la historia
        for (int i = 0; i < objetosHistoria.Length; i++)
        {
            // Si un objeto de historia est� activo y su bot�n a�n no est� desbloqueado
            if (objetosHistoria[i].activeSelf && botonesInicio[i].activeSelf)
            {
                // Desbloqueamos el bot�n
                botonesInicio[i].SetActive(false);

                // Guardamos el estado de desbloqueo en PlayerPrefs
                PlayerPrefs.SetInt("BotonDesbloqueado_" + i, 1);
                PlayerPrefs.Save();
            }
        }
    }
}