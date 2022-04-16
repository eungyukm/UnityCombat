using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using Cursor = UnityEngine.Cursor;

public class CameraManger : MonoBehaviour
{
    public InputReader inputReader;

    public Camera mainCamera;

    public CinemachineFreeLook freeLookVCam;

    // public CinemachineImpulseSource ImpulseSource;

    private bool _isRMBPressed;

    private bool _cameraMovementLock = false;

    [SerializeField] [Range(.5f, 3f)] private float _speedMultiplier = 1f;

    [SerializeField] private Transform target;
    private void OnEnable()
    {
        inputReader.CameraMoveEvent += OnCameraMove;
        inputReader.EnableMouseControlCameraEvent += OnEnableMouseControlCamera;
        inputReader.DisableMouseControlCameraEvent += OnDisalbeMouseControlCamera;
    }

    private void OnDisable()
    {
        inputReader.CameraMoveEvent -= OnCameraMove;
        inputReader.EnableMouseControlCameraEvent -= OnEnableMouseControlCamera;
        inputReader.DisableMouseControlCameraEvent -= OnDisalbeMouseControlCamera;
    }

    // Start is called before the first frame update
    void Start()
    {
        inputReader.EnableGamePlayInput();
        
        SetupVirtualCamera();
    }

    public void SetupVirtualCamera()
    {
        Debug.Log("SetupVirtual Camera!!");
        freeLookVCam.Follow = target;
        freeLookVCam.LookAt = target;
        
        // Target으로 Camer를 이동시킵니다.
        freeLookVCam.OnTargetObjectWarped(target, target.position - freeLookVCam.transform.position - Vector3.forward);
    }
    
    /// <summary>
    /// 오른쪽 마우스가 클릭 되었을 때
    /// </summary>
    private void OnEnableMouseControlCamera()
    {
        _isRMBPressed = true;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        StartCoroutine(DisableMouseControlForFrame());
    }

    private IEnumerator DisableMouseControlForFrame()
    {
        _cameraMovementLock = true;
        yield return new WaitForEndOfFrame();
        _cameraMovementLock = false;
    }

    private void OnDisalbeMouseControlCamera()
    {
        _isRMBPressed = false;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        freeLookVCam.m_XAxis.m_InputAxisValue = 0;
        freeLookVCam.m_YAxis.m_InputAxisValue = 0;
    }

    private void OnCameraMove(Vector2 cameraMovement, bool isDeviceMouse)
    {
        // Debug.Log("OnCamera Move Call!!");
        if (_cameraMovementLock)
        {
            return;
        }

        if (isDeviceMouse && !_isRMBPressed)
        {
            return;
        }

        float deviceMultiplier = isDeviceMouse ? 0.02f : Time.deltaTime;

        freeLookVCam.m_XAxis.m_InputAxisValue = cameraMovement.x * deviceMultiplier * _speedMultiplier;
        freeLookVCam.m_YAxis.m_InputAxisValue = cameraMovement.y * deviceMultiplier * _speedMultiplier;
    }
}
