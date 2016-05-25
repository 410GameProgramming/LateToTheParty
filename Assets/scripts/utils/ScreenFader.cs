using UnityEngine;
using System.Collections;

public class ScreenFader : MonoBehaviour {

    public Texture2D fadeOutTexture;
    public float fadeSpeed = 0.2f;
    private int drawDepth = -1000;
    private float alpha = 1.0f;
    private int fadeDir = -1;

    void OnGUI(){
        alpha += fadeDir * fadeSpeed * Time.deltaTime;
        alpha = Mathf.Clamp01(alpha);
        GUI.color = new Color(GUI.color.r, GUI.color.b, GUI.color.b, alpha);
        GUI.depth = drawDepth;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);
    }

    public float beginFade(int direction)
    {
        fadeDir = direction;
        return (fadeSpeed);
    }

    void OnLevelWasLoaded()
    {
         StartCoroutine(fadeOut());
    }

    IEnumerator fadeOut()
    {
        float fadeTime = beginFade(-1);
        yield return new WaitForSeconds(fadeTime);
    }



}
