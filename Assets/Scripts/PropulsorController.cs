using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropulsorController : MonoBehaviour
{
    [Header("Parámetros de Nave")]
    public float combustibleTotal = 100f;
    public float aceleracionMaxima = 10f;
    public float velocidadActual = 0f;
    public float consumoPorSegundo = 5f;
    public float desaceleracionPorSegundo = 10f;
    public KeyCode tecla;

    [SerializeField] private float combustibleActual;

    void Start()
    {
        combustibleActual = combustibleTotal;
        ActualizarUI();
    }

    void Update()
    {
        if (Input.GetKey(tecla) && combustibleActual > 0)
        {
            Acelerar();
        }
        else
        {
            Desacelerar();
        }

        // Prueba: Agregar combustible con la tecla F
        if (Input.GetKeyDown(KeyCode.F))
        {
            AgregarCombustible(20f);
        }

        ActualizarUI();
    }

    void Acelerar()
    {
        velocidadActual += aceleracionMaxima * Time.deltaTime;
        velocidadActual = Mathf.Clamp(velocidadActual, 0, aceleracionMaxima);

        combustibleActual -= consumoPorSegundo * Time.deltaTime;
        combustibleActual = Mathf.Clamp(combustibleActual, 0, combustibleTotal);
    }

    void Desacelerar()
    {
        velocidadActual -= desaceleracionPorSegundo * Time.deltaTime;
        velocidadActual = Mathf.Max(velocidadActual, 0);
    }

    void AgregarCombustible(float cantidad)
    {
        combustibleActual += cantidad;
        combustibleActual = Mathf.Clamp(combustibleActual, 0, combustibleTotal);
        Debug.Log("Combustible agregado: " + cantidad + " | Combustible actual: " + combustibleActual);
    }

    void ActualizarUI()
    {

    }
}
