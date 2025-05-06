using UnityEngine;

public class ContenedorBotella : MonoBehaviour
{
    public bool aceptaBuenas;
    public TemporizadorPastel temporizador;
    public UIObjetivoBotellas objetivo;

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Botella")) return;

        bool esBuena = other.GetComponent<Botella>().esBuena;

        if (objetivo.botellasObjetivo > 0)
        {
            objetivo.BotellaProcesada(); // Resta objetivo
        }
        else
        {
            if (aceptaBuenas && esBuena)
            {
                temporizador.AñadirTiempo(10f);
            }
            else if (!aceptaBuenas && !esBuena)
            {
                temporizador.AñadirTiempo(10f);
            }
            else
            {
                temporizador.QuitarTiempo(5f);
            }
        }

        Destroy(other.gameObject);
    }
}