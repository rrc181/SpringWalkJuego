using UnityEngine;
using UnityEngine.SceneManagement; // Asegúrate de importar este espacio de nombres

public class Inicio : MonoBehaviour
{
    void Update()
    {
        // Detectar cuando se presiona la tecla de espacio
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Cargar la siguiente escena
            LoadNextScene();
        }
    }

    void LoadNextScene()
    {
        // Obtener el índice de la escena actual
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Cargar la siguiente escena en la lista
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
