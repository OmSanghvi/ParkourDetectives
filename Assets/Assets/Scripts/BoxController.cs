using UnityEngine;

public class BoxController : MonoBehaviour
{
    public GameObject boxLid;
    public GameObject codeUI;

    public bool isOpen;

    private void Start()
    {
        codeUI.SetActive(false);
    }

    public void ToggleBox()
    {
        if (isOpen)
            CloseBox();
        else
            OpenBox();
    }

    public void OpenBox()
    {
        boxLid.transform.rotation *= Quaternion.Euler(90f,0f,0f);
        boxLid.transform.position += new Vector3(-0.3f,1, 0f);
        isOpen = true;
        codeUI.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void CloseBox()
    {
        boxLid.transform.rotation *= Quaternion.Euler(-90f,0f,0f);
        boxLid.transform.position -= new Vector3(-0.3f,1, 0f);
        isOpen = false;
    }
}