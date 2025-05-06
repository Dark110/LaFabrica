using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Necesario para cambiar de escena

public class TemporizadorPastel : MonoBehaviour
{
    public Image imagenPastel;
    public float tiempoMaximo = 40f;
    private float tiempoActual;

    public bool timerActivo = true;
    public string nombreEscenaMenu = "Menu"; // Nombre de la escena del menú

    void Start()
    {
        tiempoActual = tiempoMaximo;
    }

    void Update()
    {
        if (!timerActivo) return;

        tiempoActual -= Time.deltaTime;
        tiempoActual = Mathf.Clamp(tiempoActual, 0, tiempoMaximo);

        if (imagenPastel != null)
            imagenPastel.fillAmount = tiempoActual / tiempoMaximo;

        if (tiempoActual <= 0)
        {
            timerActivo = false;
            Debug.Log("¡Tiempo agotado!");
            RegresarAlMenu(); // Llama al método para regresar al menú
        }
    }

    public void AñadirTiempo(float segundos)
    {
        tiempoActual += segundos;
        tiempoActual = Mathf.Min(tiempoActual, tiempoMaximo);
    }

    public void QuitarTiempo(float segundos)
    {
        tiempoActual -= segundos;
        tiempoActual = Mathf.Max(0, tiempoActual);
    }

    private void RegresarAlMenu()
    {
        // Asegúrate de que el tiempo esté en escala normal
        Time.timeScale = 1f;

        // Detén el temporizador
        timerActivo = false;

        // Desbloquea y muestra el cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // Carga la escena del menú
        SceneManager.LoadScene(nombreEscenaMenu);
    }

}
