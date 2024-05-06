/*****************************************************************************
// File Name : ShoeCleaner.cs
// Author : Mark Gyure
// Creation Date : 4/14/2024
//
// Brief Description : handles cleaning shoes and calculating score for the player in all 3 levels
*****************************************************************************/
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
public class ShoeCleaner : MonoBehaviour
{
    [SerializeField] private Texture2D dirtyTexture;
    [SerializeField] private Texture2D cleanTexture;
    [SerializeField] private Texture2D soapTexture;
    [SerializeField] private Renderer shoeRenderer;
    [SerializeField] private int brushSize = 20;
    private Color[] originalColors;
    [SerializeField] private TimerCountdown timerCountdown;
    [SerializeField] private ItemSwitch itemSwitch;
    [SerializeField] private int cleanedPixelCount = 0;
    [SerializeField] private int RequiredCleanedPixels = 250000;
    [SerializeField] private TMP_Text playerScore;
    [SerializeField] private ScoreData scoreData;
    private InputAction mouseClickAction;
    private InputAction mouseDragAction;
    private bool isDragging = false;
    private int mappedScore;
    /// <summary>
    /// getter for CleanedPixelCount
    /// </summary>
    public int CleanedPixelCount
    {
        get { return cleanedPixelCount; }
    }
    /// <summary>
    /// getter for MappedScore
    /// </summary>
    public int MappedScore
    {
        get { return mappedScore; }
    }
    /// <summary>
    /// enables mouse click and drag action
    /// </summary>
    void OnEnable()
    {
        mouseClickAction.Enable();
        mouseDragAction.Enable();
    }
    /// <summary>
    /// disables click and drag action. also resets the shoes texture so its not permanently effected.
    /// </summary>
    void OnDisable()
    {
        mouseClickAction.Disable();
        mouseDragAction.Disable();
        ResetShoe();
    }
    /// <summary>
    ///Creates the mouse click action and drag action instead of doing in an input actions class. adds listeners for 
    ///starting and canceling dragging and clicking.
    /// </summary>
    void Awake()
    {
        mouseClickAction = new InputAction(binding: "<Mouse>/leftButton");
        mouseDragAction = new InputAction(binding: "<Mouse>/leftButton");
        mouseClickAction.started += ctx => OnMouseClick();
        mouseDragAction.started += ctx => OnMouseDrag();
        mouseDragAction.canceled += ctx => OnMouseDragEnd();
    }
    /// <summary>
    /// Before the first framem it stores the original pixels of the dirty texture so it doesnt get permanently ruined
    /// </summary>
    void Start()
    {
        originalColors = dirtyTexture.GetPixels();
    }
    /// <summary>
    /// every frame it checks for the mouse's location and checks if the player is dragging the mouse. If they are, 
    /// it will apply the correlating texture based on the tool that is selected
    /// </summary>
    void Update() 
    {
        if (isDragging && !timerCountdown.timesUp1 && !timerCountdown.allDone1)
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
    /// when mouse is clicked, sets dragging to true
    /// </summary>
    void OnMouseClick()
    {
        isDragging = true;
    }
    /// <summary>
    /// when mouse is dragged, also sets dragging to true
    /// </summary>
    void OnMouseDrag()
    {
        isDragging = true;
    }
    /// <summary>
    /// when its done dragging, it updates the player score according to the pixels changed and sets isDragging to 
    /// false.
    /// </summary>
    void OnMouseDragEnd()
    {
        isDragging = false;
        UpdateScore(); 
    }
    /// <summary>
    /// applies soap texture within the x and y brush radius at the same location of the dirty texture.
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
                if (i * i + j * j <= brushRadius * brushRadius) // Check if within circular brush area
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
    /// finds coords of both textures and applies new one and calculates how many pixels are effected. Then converts 
    /// huge number into a score of 1-20 to be saved as the players score.
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
                if (i * i + j * j <= brushRadius * brushRadius) // Check if within circular brush area again
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
                            cleanedPixelCount++;
                        }
                    }
                }
            }
        }
        dirtyTexture.Apply();
        shoeRenderer.material.mainTexture = dirtyTexture;
        // Calculate the new mapped score
        int newMappedScore = MapScore(cleanedPixelCount);
        // Check if the new score is different from the current score
        if (newMappedScore != mappedScore)
        {
            mappedScore = newMappedScore;
            // Update the player's score in the scoreData ScriptableObject
            scoreData.AddPlayerScore("player");
            playerScore.text = "You: " + scoreData.GetPlayerScore("player").ToString();
        }
        if (cleanedPixelCount >= RequiredCleanedPixels)
        {
            Debug.Log("Win Condition Met!");
        }
    }
    /// <summary>
    /// updates score according the cleanedPixelCount
    /// </summary>
    private void UpdateScore()
    {
        // Calculate the new mapped score
        int newMappedScore = MapScore(cleanedPixelCount);
        // Check if the new score is different from the current score
        if (newMappedScore != mappedScore)
        {
            mappedScore = newMappedScore;
            // Update the player's score in the scoreData ScriptableObject
            scoreData.AddPlayerScore("player");
            playerScore.text = "You: " + scoreData.GetPlayerScore("player").ToString();
        }
        if (cleanedPixelCount >= RequiredCleanedPixels)
        {
            Debug.Log("Win Condition Met!");
        }
    }
    /// <summary>
    /// has the startinf changed pixels, and max, along with the min score and the max. calculates the current
    /// "cleaned" pixels and converts that huge number into a more managable 1-20
    /// </summary>
    /// <param name="pixelCount"></param>
    /// <returns></returns>
    private int MapScore(int pixelCount)
    {
        float minOriginal = 0;
        float maxOriginal = 550000;
        int minTarget = 1;
        int maxTarget = 20;
        // Calculate the mapped score
        float mappedScore = minTarget + (maxTarget - minTarget) * ((pixelCount - minOriginal) / (maxOriginal - 
            minOriginal));
        // Round the mapped score to the nearest integer
        int roundedScore = Mathf.RoundToInt(mappedScore);
        // Ensure the score is within the target range
        return Mathf.Clamp(roundedScore, minTarget, maxTarget);
    }
    /// <summary>
    /// sets the dirty texture back to the original texture so its not ruined after cleaning.
    /// </summary>
    public void ResetShoe()
    {
        cleanedPixelCount = 0;
        dirtyTexture.SetPixels(originalColors);
        dirtyTexture.Apply();
        shoeRenderer.material.mainTexture = dirtyTexture;
    }
}
