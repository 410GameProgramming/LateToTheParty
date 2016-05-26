using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenFader : MonoBehaviour
{
    public float fadeTime;
    public Color fadeColor = new Color(0.0f, 0.0f, 0.0f, 1.0f);
    public Material fadeMaterial = null;
    
    private bool faded = false;
    private List<ScreenFadeControl> fadeControls = new List<ScreenFadeControl>();

    void SetFadersEnabled(bool value)
    {
        foreach (ScreenFadeControl fadeControl in fadeControls)
            fadeControl.enabled = value;         
    }

    void Start()
    {
        initFade();
        SetFadersEnabled(true);
        fadeMaterial.color = fadeColor;
        faded = true;
        StartCoroutine(FadeIn());
    }

    public IEnumerator FadeOut()
    {
        if (!faded)
        {
            // Derived from OVRScreenFade
            float elapsedTime = 0.0f;
            Color color = fadeColor;
            color.a = 0.0f;
            fadeMaterial.color = color;
            while (elapsedTime < fadeTime)
            {
                yield return new WaitForEndOfFrame();
                elapsedTime += Time.deltaTime;
                color.a = Mathf.Clamp01(elapsedTime / fadeTime);
                fadeMaterial.color = color;
            }
        }
        faded = true;
    }

    public IEnumerator FadeIn()
    {
        if (faded)
        {
            float elapsedTime = 0.0f;
            Color color = fadeMaterial.color = fadeColor;
            
                while (elapsedTime < fadeTime)
            {
                yield return new WaitForEndOfFrame();
                elapsedTime += Time.deltaTime;
                color.a = 1.0f - Mathf.Clamp01(elapsedTime / fadeTime);
                fadeMaterial.color = color;
            }
        }
        faded = false;
        //SetFadersEnabled(false);
    }
    private void initFade()
    {
        // Clean up from last fade
        foreach (ScreenFadeControl fadeControl in fadeControls)
        {
            Destroy(fadeControl);
        }
        fadeControls.Clear();

        // Find all cameras and add fade material to them (initially disabled)
        foreach (Camera c in Camera.allCameras)
        {
            var fadeControl = c.gameObject.AddComponent<ScreenFadeControl>();
            fadeControl.fadeMaterial = fadeMaterial;
            fadeControls.Add(fadeControl);
        }

    }
}
