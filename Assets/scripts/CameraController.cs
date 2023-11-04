using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public LayerMask obstacleMask;
    public float mouseSensitivity = 100f;
    public float collisionDistance = 2.0f;
    public float initialCameraDistance = 2.0f;
    public float minCameraDistance = 1.0f;
    public float maxCameraDistance = 5.0f;

    float xRotation = 0f;
    Vector3 initialPosition;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        initialPosition = transform.localPosition;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Obrót postaci w lewo i prawo
        player.Rotate(Vector3.up * mouseX);

        // Sprawdzenie kolizji kamery z przeszkodami
        CheckCameraCollision();
    }

    void CheckCameraCollision()
    {
        Vector3 direction = transform.position - player.position;
        RaycastHit hit;

        if (Physics.Raycast(player.position, direction, out hit, collisionDistance, obstacleMask))
        {
            transform.position = hit.point - direction.normalized * 0.2f; // Unikanie przenikania przez obiekty
        }
        else
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, initialPosition, Time.deltaTime); // Powrót kamery do pocz¹tkowej pozycji
        }
    }
}