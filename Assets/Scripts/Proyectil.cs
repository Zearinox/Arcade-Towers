using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    public float velocidad = 20f; // Velocidad del proyectil
    private Transform objetivo; // El objetivo al que se dirigirá el proyectil

    public void ConfigurarObjetivo(Transform _objetivo)
    {
        objetivo = _objetivo;
    }

    void Update()
    {
        if (objetivo == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 direccion = objetivo.position - transform.position;
        float distanciaEnEsteFrame = velocidad * Time.deltaTime;

        if (direccion.magnitude <= distanciaEnEsteFrame)
        {
            GolpearObjetivo();
            return;
        }

        transform.Translate(direccion.normalized * distanciaEnEsteFrame, Space.World);
    }

    void GolpearObjetivo()
    {
        Destroy(gameObject);
    }
}