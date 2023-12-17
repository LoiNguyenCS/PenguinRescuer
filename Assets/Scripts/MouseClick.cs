using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// inspired from: https://medium.com/@seemantadebdas/make-your-own-first-person-controller-part-1-9864d0b5b689

public class MouseClick : MonoBehaviour
{
    [SerializeField] float mouseSensitivity = 200f;
    private Camera cam;
    void Update()
    {
        Vector2 mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * mouseSensitivity * Time.deltaTime;
        transform.Rotate(Vector3.up * mouseInput.x);
    }

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        cam = Camera.main;
    }
}
