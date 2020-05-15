using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugarController : MonoBehaviour
{
    [SerializeField]
    GameObject jugar;
    [SerializeField]
    GameObject estadisticas;
    [SerializeField]
    GameObject opciones;

    public void Show()
    {

        jugar.SetActive(true);
        estadisticas.SetActive(false);
        opciones.SetActive(false);


    }
}
