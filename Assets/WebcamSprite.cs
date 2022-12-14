using UnityEngine;
using System.Collections;

public class WebcamSprite : MonoBehaviour
{
    // The webcam texture
    WebCamTexture webcamTexture;

    // The renderer for the sprite
    SpriteRenderer spriteRenderer;

    void Start()
    {
        // Get the webcam texture
        webcamTexture = new WebCamTexture();

        // If the webcam is not available, print a debug message
        if (webcamTexture == null)
        {
            Debug.LogError("Webcam not available");
            return;
        }

        // Get the renderer for the sprite
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Create a new texture from the webcam texture
        Texture2D texture = new Texture2D(webcamTexture.width, webcamTexture.height);
        texture.SetPixels(webcamTexture.GetPixels());
        texture.Apply();

        // Set the texture as the sprite's texture
        spriteRenderer.sprite = Sprite.Create(
            texture,
            new Rect(0, 0, texture.width, texture.height),
            new Vector2(0.5f, 0.5f)
        );

        // Start the webcam
        webcamTexture.Play();
    }
}


