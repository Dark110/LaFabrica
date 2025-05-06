namespace Game.UI
{
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
            botellasObjetivo = Random.Range(3, 11); // Genera un número aleatorio de botellas objetivo
            ActualizarTexto();
        }

        void ActualizarTexto()
        {
            if (textoObjetivo != null)
            {
                textoObjetivo.text = "Procesa " + botellasObjetivo + " botellas para comenzar a puntuar.";
            }
        }

        void ProcesarBotella(GameObject botella)
        {
            bool esCorrecta = botella.CompareTag("BotellaBuena");
            bool esIncorrecta = botella.CompareTag("BotellaMala");

            if (objetivoCompletado && esCorrecta)
            {
                puntaje += 10; // Suma 10 puntos por botella correcta
                temporizador.AñadirTiempo(10f); // Añade tiempo al temporizador
            }

            if (esIncorrecta)
            {
                temporizador.QuitarTiempo(5f); // Resta tiempo si la botella es incorrecta
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


}
