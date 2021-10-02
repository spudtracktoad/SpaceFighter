using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class SpaceshipController : MonoBehaviour
{
    public float normalSpeed = 0f;
    public float accelerationSpeed = 45f;
    public Transform cameraPosition;
    public Camera mainCamera;
    public Transform spaceshipRoot;
    public float rotationSpeed = 4.0f;
    public float cameraSmooth = 4f;
    public RectTransform crosshairTexture;
    public Camera spaceCraft;
    public Camera overheadCamera;

    float speed;
    float pitch = 0.0f;
    float yaw = 0.0f;

    Rigidbody r;
    Quaternion lookRotation;
    float rotationZ = 0;
    float mouseXSmooth = 0;
    float mouseYSmooth = 0;
    Vector3 defaultShipRotation;
    float rotationY; //Yaw
    float rotationX; //Pitch
    float scale = 2f;

    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<Rigidbody>();
        r.useGravity = false;
        lookRotation = transform.rotation;
        defaultShipRotation = spaceshipRoot.localEulerAngles;
        rotationZ = defaultShipRotation.z;
        rotationY = defaultShipRotation.y;
        rotationX = defaultShipRotation.x;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        spaceCraft.enabled = true;
        overheadCamera.enabled = false;
    }

    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.C))
        {
            spaceCraft.enabled = !spaceCraft.enabled;
            overheadCamera.enabled = !overheadCamera.enabled;
        }
        //Press mouse wheel to accelerate or decelerate
        if (Input.GetAxisRaw("Mouse ScrollWheel") > 0)
        {
            //wheel goes up
            speed += Input.mouseScrollDelta.y* scale;
            Debug.Log(speed.ToString());
            //speed = Mathf.Lerp(speed, accelerationSpeed, Time.deltaTime * 3);
        }
        else if (Input.GetAxisRaw("Mouse ScrollWheel") < 0)
        {
            //wheel goes down
            speed += Input.mouseScrollDelta.y * scale;
            Debug.Log(speed.ToString());
            //speed = Mathf.Lerp(speed, accelerationSpeed, Time.deltaTime * 3);
        }

        //Set moveDirection to the vertical axis (up and down keys) * speed
        Vector3 moveDirection = new Vector3(0, 0, speed);
        //Transform the vector3 to local space
        moveDirection = transform.TransformDirection(moveDirection);
        //Set the velocity, so you can move
        r.velocity = new Vector3(moveDirection.x, moveDirection.y, moveDirection.z);

        //Camera follow
        yaw += Input.GetAxis("Mouse X") * rotationSpeed;
        yaw = Mathf.Clamp(yaw, -45, 45);
        pitch += Input.GetAxis("Mouse Y") * rotationSpeed;
        pitch = Mathf.Clamp(pitch, -45, 45);
        spaceCraft.transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        //mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, cameraPosition.position, Time.deltaTime * cameraSmooth);
        //mainCamera.transform.rotation = Quaternion.Lerp(mainCamera.transform.rotation, cameraPosition.rotation, Time.deltaTime * cameraSmooth);

        //mouseXSmooth = Mathf.Lerp(mouseXSmooth, Input.GetAxis("Mouse X") * rotationSpeed, Time.deltaTime * cameraSmooth);
        //mouseYSmooth = Mathf.Lerp(mouseYSmooth, Input.GetAxis("Mouse Y") * rotationSpeed, Time.deltaTime * cameraSmooth);
        //Quaternion localRotation = Quaternion.Euler(-mouseYSmooth, mouseXSmooth, -3 * rotationSpeed);
        //lookRotation = lookRotation * localRotation;
        //transform.rotation = lookRotation;
        //rotationZ -= mouseXSmooth;
        //rotationZ = Mathf.Clamp(rotationZ, -45, 45);

        //Rotation
        float rotationZTmp = 0;
        if (Input.GetKey(KeyCode.A))
        {
            rotationY += -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rotationY += 1;
        }
        if (Input.GetKey(KeyCode.W))
        {
            rotationX += -1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            rotationX += 1;
        }

        //rotationY += Input.GetAxis("Mouse Y") * rotationSpeed;

        //rotationY = Mathf.Clamp(rotationY, -45, 45);
        //rotationX = Mathf.Clamp(rotationX, -45, 45);
        spaceshipRoot.transform.localEulerAngles = new Vector3(rotationX, rotationY, rotationZ);
        rotationZ = Mathf.Lerp(rotationZ, defaultShipRotation.z, Time.deltaTime * cameraSmooth);

        //Update crosshair texture
        if (crosshairTexture)
        {
            crosshairTexture.position = mainCamera.WorldToScreenPoint(transform.position + transform.forward * 100);
        }
    }
}