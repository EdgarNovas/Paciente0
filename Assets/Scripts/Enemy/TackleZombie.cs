using UnityEngine;

public class PushObjectTowardsPlayer : MonoBehaviour
{
    public Transform player; // Referencia al transform del jugador
    public float pushForce = 5f; // Fuerza de empuje hacia el jugador
    public float cooldown = 1f; // Tiempo de enfriamiento entre empujes

    private Rigidbody2D rb; // Referencia al Rigidbody2D del objeto que queremos empujar
    private bool canPush = true; // Variable para controlar el cooldown

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Obtener el Rigidbody2D del objeto
    }

    void Update()
    {
        if (player != null && canPush)
        {
            // Calcular la distancia hacia el jugador
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);

            // Si la distancia es menor que cierto valor, activar el empuje
            if (distanceToPlayer < 5f)
            {
                // Calcular la dirección hacia el jugador
                Vector2 direction = player.position - transform.position;
                direction.Normalize();

                // Aplicar fuerza hacia el jugador
                rb.AddForce(direction * pushForce * Time.deltaTime);

                // Activar el cooldown
                canPush = false;
                Invoke("ResetCooldown", cooldown);
            }
        }
    }

    // Método para restablecer el cooldown
    void ResetCooldown()
    {
        canPush = true;
    }
}