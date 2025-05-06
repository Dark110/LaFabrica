using TMPro;
using UnityEngine;

public class UIObjetivoBotellas : MonoBehaviour
{
    public int botellasObjetivo = 0;
    public TextMeshProUGUI textoObjetivo;
    public TemporizadorPastel temporizador;

    private int puntaje = 0; // Variable para almacenar el puntaje acumulado

    public bool objetivoCompletado => botellasObjetivo <= 0;

    void Start()
    {
        botellasObjetivo = Random.Range(3, 11);
        ActualizarTexto();
    }

    void ActualizarTexto()
    {
        textoObjetivo.text = "Puntaje: " + puntaje; // Muestra el puntaje en tiempo real
    }

    void ProcesarBotella(GameObject botella)
    {
        bool esCorrecta = botella.CompareTag("BotellaBuena");
        bool esIncorrecta = botella.CompareTag("BotellaMala");

        if (objetivoCompletado && esCorrecta)
        {
            puntaje += 10; // Suma 10 puntos por botella correcta
            temporizador.AñadirTiempo(10f);
            ActualizarTexto(); // Actualiza el texto con el nuevo puntaje
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

