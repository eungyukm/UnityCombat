using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void OnMovement(float horizontal, float vertical)
    {
        _animator.SetFloat("horizontal", horizontal);
        _animator.SetFloat("vertical", vertical);
    }

    public void OnDefaultAttack()
    {
        _animator.SetTrigger("onWeaponAttack");
    }
}
