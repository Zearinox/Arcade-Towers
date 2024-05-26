using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torre : MonoBehaviour
{
    public Transform objetivo; // Referencia al personaje
    public GameObject proyectilPrefab; // Prefab del proyectil
    public float rangoDisparo = 10f; // Rango de la torre

    private float tiempoEntreDisparos;
    private float tiempoSiguienteDisparo;

    void Start()
    {
        tiempoSiguienteDisparo = Time.time + Random.Range(1f, 3f);
    }

    void Update()
    {
        if (objetivo == null)
        {
            Debug.LogError("Objetivo no asignado a la torre.");
            return;
        }

        float distanciaAlObjetivo = Vector3.Distance(transform.position, objetivo.position);

        if (distanciaAlObjetivo <= rangoDisparo)
        {
            if (Time.time >= tiempoSiguienteDisparo)
            {
                Disparar();
                tiempoSiguienteDisparo = Time.time + Random.Range(1f, 5f);
            }
        }
    }

    void Disparar()
    {
        // Crear el proyectil y direccionarlo hacia el objetivo
        GameObject proyectil = Instantiate(proyectilPrefab, transform.position, transform.rotation);
        Proyectil proyectilScript = proyectil.GetComponent<Proyectil>();

        if (proyectilScript != null)
        {
            proyectilScript.ConfigurarObjetivo(objetivo);
        }
    }
}