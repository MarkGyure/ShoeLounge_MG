/*****************************************************************************
// File Name : TutorialShoeCleaner.cs
// Author : Mark Gyure
// Creation Date : 4/14/2024
//
// Brief Description : handles how the shoes are cleaned for the tutorial only because its different.
*****************************************************************************/
using UnityEngine;
using UnityEngine.InputSystem;
public class TutorialShoeCleaner : MonoBehaviour
{
    [SerializeField] private Texture2D dirtyTexture;
    [SerializeField] private Texture2D cleanTexture;
    [SerializeField] private Texture2D soapTexture;
    [SerializeField] private Renderer shoeRenderer;
    [SerializeField] private int brushSize = 20;
    private Color[] originalColors;
    [SerializeField] private TutorialItemSwitch itemSwitch;
    private InputAction mouseClickAction;
    private bool isCleaning = false;
    /// <summary>
    /// enables the mouse click action
    /// </summary>
    void OnEnable()
    {
        mouseClickAction.Enable();
    }
    /// <summary>
    /// disables the mouse click action and resets the shoe texture
    /// </summary>
    void OnDisable()
    {
        mouseClickAction.Disable();
        ResetShoe(); 
    }
    /// <summary>
    /// creates the mouse click action and adds listeners for starting and canceling
    /// </summary>
    void Awake()
    {
        mouseClickAction = new InputAction(binding: "<Mouse>/leftButton");
        mouseClickAction.started += ctx => StartCleaning();
        mouseClickAction.canceled += ctx => EndCleaning();
    }
    /// <summary>
    /// before the first frame sets the original colors to the current dirty texture and saves it for later
    /// </summary>
    void Start()
    {
        originalColors = dirtyTexture.GetPixels();
    }
    /// <summary>
    /// during every frame if the player is cleaning it will cast a ray at the mouse and check if its colliding with
    /// the game object that the script is attached to and get the pixels that the ray is hitting. those pixels are
    /// sent to apply soap brush and sponge brush to do their jobs.
    /// </summary>
    void Update()
    {
        if (isCleaning)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
            {
                Vector2 pixelUV = hit.textureCoord;
                pixelUV.x *= dirtyTexture.width;
                pixelUV.y *= dirtyTexture.height;

                if (itemSwitch.SoapActive)
                {
                    ApplySoapBrush();
                }
                else if (itemSwitch.SpongeActive)
                {
                    ApplySpongeBrush();
                }
            }
        }
    }
    /// <summary>
    /// sets isCleaning to true;
    /// </summary>
    void StartCleaning()
    {
        isCleaning = true;
    }
    /// <summary>
    /// sets isCleaning to false;
    /// </summary>
    void EndCleaning()
    {
        isCleaning = false;
    }
    /// <summary>
    /// applies the soap brush to the mouse location coords on both textures
    /// </summary>
    void ApplySoapBrush()
    {
        Vector2 mousePosition = Mouse.current.position.ReadValue();
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
        {
            Vector2 pixelUV = hit.textureCoord;
            pixelUV.x *= dirtyTexture.width;
            pixelUV.y *= dirtyTexture.height;

            int brushRadius = brushSize / 2;

            for (int i = -brushRadius; i <= brushRadius; i++)
            {
                for (int j = -brushRadius; j <= brushRadius; j++)
                {
                    if (i * i + j * j <= brushRadius * brushRadius)
                    {
                        int texX = (int)pixelUV.x + i;
                        int texY = (int)pixelUV.y + j;

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
    }
    /// <summary>
    /// applies the clean texture on the soap texture based on mouse pos
    /// </summary>
    void ApplySpongeBrush()
    {
        Vector2 mousePosition = Mouse.current.position.ReadValue();
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);

        if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
        {
            Vector2 pixelUV = hit.textureCoord;
            pixelUV.x *= dirtyTexture.width;
            pixelUV.y *= dirtyTexture.height;

            int brushRadius = brushSize / 2;

            for (int i = -brushRadius; i <= brushRadius; i++)
            {
                for (int j = -brushRadius; j <= brushRadius; j++)
                {
                    if (i * i + j * j <= brushRadius * brushRadius)
                    {
                        int texX = (int)pixelUV.x + i;
                        int texY = (int)pixelUV.y + j;

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
    }
    /// <summary>
    /// sets the effected texture to the original texture that was saved at the start
    /// </summary>
    public void ResetShoe()
    {
        dirtyTexture.SetPixels(originalColors);
        dirtyTexture.Apply();
        shoeRenderer.material.mainTexture = dirtyTexture;
    }
}
