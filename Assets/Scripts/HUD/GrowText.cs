using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GrowText : MonoBehaviour
{
    private TextMeshProUGUI targetText;
    public Vector3 normalScale = new Vector3(1, 1, 1);
    public Vector3 maxScale = new Vector3(1.25f, 1.25f, 1.25f);
    public float cycleDuration = 1.0f;

    private float timer;

    void Start()
    {
        if (targetText == null)
        {
            targetText = GetComponent<TextMeshProUGUI>();
        }

        targetText.transform.localScale = normalScale;
        timer = 0.0f;
    }

    void Update()
    {
        timer += Time.deltaTime;
        float cycleProgress = Mathf.PingPong(timer, cycleDuration) / cycleDuration;
        targetText.transform.localScale = Vector3.Lerp(normalScale, maxScale, cycleProgress);
    }
}





