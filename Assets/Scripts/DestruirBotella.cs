using UnityEngine;

public class DestruirBotella : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Botella"))
        {
            // Notificar al script de interacción que la botella será destruida
            InteractuarConObjeto interactor = FindObjectOfType<InteractuarConObjeto>();
            if (interactor != null)
            {
                interactor.ForzarSoltarSiEs(other.gameObject);
            }

            Destroy(other.gameObject);
        }
    }

}
