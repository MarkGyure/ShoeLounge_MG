/*****************************************************************************
// File Name : ShoeCleaner.cs
// Author : Mark Gyure
// Creation Date : 4/14/2024
//
// Brief Description : handles cleaning shoes and calculating score for the player in all 3 levels
*****************************************************************************/
using TMPro;
using UnityEngine;
public class ShoeCleaner : MonoBehaviour
{
    [SerializeField] private Texture2D dirtyTexture;
    [SerializeField] private Texture2D cleanTexture;
    [SerializeField] private Texture2D soapTexture;
    [SerializeField] private Renderer shoeRenderer;
    [SerializeField] private int brushSize = 20;
    [SerializeField] private float brushStrength = 1.0f; 
    private Color[] originalColors; 
    [SerializeField] private TimerCountdown timerCountdown;
    [SerializeField] private ItemSwitch itemSwitch;
    [SerializeField] private int cleanedPixelCount = 0;
    public int CleanedPixelCount
    {
        get { return cleanedPixelCount; }
    }
    [SerializeField] private int RequiredCleanedPixels = 250000; 
    private int mappedScore;
    /// <summary>
    /// get method for the mappedScore
    /// </summary>
    public int MappedScore
    {
        get { return mappedScore; }
    }
    [SerializeField] private TMP_Text playerScore;
    [SerializeField] private ScoreData scoreData;
    /// <summary>
    /// Sets originalColors to an array of pixels that is on the dirtyTexture Texture
    /// </summary>
    void Start()
    {
        // Store the original colors of the dirty texture
        originalColors = dirtyTexture.GetPixels();
    }
    /// <summary>
    /// when left click is held it casts a ray from the camera to the position of the mouse and if it hits the collider
    /// of the specified gameobject, it will find the coords of the texture that it hit and go to the same coords of
    /// the clean texture and apply them in place of that spot depending on which brush is being used
    /// </summary>
    void Update()
    {
        if (Input.GetMouseButton(0) && timerCountdown.timesUp1 == false && timerCountdown.allDone1 == false)
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
    /// finds coords of mouse position and applies the soap texture over that area
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
        float mappedScore = minTarget + (maxTarget - minTarget) * ((pixelCount - minOriginal) / (maxOriginal - minOriginal));
        // Round the mapped score to the nearest integer
        int roundedScore = Mathf.RoundToInt(mappedScore);
        // Ensure the score is within the target range
        return Mathf.Clamp(roundedScore, minTarget, maxTarget);
    }
    /// <summary>
    /// takes the saved original colros and sets the dirty texture equal to those so it doesnt ruin the texture forever
    /// </summary>
    public void ResetShoe()
    {
        cleanedPixelCount = 0;
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
