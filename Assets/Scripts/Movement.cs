using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// inspired from: https://medium.com/@seemantadebdas/make-your-own-first-person-controller-part-1-9864d0b5b689
public class Movement : MonoBehaviour
{
    [SerializeField] float speed;
    Vector3 direction;
    CharacterController controller;
    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        direction = (transform.right * input.x + transform.forward * input.z).normalized * speed;
        controller.Move(direction * Time.deltaTime);
    }
}