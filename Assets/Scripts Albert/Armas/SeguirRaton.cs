using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguirRaton : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Camera cam;

    Vector2 mousePos;
    public Texture2D cursorTexture; // Asigna la textura del cursor en el inspector

    public float cursorScale = 40.5f;

    private void Start()
    {
        cam = Camera.main;

        
        Cursor.SetCursor(cursorTexture, mousePos, CursorMode.Auto);

    }
    // Update is called once per frame
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        
    }

    void FixedUpdate()
    {
        //Vector2 lookDir = mousePos - rb.position;
        Vector2 lookDir = mousePos - (Vector2)transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        //rb.rotation = angle;
        transform.rotation = new Quaternion();
        transform.Rotate(new Vector3(0, 0, angle), Space.Self);
        if (lookDir.y >=0)
        {
            
        }
    }

    // Método para escalar una textura
    private Texture2D ScaleTexture(Texture2D texture, int newWidth, int newHeight)
    {
        // Creamos una nueva textura con las dimensiones escaladas
        Texture2D scaledTexture = new Texture2D(newWidth, newHeight);
        // Escalamos los píxeles de la textura original a la nueva textura
        for (int x = 0; x < newWidth; x++)
        {
            for (int y = 0; y < newHeight; y++)
            {
                // Calculamos las coordenadas de la textura original correspondientes a la nueva textura
                float u = x * 1.0f / newWidth;
                float v = y * 1.0f / newHeight;
                // Mapeamos las coordenadas de la textura original
                int sampleX = Mathf.FloorToInt(u * texture.width);
                int sampleY = Mathf.FloorToInt(v * texture.height);
                // Obtenemos el color de la textura original y lo asignamos a la nueva textura
                Color color = texture.GetPixel(sampleX, sampleY);
                scaledTexture.SetPixel(x, y, color);
            }
        }
        // Aplicamos los cambios a la nueva textura
        scaledTexture.Apply();
        return scaledTexture;
    }
}
