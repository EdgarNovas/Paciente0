using UnityEngine;

public class MoveTileSet : MonoBehaviour
{
    public float speed = 5f; // Velocidad de movimiento del tile

    public float screenWidth;

    void Start()
    {

    }

    void Update()
    {
        // Mover el objeto hacia la derecha
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        // Si el tile se sale de la pantalla, reposicionarlo al lado izquierdo
        if (transform.position.x >= screenWidth)
        {
            RepositionTile();
        }
    }

    void RepositionTile()
    {
        // Reposiciona el tile al lado izquierdo
        transform.position = new Vector2(-screenWidth, transform.position.y);
    }
}

