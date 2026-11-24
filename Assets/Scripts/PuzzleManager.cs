using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleManager : MonoBehaviour
{
    [Header("Correct Button Sequence")]
    [SerializeField] private int[] correctSequence = { 7, 5, 6, 0, 2 };

    [Header("Grid Buttons")]
    [SerializeField] private Button[] gridButtons;

    [Header("UI Feedback")]
    [SerializeField] private TMP_Text feedbackText;

    private int[] playerSequence = new int[5];
    private int currentStep = 0;

    private Image[] buttonImages;
    private Color[] originalColors;

    private void Awake()
    {
        // Get the Image component from each button
        buttonImages = new Image[gridButtons.Length];
        originalColors = new Color[gridButtons.Length];

        for (int i = 0; i < gridButtons.Length; i++)
        {
            buttonImages[i] = gridButtons[i].GetComponent<Image>();
            originalColors[i] = buttonImages[i].color;
        }
    }

    public void PressButton(int buttonIndex)
    {
        // Ignore presses once all 5 buttons have been entered
        if (currentStep >= 5)
            return;

        // Clear old feedback when a new attempt begins
        if (currentStep == 0)
        {
            CancelInvoke(nameof(ResetPuzzle));
            feedbackText.text = "";
        }

        // Highlight the pressed button
        buttonImages[buttonIndex].color = Color.yellow;

        // Record the button press
        playerSequence[currentStep] = buttonIndex;
        currentStep++;

        // Check the sequence after 5 presses
        if (currentStep == 5)
        {
            bool isCorrect = true;

            for (int i = 0; i < 5; i++)
            {
                if (playerSequence[i] != correctSequence[i])
                {
                    isCorrect = false;
                    break;
                }
            }

            if (isCorrect)
            {
                feedbackText.color = Color.green;
                feedbackText.text = "Correct! You solved the puzzle!";
            }
            else
            {
                feedbackText.color = Color.red;
                feedbackText.text = "Wrong button order! Try again.";
            }

            // Reset everything after 1 second
            Invoke(nameof(ResetPuzzle), 1f);
        }
    }

    private void ResetPuzzle()
    {
        // Restore all original button colours
        for (int i = 0; i < buttonImages.Length; i++)
        {
            buttonImages[i].color = originalColors[i];
        }

        feedbackText.text = "";
        currentStep = 0;
    }
}
