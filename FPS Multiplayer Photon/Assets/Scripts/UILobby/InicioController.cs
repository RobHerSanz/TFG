﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InicioController : MonoBehaviour
{
    [SerializeField]
    GameObject jugar;
    [SerializeField]
    GameObject estadisticas;
    [SerializeField]
    GameObject opciones;

    public void Show()
    {

        jugar.SetActive(false);
        estadisticas.SetActive(false);
        opciones.SetActive(false);


    }
}
