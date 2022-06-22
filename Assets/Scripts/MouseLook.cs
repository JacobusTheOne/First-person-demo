using UnityEngine;
using System.Collections;

// MouseLook rotates the transform based on the mouse delta.
// To make an FPS style character:
// - Create a capsule.
// - Add the MouseLook script to the capsule.
//   -> Set the mouse look to use MouseX. (You want to only turn character but not tilt it)
// - Add FPSInput script to the capsule
//   -> A CharacterController component will be automatically added.
//
// - Create a camera. Make the camera a child of the capsule. Position in the head and reset the rotation.
// - Add a MouseLook script to the camera.
//   -> Set the mouse look to use MouseY. (You want the camera to tilt up and down like a head. The character already turns.)


public class MouseLook : MonoBehaviour {
    public float horSensitivity = 10f;
    public float verSensitivity = 10f;
    public float minAngle = -45f;
    public float maxAngle = 45f;
    public float rotationX = 0f;
    public Transform playerBody;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
       
    }
    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * horSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * verSensitivity * Time.deltaTime;

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, minAngle, maxAngle);
        transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX * 10f);
            
    }

}