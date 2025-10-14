using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController _controller;
    public float speed = 12f;

    void Awake()
    {
        _controller = gameObject.GetComponent<CharacterController>();
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        _controller.Move(move * speed * Time.deltaTime);
    }

}
