using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class precarga : MonoBehaviour
{
    // Objetos de la historia (páginas o secciones que se activan)
    public GameObject[] objetosHistoria;

    // Botones del menú de inicio correspondientes a cada página o sección
    public GameObject[] botonesInicio;

    void Start()
    {
        // Inicializamos el estado de los botones en función de los datos guardados
        for (int i = 0; i < botonesInicio.Length; i++)
        {
            // Si el progreso está guardado, desbloqueamos el botón correspondiente
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
            // Si un objeto de historia está activo y su botón aún no está desbloqueado
            if (objetosHistoria[i].activeSelf && botonesInicio[i].activeSelf)
            {
                // Desbloqueamos el botón
                botonesInicio[i].SetActive(false);

                // Guardamos el estado de desbloqueo en PlayerPrefs
                PlayerPrefs.SetInt("BotonDesbloqueado_" + i, 1);
                PlayerPrefs.Save();
            }
        }
    }
}