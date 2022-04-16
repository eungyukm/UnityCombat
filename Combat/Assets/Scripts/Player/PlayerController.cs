using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Movement _movement;
    private CharacterController _characterController;
    public AttackReader _attackReader;
    private PlayerAnimator _playerAnimator;

    private void OnEnable()
    {
        _attackReader.OnDefaultAttack += DefaultAttack;
    }

    private void OnDisable()
    {
        _attackReader.OnDefaultAttack -= DefaultAttack;
    }

    // Start is called before the first frame update
    void Start()
    {
        _movement = GetComponent<Movement>();
        _characterController = GetComponent<CharacterController>();
        _playerAnimator = GetComponent<PlayerAnimator>();
    }

    // Update is called once per frame
    void Update()
    {
        _characterController.Move(_movement.MoveDirecton * _movement.MoveSpeed * Time.deltaTime);
        _playerAnimator.OnMovement(_movement._inputX, _movement._inputZ);
        transform.rotation = Quaternion.Euler(0, _movement._cameraTransform.eulerAngles.y, 0);
    }

    void DefaultAttack()
    {
        Debug.Log("Default Attack Call!!");
        _playerAnimator.OnDefaultAttack();
    }
}
