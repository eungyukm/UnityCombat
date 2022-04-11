using UnityEngine;

public class Movement : MonoBehaviour
{
    public Vector3 MoveDirecton;

    public float MoveSpeed;

    public InputReader InputReader;
    public Transform _cameraTransform;
    
    public float _inputX;
    public float _inputZ;
    
    private void OnEnable()
    {
        InputReader.MoveEvent += SetUPMovement;
    }

    private void OnDisable()
    {
        InputReader.MoveEvent -= SetUPMovement;
    }

    public void MoveTo(Vector3 direction)
    {
        MoveDirecton = new Vector3(direction.x, 0, direction.z);
        MoveDirecton.Normalize();
    }

    private void SetUPMovement(Vector2 move)
    {
        _inputX = move.x;
        _inputZ = move.y;
    }

    private void Update()
    {
        MoveSpeed = _inputZ > 0 ? 5.0f : 2.0f;
        MoveTo(_cameraTransform.rotation * new Vector3(_inputX, 0, _inputZ));
    }
}
