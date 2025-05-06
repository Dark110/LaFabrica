using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuSystem : MonoBehaviour
{

  
    public TextMeshProUGUI textoPuntajeFinal; // Campo para mostrar el puntaje final

        void Start()
        {
            if (textoPuntajeFinal != null)
            {
                textoPuntajeFinal.text = "Puntaje Personal: " + GameData.puntajeFinal;
            }
        }
    
    public void Jugar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);

    }
   
    public void controles ()
    {
        SceneManager.LoadScene("Controles");
    }


    public void Volver()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Salir()
    {
       Application.Quit();
        Debug.Log("Saliendo del juego");
    }
}