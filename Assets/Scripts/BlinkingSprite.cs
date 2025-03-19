using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BlinkingGameObject : MonoBehaviour
{
    [SerializeField] private GameObject emergencyObject;
    [SerializeField] private float blinkInterval;
    private Image imageRenderer;

    private void Start()
    {
        imageRenderer = emergencyObject.GetComponent<Image>();

        if (imageRenderer.name == "DangerIcon")
        {
            blinkInterval -= 0.2f;
        }

        if (imageRenderer != null)
            StartCoroutine(BlinkCoroutine());
    }

    private IEnumerator BlinkCoroutine()
    {
        while (true)
        {
            imageRenderer.enabled = !imageRenderer.enabled;

            yield return new WaitForSeconds(blinkInterval);
        }
    }
}
