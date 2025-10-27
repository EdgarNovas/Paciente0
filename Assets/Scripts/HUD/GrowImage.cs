using UnityEngine;
using UnityEngine.UI;

public class GrowImage : MonoBehaviour
{
    private SpriteRenderer targetSprite;
    private Image targetImage;
    public Vector3 normalScale = new Vector3(1, 1, 1);
    public Vector3 maxScale = new Vector3(1.25f, 1.25f, 1.25f);
    public float cycleDuration = 1.0f;
    public bool image;

    private float timer;

    void Start()
    {
        if (image)
        {
            targetImage = GetComponent<Image>();
            targetImage.transform.localScale = normalScale;
            timer = 0.0f;
        }

        else
        { 
        targetSprite = GetComponent<SpriteRenderer>();
        targetSprite.transform.localScale = normalScale;
        timer = 0.0f;
        }
    }

    void Update()
    {
        if(!image)
        { 
        timer += Time.deltaTime;
        float cycleProgress = Mathf.PingPong(timer, cycleDuration) / cycleDuration;
        targetSprite.transform.localScale = Vector3.Lerp(normalScale, maxScale, cycleProgress);
        }
    }

    public void OneLoop()
    {
        if (timer < cycleDuration*2)
        {
            timer += Time.deltaTime;
            float cycleProgress = Mathf.PingPong(timer, cycleDuration) / cycleDuration;
            targetImage.transform.localScale = Vector3.Lerp(normalScale, maxScale, cycleProgress);
        }
    }
}