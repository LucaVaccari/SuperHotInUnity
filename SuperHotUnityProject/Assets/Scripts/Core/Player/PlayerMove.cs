using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speed = 10;
    [SerializeField] private float xSens = 10, ySens = 10;

    Vector2 moveInput, lookInput;

    CharacterController cc;

    private void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    private void Update()
    {
        CalculateInput();
        Look();
        Move();
    }

    private void CalculateInput()
    {
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");

        lookInput.x = Input.GetAxis("Mouse X");
        lookInput.y = Input.GetAxis("Mouse Y");
    }
    private void Look()
    {

    }
    private void Move()
    {
        Vector3 velocity = new Vector3(moveInput.x, 0, moveInput.y) * Time.unscaledDeltaTime * speed;
        cc.Move(velocity);
    }
}
