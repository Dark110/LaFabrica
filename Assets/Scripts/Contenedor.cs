using UnityEngine;

public class ContenedorBotella : MonoBehaviour
{
    public bool aceptaBuenas;
    public TemporizadorPastel temporizador;
    public int botellasObjetivo = 0; // Reemplaza la referencia a UIObjetivoBotellas
    public UIObjetivoBotellas objetivo;
    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Botella")) return;

        Botella botella = other.GetComponent<Botella>();
        if (botella == null) return;

        if (objetivo == null)
        {
            Debug.LogError("Falta la referencia al script UIObjetivoBotellas.");
            return;
        }


        bool esBuena = botella.esBuena;

        if (botellasObjetivo > 0)
        {
            botellasObjetivo--; // Resta objetivo directamente
            Debug.Log("Botellas restantes: " + botellasObjetivo);
        }
        else
        {
            if (aceptaBuenas && esBuena)
            {
                temporizador.AñadirTiempo(3f);
            }
            else if (!aceptaBuenas && !esBuena)
            {
                temporizador.AñadirTiempo(3f);
            }
            else
            {
                temporizador.QuitarTiempo(5f);
            }
        }

        Destroy(other.gameObject);
    }
}