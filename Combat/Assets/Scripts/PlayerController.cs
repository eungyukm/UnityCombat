using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Move _move;
    // Start is called before the first frame update
    void Start()
    {
        _move = GetComponent<Move>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        _move.MoveSpeed = z > 0 ? 5.0f : 2.0f;
        _move.MoveTo(new Vector3(x, 0, z));
    }
}
