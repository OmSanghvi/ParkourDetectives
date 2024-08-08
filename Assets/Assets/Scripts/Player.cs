using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private LayerMask doorLayerMask;
    [SerializeField] private Text cluesText;
    [SerializeField] private GameObject choosingButton;
    [SerializeField] private GameObject choosingButtonPrefab;
    [SerializeField] private LayerMask objectMask;
    [SerializeField] private Transform playerCameraTransform;
    [SerializeField] private PlayerPickUp playerPickUp;
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private CodePanelInputField boxComp;
    [SerializeField] private GameObject winCanvas;
    [SerializeField] private GameObject boxCodeUI;

    public int bookCounter;
    public int pillCounter;
    public int totalCounter;
    public int wardrobeCounter;
    public int drawerCounter;
    public int crateCounter;

    private void Start()
    {
        choosingButtonPrefab.SetActive(false);
        gameOverUI.SetActive(false);
        boxCodeUI.SetActive(false);
    }

    private void Update()
    {
        if (transform.position.y < -15f)
        {
            gameOverUI.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            
        }

        HandleInteractions();
        totalCounter = bookCounter + pillCounter + wardrobeCounter + drawerCounter + crateCounter + boxComp.boxClue + playerPickUp.chestCounter + playerPickUp.flaskCounter;
        cluesText.text = "Clues Found: " + totalCounter + "/8";
        choosingButton.SetActive(totalCounter >= 8);
        choosingButtonPrefab.SetActive(totalCounter >= 8);
    }

    private void HandleInteractions()
    {
        float interactDistance = 2.5f;

        if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHit, interactDistance, doorLayerMask))
        {
            if (raycastHit.transform.TryGetComponent(out Door door))
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    door.ToggleDoor();
                }
            }
        }

        if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit pageHit, interactDistance))
        { 
            if (pageHit.transform.TryGetComponent(out BookShelf bookShelf)) 
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    bookShelf.ToggleBookShelf();
                    bookCounter = Mathf.Clamp(bookCounter + 1, 0, 1);
                }
            }
        }

        if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit sofaHit, interactDistance))
        { 
            if (sofaHit.transform.TryGetComponent(out SofaPill sofaPill))
            {
                if (Input.GetKeyDown(KeyCode.E))
                { 
                    sofaPill.TogglePill();
                    pillCounter = Mathf.Clamp(pillCounter + 1, 0, 1);
                }
            }
        }

        if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit wardrobeHit, interactDistance))
        {
            if (wardrobeHit.transform.TryGetComponent(out Wardrobe wardrobe))
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    wardrobe.ToggleWardrobe();
                    wardrobeCounter = Mathf.Clamp(wardrobeCounter + 1, 0, 1);
                }
            }
        }

        if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit drawerHit, interactDistance))
        {
            if (drawerHit.transform.TryGetComponent(out DiningTableDrawers drawers))
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    drawers.ToggleDrawers();
                    drawerCounter = Mathf.Clamp(drawerCounter + 1, 0, 1);
                }
            }
        }

        if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit crateHit, interactDistance))
        {
            if (crateHit.transform.TryGetComponent(out SofaCrate crate))
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    crate.ToggleSofa();
                    crateCounter = Mathf.Clamp(crateCounter + 1, 0, 1);
                }
            }
        }

        if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit boxHit, interactDistance))
        {
            if (boxHit.transform.TryGetComponent(out BoxController box))
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    box.ToggleBox();
                }
            }
        }

        if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit suspectHit, interactDistance))
        {
            if (suspectHit.transform.TryGetComponent(out SuspectButton suspectButton))
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }
}
