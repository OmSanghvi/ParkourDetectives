using UnityEngine;

public class ObjectGrabbable : MonoBehaviour
{
    private Rigidbody objectRigidBody;
    private Transform objectGrabPointTransform;
    private MeshCollider objectMeshCollider;
    private BoxCollider objectBoxCollider;
    public bool isGrabbed;

    private void Awake()
    {
        objectRigidBody = GetComponent<Rigidbody>();
        objectMeshCollider = GetComponent<MeshCollider>();
        objectBoxCollider = GetComponent<BoxCollider>();
    }

    public void Grab(Transform grabPoint)
    {
        objectGrabPointTransform = grabPoint;
        objectRigidBody.useGravity = false;
        objectRigidBody.velocity = Vector3.zero; // Stop any existing movement
        objectRigidBody.angularVelocity = Vector3.zero; // Stop any existing rotation
        if (objectMeshCollider != null)
        {
            objectMeshCollider.enabled = false;
        }

        if (objectBoxCollider != null)
        {
            objectBoxCollider.enabled = false;
        }

        isGrabbed = true;
    }

    public void Drop()
    {
        objectGrabPointTransform = null;
        objectRigidBody.useGravity = true;
        if (objectMeshCollider != null)
        {
            objectMeshCollider.enabled = true;
        }
        objectRigidBody.isKinematic = false;
        
        if (objectBoxCollider != null)
        {
            objectBoxCollider.enabled = true;
        }

        isGrabbed = false;
    }

    private void FixedUpdate()
    {
        if (objectGrabPointTransform != null)
        {
            float lerpSpeed = 1f; 
            Vector3 newPosition = Vector3.Lerp(transform.position, objectGrabPointTransform.position, Time.deltaTime * lerpSpeed);
            transform.position = newPosition;
        }
    }

    public void MakeKinematic()
    {
        objectRigidBody.isKinematic = true;
    }
}