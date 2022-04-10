using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Movement _movement;
    private CharacterController _characterController;

    // Start is called before the first frame update
    void Start()
    {
        _movement = GetComponent<Movement>();
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        _characterController.Move(_movement.MoveDirecton * _movement.MoveSpeed * Time.deltaTime);
    }
}
