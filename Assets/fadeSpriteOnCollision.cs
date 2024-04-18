using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fadeSpriteOnCollision : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private bool fadingOut = false;
    private float fadeDuration = 2.0f;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter(Collider collision) // 3D Trigger
    {

        fadingOut = true;
        StartCoroutine(FadeOut());

    }

    void OnTriggerExit(Collider collision) // 3D Trigger
    {

        fadingOut = false;
        StartCoroutine(FadeIn());

    }


    IEnumerator FadeOut()
    {
        float startTime = Time.time;
        float startAlpha = spriteRenderer.color.a;

        while (spriteRenderer.color.a > 0)
        {
            float elapsedTime = Time.time - startTime;
            float alpha = Mathf.Lerp(startAlpha, 0, elapsedTime / fadeDuration);
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, alpha);
            yield return null;
        }
    }

    IEnumerator FadeIn()
    {
        float startTime = Time.time;
        float startAlpha = spriteRenderer.color.a;

        while (spriteRenderer.color.a < 1)
        {
            float elapsedTime = Time.time - startTime;
            float alpha = Mathf.Lerp(startAlpha, 1, elapsedTime / fadeDuration);
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, alpha);
            yield return null;
        }
    }
}
