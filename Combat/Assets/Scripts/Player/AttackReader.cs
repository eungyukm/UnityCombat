using System;
using UnityEngine;
using UnityEngine.Events;

public class AttackReader : MonoBehaviour
{
    public InputReader InputReader;
    public UnityAction OnDefaultAttack;
    
    private void OnEnable()
    {
        InputReader.OnAttackEvent += DefaultAttack;
    }

    private void OnDisable()
    {
        InputReader.OnAttackEvent -= DefaultAttack;
    }

    public void DefaultAttack()
    {
        Debug.Log("Left Mouse Button Click");
        OnDefaultAttack?.Invoke();
    }
}
