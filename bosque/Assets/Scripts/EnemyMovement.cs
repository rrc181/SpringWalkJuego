using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform puntoA;
    public Transform puntoB;
    public float velocidad = 2f;

    public AudioSource audioSource;
    public AudioClip audioclip;

    private Vector3 destino;

    void Start()
    {
        destino = puntoB.position;
    }

    void Update()
    {
        // Mover hacia el destino
        transform.position = Vector3.MoveTowards(transform.position, destino, velocidad * Time.deltaTime);

        // Si llega al destino, cambia de dirección
        if (Vector3.Distance(transform.position, destino) < 0.1f)
        {
            destino = (destino == puntoA.position) ? puntoB.position : puntoA.position;
            Flip(); // Voltear al llegar al destino
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica si el enemigo colisiona con el jugador desde arriba
        if (collision.gameObject.CompareTag("Player") && collision.contacts[0].normal.y > 0)
        {
            // El jugador pisa al enemigo, destruir el enemigo
            audioSource.PlayOneShot(audioclip);
            Destroy(gameObject);

        }

        // Verifica si el enemigo colisiona con otro enemigo
        if (collision.gameObject.CompareTag("Enemies"))
        {
            Flip(); // Voltear el enemigo al colisionar con otro
            destino = (destino == puntoA.position) ? puntoB.position : puntoA.position; // Cambiar de destino
        }
    }

    void Flip()
    {
        // Cambiar la dirección en el eje X
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }
}
