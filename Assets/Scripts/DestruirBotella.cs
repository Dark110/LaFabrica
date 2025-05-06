using UnityEngine;

public class DestruirBotella : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Botella"))
        {
            // Notificar al script de interacci�n que la botella ser� destruida
            InteractuarConObjeto interactor = FindObjectOfType<InteractuarConObjeto>();
            if (interactor != null)
            {
                interactor.ForzarSoltarSiEs(other.gameObject);
            }

            Destroy(other.gameObject);
        }
    }

}
