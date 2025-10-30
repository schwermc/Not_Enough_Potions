using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] Settings setting;
    public Transform playerBody;
    float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * setting.getDIP() * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * setting.getDIP() * Time.deltaTime;

        xRotation -= mouseY; // += cause the roations to be flipped
        xRotation = Mathf.Clamp(xRotation, -45, 45);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    public void setSensitivity(float amount)
    {
        setting.setDIP(amount);
    }
}
