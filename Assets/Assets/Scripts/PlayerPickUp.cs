using System.Collections;
using UnityEngine;

public class PlayerPickUp : MonoBehaviour
{
    [SerializeField] private Transform playerCameraTransform;
    [SerializeField] private Transform objectGrabPointTransform;
    [SerializeField] private LayerMask objectLayerMask;
    [SerializeField] private KeyTest keyTest;
    [SerializeField] private AudioClipsRefsSO audioClipsRefsSO;
    [SerializeField] private SoundManager soundManager;
    [SerializeField] private KeyCardInput KeyCardInput;
    
    
    private GameObject mainCamera;
    
    private ObjectGrabbable objectGrabbable;
    private bool hasKey;
    

    private bool hasFlask;
    private bool hasKeyCard;
    public int chestCounter;
    public int flaskCounter;
    
    

    private void Awake()
    {
        if (mainCamera == null)
        {
            mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (objectGrabbable == null)
            {
                float pickUpDistance = 30f;

                if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward,
                        out RaycastHit raycastHit, pickUpDistance, objectLayerMask))
                {
                    if (raycastHit.transform.TryGetComponent(out ObjectGrabbable grabbedObject))
                    {
                        grabbedObject.Grab(objectGrabPointTransform);
                        if (grabbedObject.TryGetComponent(out KeyTest key))
                        {
                            hasKey = true;
                        }
                        else
                        {
                            hasKey = false;
                        }

                        if (grabbedObject.TryGetComponent(out ErlenFlask erlenFlask))
                        {
                            hasFlask = true;
                        }
                        else
                        {
                            hasFlask = false;
                        }

                        if (grabbedObject.TryGetComponent(out KeyCard keyCard))
                        {
                            hasKeyCard = true;
                        }
                        else
                        {
                            hasKeyCard = false;
                        }

                        objectGrabbable = grabbedObject;
                        keyTest.keyMovedAndRotated = false;
                    }
                }
            }
            else
            {
                objectGrabbable.Drop();
                objectGrabbable = null;
                hasKey = false;
                hasFlask = false;
                hasKeyCard = false;
            }
        }

        float chestHitDistance = 3f;
        if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward,
                out RaycastHit chestHit, chestHitDistance))
        {
            if (chestHit.transform.TryGetComponent(out Chest chest))
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (!keyTest.keyMovedAndRotated)
                    {
                        if (hasKey)
                        {
                            if (objectGrabbable != null)
                            {
                                objectGrabbable.Drop();
                                objectGrabbable.MakeKinematic();
                                objectGrabbable = null;
                            }
                            keyTest.KeyOpenChestRotateAtStart();

                            chestCounter++;
                            if (chestCounter > 1)
                            {
                                chestCounter = 1;
                            }
                        }

                        
                    }
                    else
                    {
                        chest.ToggleChestLid();
                    }
                }
            }
        }
        
        float instHitDistance = 3f;
        if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward,
                out RaycastHit instHit, instHitDistance))
        {
            if (instHit.transform.TryGetComponent(out AnalyticalInst analyticalInst))
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                        if (hasFlask&&!analyticalInst.textIsShown)
                        {
                            if (objectGrabbable != null)
                            {
                                objectGrabbable.Drop();
                                objectGrabbable.MakeKinematic();
                                objectGrabbable = null;
                            }
                            analyticalInst.Scan();
                            soundManager.PlaySound(audioClipsRefsSO.clueCollected, mainCamera.transform.position);
                            flaskCounter++;
                            if (flaskCounter > 1)
                            {
                                flaskCounter = 1;
                            }
                        }
                }
            }
        }
        
        if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward,
                out RaycastHit keyCardHit, instHitDistance))
        {
            if (keyCardHit.transform.TryGetComponent(out KeyCardInput keyCardInput))
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (hasKeyCard && !keyCardInput.garageOpened)
                    {
                        if (objectGrabbable != null)
                        {
                            objectGrabbable.Drop();
                            objectGrabbable.MakeKinematic();
                            objectGrabbable = null;
                        }
                        keyCardInput.RotateKeyCard();
                        keyCardInput.MoveKeyCard();
                    }
                }
            }
        }
    }
}
