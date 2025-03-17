using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para cambiar de escena

public class SceneChanger : MonoBehaviour
{
    public string SampleScene; // Nombre de la escena a la que queremos cambiar

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Detecta si se presiona la barra espaciadora
        {
            CambioEscena();
        }
    }

    void CambioEscena()
    {
        if (!string.IsNullOrEmpty(SampleScene)) // Verifica que haya un nombre de escena asignado
        {
            SceneManager.LoadScene(SampleScene);
        }
        else
        {
            Debug.LogError("No se ha asignado un nombre de escena en el Inspector.");
        }
    }
}
