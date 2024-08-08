using TMPro;
using UnityEngine;

public class CodePanelInputField : MonoBehaviour
{
    public TMP_InputField inputField;
    public GameObject incorrectText;
    public GameObject correctText;
    public GameObject tryAgainButton;
    public GameObject submitButton;
    public BoxController box;
    public GameObject boxCodeUI;
    public int boxClue;
    [SerializeField] private TextMeshPro diningText;
    [SerializeField] private TextMeshPro pillText;
    [SerializeField] private TextMeshPro wardrobeText;
    [SerializeField] private TextMeshPro analyticalInstText;
    [SerializeField] private TextMeshPro bookText;
    private int randomNumber;

    private void Start()
    {
        SetTextByRandomNum();
        incorrectText.SetActive(false);
        correctText.SetActive(false);
        tryAgainButton.SetActive(false);
    }

    public void inputFieldBehavior()
    {
        if (randomNumber == 1)
        {
            if (inputField.text == "92658")
            {
                boxClue = 1;
                correctText.SetActive(false);
                boxCodeUI.SetActive(false);
                tryAgainButton.SetActive(false);
                if (box.isOpen == false)
                {
                    box.OpenBox();
                }
            }
            else{InputFieldIncorrect();}
        }
        else if (randomNumber == 2)
        {
            if (inputField.text == "71936")
            {
                boxClue = 1;
                correctText.SetActive(false);
                boxCodeUI.SetActive(false);
                tryAgainButton.SetActive(false);
                if (box.isOpen == false)
                {
                    box.OpenBox();
                }
            }
            else{InputFieldIncorrect();}
            
        }
        else if (randomNumber == 3)
        {
            if (inputField.text == "84815")
            {
                boxClue = 1;
                correctText.SetActive(false);
                boxCodeUI.SetActive(false);
                tryAgainButton.SetActive(false);
                if (box.isOpen == false)
                {
                    box.OpenBox();
                }
            }
            else{InputFieldIncorrect();}
        }
        else if (randomNumber == 4)
        {
            if (inputField.text == "27403")
            {
                boxClue = 1;
                correctText.SetActive(false);
                boxCodeUI.SetActive(false);
                tryAgainButton.SetActive(false);
                if (box.isOpen == false)
                {
                    box.OpenBox();
                }
            }
            else{InputFieldIncorrect();}
        }
    }

    public void SetTextByRandomNum()
    {
        randomNumber = Random.Range(1, 5);
        if (randomNumber == 1)
        {
            diningText.text = "9:1";
            wardrobeText.text = "2:2";
            pillText.text = "Heroin 6:3";
            bookText.text = "5:4";
            analyticalInstText.text = "Found: Radium, Water, and DNA of Mrs Finch and Lady Amelia 8:5";
        }
        else if (randomNumber == 2)
        {
            diningText.text = "7:1";
            wardrobeText.text = "1:2";
            pillText.text = "Heroin 9:3";
            bookText.text = "3:4";
            analyticalInstText.text = "Found: Radium, Water, and DNA of Mrs Finch and Lady Amelia 6:5";
        }
        else if (randomNumber == 3)
        {
            diningText.text = "8:1";
            wardrobeText.text = "4:2";
            pillText.text = "Heroin 8:3";
            bookText.text = "1:4";
            analyticalInstText.text = "Found: Radium, Water, and DNA of Mrs Finch and Lady Amelia 5:5";
        }
        else if (randomNumber == 4)
        {
            diningText.text = "2:1";
            wardrobeText.text = "7:2";
            pillText.text = "Heroin 4:3";
            bookText.text = "0:4";
            analyticalInstText.text = "Found: Radium, Water, and DNA of Mrs Finch and Lady Amelia 3:5";
        }
    }

    private void InputFieldIncorrect()
    {
        if (box.isOpen)
        {
            box.CloseBox();
        }
        incorrectText.SetActive(true);
        tryAgainButton.SetActive(true);
        submitButton.SetActive(false); 
    }
}
