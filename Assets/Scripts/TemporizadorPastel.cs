using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Necesario para cambiar de escena

public class TemporizadorPastel : MonoBehaviour
{
    public Image imagenPastel;
    public float tiempoMaximo = 40f;
    private float tiempoActual;

    public bool timerActivo = true;
    public string nombreEscenaMenu = "Menu"; // Nombre de la escena del men�

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
            Debug.Log("�Tiempo agotado!");
            RegresarAlMenu(); // Llama al m�todo para regresar al men�
        }
    }

    public void A�adirTiempo(float segundos)
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
        // Aseg�rate de que el tiempo est� en escala normal
        Time.timeScale = 1f;

        // Det�n el temporizador
        timerActivo = false;

        // Desbloquea y muestra el cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // Carga la escena del men�
        SceneManager.LoadScene(nombreEscenaMenu);
    }

}
