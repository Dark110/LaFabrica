using TMPro;
using UnityEngine;

public class UIObjetivoBotellas : MonoBehaviour
{
    public int botellasObjetivo = 0;
    public TextMeshProUGUI textoObjetivo;
    public TemporizadorPastel temporizador;

    public bool objetivoCompletado => botellasObjetivo <= 0; // ✅ Esta línea arregla el error

    void Start()
    {
        botellasObjetivo = Random.Range(3, 11);
        ActualizarTexto();
    }

    void ActualizarTexto()
    {
        textoObjetivo.text = "Procesa " + botellasObjetivo + " botellas para comenzar a puntuar.";
    }

    void ProcesarBotella(GameObject botella)
    {
        bool esCorrecta = botella.CompareTag("BotellaBuena");
        bool esIncorrecta = botella.CompareTag("BotellaMala");

        if (objetivoCompletado && esCorrecta)
        {
            temporizador.AñadirTiempo(10f);
        }

        if (esIncorrecta)
        {
            temporizador.QuitarTiempo(5f);
        }
    }

    public void BotellaProcesada()
    {
        botellasObjetivo--;

        if (botellasObjetivo > 0)
        {
            ActualizarTexto();
        }
        else
        {
            textoObjetivo.text = "¡Puntaje activado!";
        }
    }
}
