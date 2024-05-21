using UnityEngine;

public class GrowImage : MonoBehaviour
{
    private SpriteRenderer targetSprite;
    public Vector3 normalScale = new Vector3(1, 1, 1);
    public Vector3 maxScale = new Vector3(1.25f, 1.25f, 1.25f);
    public float cycleDuration = 1.0f;

    private float timer;

    void Start()
    {
        // Obtener el componente SpriteRenderer
        targetSprite = GetComponent<SpriteRenderer>();

        // Verificar si el componente SpriteRenderer está presente
        if (targetSprite == null)
        {
            Debug.LogError("No se encontró SpriteRenderer en el GameObject.");
            return;
        }

        // Establecer la escala inicial
        targetSprite.transform.localScale = normalScale;
        timer = 0.0f;
    }

    void Update()
    {
        // Actualizar el temporizador
        timer += Time.deltaTime;

        // Calcular el progreso del ciclo
        float cycleProgress = Mathf.PingPong(timer, cycleDuration) / cycleDuration;

        // Interpolar entre las escalas normal y máxima
        targetSprite.transform.localScale = Vector3.Lerp(normalScale, maxScale, cycleProgress);
    }
}