using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int vidas = 3;
    public  Text texto;
    private static GameManager audioListenerInstance;


    void Awake()
    {

        // Si ya existe una instancia del GameManager, destruye este objeto duplicado
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Este objeto no ser� destruido al cargar nuevas escenas
        }

        // Verificar si ya hay un AudioListener activo
        if (audioListenerInstance == null)
        {
            // Si no hay un AudioListener Singleton, lo creamos
            audioListenerInstance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            // Si ya existe un AudioListener Singleton, destruye el duplicado
            Destroy(gameObject);
        }

        vidas = 3;
    }

    public void ReduceVidas()
    {
        vidas--; // Primero reducimos las vidas
        if (texto != null)
        {
            texto.text = "X" + vidas; // Luego actualizamos el texto mostrando el número de vidas restantes
        }
        else
        {
            Debug.LogError("No se ha asignado el campo de texto de vidas.");
        }
    
        if (vidas <= 0)
        {
            // Si no hay vidas, ir a la pantalla de Game Over
            SceneManager.LoadScene("GameOver");
    }
}

}