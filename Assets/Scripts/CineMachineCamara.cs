using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CineMachineCamara : MonoBehaviour
{
    public static CineMachineCamara Instance;
    private CinemachineVirtualCamera _cinemachineVirtualCamera;
    private CinemachineBasicMultiChannelPerlin _cinemachineBasicMultichannelPerlin;
    private float timeMovement;
    private float initialMovementTime;
    private float initialIntencity;

    private void Awake()
    {
        Instance = this;
        _cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
        _cinemachineBasicMultichannelPerlin = _cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    public void MoveCamera(float intencity, float frequency, float time)
    {
        _cinemachineBasicMultichannelPerlin.m_AmplitudeGain = intencity;
        _cinemachineBasicMultichannelPerlin.m_FrequencyGain = frequency;
        initialIntencity = intencity;
        initialMovementTime = time;
        timeMovement = time;
    }

    private void Update()
    {
        if (timeMovement > 0)
        {
            timeMovement -= Time.deltaTime;
            _cinemachineBasicMultichannelPerlin.m_AmplitudeGain = Mathf.Lerp(initialIntencity, 0, 1 - (timeMovement / initialMovementTime));
        }
    }
}
