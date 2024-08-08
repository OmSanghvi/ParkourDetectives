using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ButtonBehavior : MonoBehaviour
{
    public GameObject popupMenu; // Reference to the popup menu panel
    public GameObject gameOverUI; // Reference to the Text component in the popup menu
    public GameObject winCanvas;
    public GameObject choosingCanvas;

    private string correctOption = "Button (2)";

    public void CheckAnswer()
    {
        // Example: You can use UI buttons or other UI components to provide options
        // Here, we simulate a simple text-based option selection

        // Assuming Option A, Option B, Option C, Option D are UI buttons on your popupMenu panel
        Button optionAButton = popupMenu.transform.Find("Button").GetComponent<Button>();
        Button optionBButton = popupMenu.transform.Find("Button (1)").GetComponent<Button>();
        Button optionCButton = popupMenu.transform.Find("Button (2)").GetComponent<Button>();
        Button optionDButton = popupMenu.transform.Find("Button (3)").GetComponent<Button>();

        // Set up button click events to check correctness
        optionAButton.onClick.AddListener(() => CheckOption("Button"));
        optionBButton.onClick.AddListener(() => CheckOption("Button (1)"));
        optionCButton.onClick.AddListener(() => CheckOption("Button (2)"));
        optionDButton.onClick.AddListener(() => CheckOption("Button (3)"));
    }

    private void Start()
    {
        gameOverUI.SetActive(false);
        winCanvas.SetActive(false);
        choosingCanvas.SetActive(false);
        popupMenu.SetActive(false);
    }

    private void CheckOption(string selectedOption)
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        if (selectedOption == correctOption)
        {
            winCanvas.SetActive(true);
        }
        else
        {
            gameOverUI.SetActive(true);
        }

        // Optionally: Close the popup menu after selection
        Invoke("ClosePopupMenu", 0.5f); // Close after 2 seconds (adjust as needed)
    }

    private void ClosePopupMenu()
    {
        popupMenu.SetActive(false);
        choosingCanvas.SetActive(false);
    }
}