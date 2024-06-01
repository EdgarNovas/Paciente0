using UnityEngine;
using TMPro;

public class TextScroll : MonoBehaviour
{
    public TextMeshProUGUI text;  // Referencia al componente TextMeshProUGUI
    public float speed = 50f;     // Velocidad de desplazamiento del texto
    public float resetPositionY = -100f;  // Posición Y donde el texto se reposiciona al volver a aparecer por debajo
    public float startPositionY = 1000f;  // Posición Y inicial del texto

    private RectTransform rectTransform;

    void Start()
    {
        if (text == null)
        {
            Debug.LogError("TextMeshProUGUI no asignado en el inspector.");
            return;
        }

        rectTransform = text.GetComponent<RectTransform>();

        if (rectTransform == null)
        {
            Debug.LogError("No se encontró RectTransform en el TextMeshProUGUI.");
        }
    }

    void Update()
    {
        if (rectTransform != null)
        {
            // Mover el texto hacia arriba
            rectTransform.anchoredPosition += Vector2.up * speed * Time.deltaTime;

            // Si el texto supera cierta posición en Y, resetear a la posición inicial
            if (rectTransform.anchoredPosition.y >= startPositionY)
            {
                rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, resetPositionY);
            }
        }
    }
}