using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CounterManager : MonoBehaviour
{
    private int tapCount = 0;

    // Reference to the TextMeshProUGUI component
    public TextMeshProUGUI tapCountText;
    private float touchTime = 0f;  // Time the player has held the touch on the screen
    private bool isTouching = false;  // Whether the player is currently touching the screen
    public float touchTimeScoringPoint;
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);  // Get the first touch (0 is the index of the first touch)

            if (touch.phase == TouchPhase.Began)  // Touch just started
            {
                // Start the countdown timer when the player first touches the screen
                isTouching = true;
                touchTime = 0f;  // Reset the timer
                tapCount++;
                tapCountText.text = tapCount.ToString();
            }

            if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)  // Player is holding the screen
            {
                // Increment the timer while the player holds the touch
                if (isTouching)
                {
                    touchTime += Time.deltaTime;  // Increase time by the amount of time passed since the last frame

                    if (touchTime >= touchTimeScoringPoint)  // If 5 seconds have passed
                    {
                        // Increment the counter and reset the timer
                        tapCount++;
                        touchTime = 0f;  // Reset timer after incrementing the counter
                        tapCountText.text = tapCount.ToString();  // Update the displayed counter
                    }
                }
            }

            if (touch.phase == TouchPhase.Ended)  // Touch ended
            {
                // Stop the countdown when the player releases the touch
                isTouching = false;
                touchTime = 0f;  // Reset the timer
            }
        }
    }
}
