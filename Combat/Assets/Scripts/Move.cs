using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private Animator animator;

    private Vector3 _moveDirection;
    [SerializeField] private float _moveSpeed = 5f;

    public float MoveSpeed
    {
        set => _moveSpeed = Mathf.Clamp(value, 2.0f, 5.0f);
    }

    private CharacterController characterController;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //characterController.Move(_moveDirection * _moveSpeed * Time.deltaTime);
    }

    public void MoveTo(Vector3 direction)
    {
        _moveDirection = new Vector3(direction.x, _moveDirection.y, direction.z); 
    }
}
