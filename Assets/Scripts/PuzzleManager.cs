using TMPro;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    [Header("Correct Button Sequence")]
    [SerializeField] private int[] correctSequence = { 7, 5, 6, 0, 2 };

    [Header("UI Feedback")]
    [SerializeField] private TMP_Text feedbackText;

    private int currentStep = 0;

    public void PressButton(int buttonIndex)
    {
        if (buttonIndex == correctSequence[currentStep])
        {
            currentStep++;

            // GREEN text for correct buttons
            feedbackText.color = Color.green;
            feedbackText.text = "Correct! " + currentStep + "/5";

            if (currentStep == correctSequence.Length)
            {
                feedbackText.color = Color.green;
                feedbackText.text = "CORRECT! Puzzle solved!";
                currentStep = 0;
            }
        }
        else
        {
            // RED text for wrong buttons
            feedbackText.color = Color.red;
            feedbackText.text = "Wrong order! Try again.";

            currentStep = 0;
        }
    }
}
