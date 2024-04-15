/*****************************************************************************
// File Name : TutorialShoeCleaner 
// Author : Mark Gyure
// Creation Date : 4/14/2024
//
// Brief Description : handles how the shoes are cleaned for the tutorial only because its different.
*****************************************************************************/
using UnityEngine;

public class TutorialShoeCleaner : MonoBehaviour
{
    [SerializeField] private Texture2D dirtyTexture;
    [SerializeField] private Texture2D cleanTexture;
    [SerializeField] private Texture2D soapTexture;
    [SerializeField] private Renderer shoeRenderer;
    [SerializeField] private int brushSize = 20;
    [SerializeField] private float brushStrength = 1.0f;
    private Color[] originalColors;
    [SerializeField] private TutorialItemSwitch itemSwitch;
    /// <summary>
    /// Sets originalColors to an array of pixels that is on the dirtyTexture Texture
    /// </summary>
    void Start()
    {
        originalColors = dirtyTexture.GetPixels();
    }
    /// <summary>
    /// when left click is held it casts a ray from the camera to the position of the mouse and if it hits the collider
    /// of the specified gameobject, it will find the coords of the texture that it hit and go to the same coords of
    /// the clean texture and apply them in place of that spot depending on which brush is being used
    /// </summary>
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
            {
                Vector2 pixelUV = hit.textureCoord;
                pixelUV.x *= dirtyTexture.width;
                pixelUV.y *= dirtyTexture.height;

                if (itemSwitch.SoapActive)
                {
                    ApplySoapBrush((int)pixelUV.x, (int)pixelUV.y);
                }
                else if (itemSwitch.SpongeActive)
                {
                    ApplySpongeBrush((int)pixelUV.x, (int)pixelUV.y);
                }
            }
        }
    }
    /// <summary>
    /// applies the entire soap texture at location of mouse pos and brush size
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    void ApplySoapBrush(int x, int y)
    {
        int brushRadius = brushSize / 2;

        for (int i = -brushRadius; i <= brushRadius; i++)
        {
            for (int j = -brushRadius; j <= brushRadius; j++)
            {
                if (i * i + j * j <= brushRadius * brushRadius)
                {
                    int texX = x + i;
                    int texY = y + j;

                    if (texX >= 0 && texX < dirtyTexture.width && texY >= 0 && texY < dirtyTexture.height)
                    {
                        Color soapColor = soapTexture.GetPixel(texX, texY);
                        dirtyTexture.SetPixel(texX, texY, soapColor);
                    }
                }
            }
        }
        dirtyTexture.Apply();
        shoeRenderer.material.mainTexture = dirtyTexture;
    }
    /// <summary>
    /// finds coords of both textures and applies new one and calculates how many pixels are effected.
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    void ApplySpongeBrush(int x, int y)
    {
        int brushRadius = brushSize / 2;

        for (int i = -brushRadius; i <= brushRadius; i++)
        {
            for (int j = -brushRadius; j <= brushRadius; j++)
            {
                if (i * i + j * j <= brushRadius * brushRadius)
                {
                    int texX = x + i;
                    int texY = y + j;

                    if (texX >= 0 && texX < dirtyTexture.width && texY >= 0 && texY < dirtyTexture.height)
                    {
                        Color currentColor = dirtyTexture.GetPixel(texX, texY);
                        Color soapColor = soapTexture.GetPixel(texX, texY);
                        if (currentColor == soapColor)
                        {
                            // Calculate the distance from the center of the brush
                            float distanceFromCenter = Mathf.Sqrt(i * i + j * j);
                            // Calculate the normalized distance (0 at the center, 1 at the edge)
                            float normalizedDistance = distanceFromCenter / (float)brushRadius;
                            // Interpolate alpha value (1 at the center, 0 at the edge)
                            float alpha = 1.0f - Mathf.Clamp01(normalizedDistance);
                            // Modify the alpha channel of the clean color
                            Color cleanColor = cleanTexture.GetPixel(texX, texY);
                            cleanColor.a *= alpha;
                            dirtyTexture.SetPixel(texX, texY, cleanColor);
                        }
                    }
                }
            }
        }
        dirtyTexture.Apply();
        shoeRenderer.material.mainTexture = dirtyTexture;
    }
    /// <summary>
    /// takes the saved original colros and sets the dirty texture equal to those so it doesnt ruin the texture forever
    /// </summary>
    public void ResetShoe()
    {
        dirtyTexture.SetPixels(originalColors);
        dirtyTexture.Apply();
        shoeRenderer.material.mainTexture = dirtyTexture;
    }
    /// <summary>
    /// resets shoe texture when scene is left
    /// </summary>
    private void OnDisable()
    {
        ResetShoe();
    }
}


