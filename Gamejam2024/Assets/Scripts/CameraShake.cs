using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraShake : MonoBehaviour
{
    private static CameraShake instance;
    private CameraShake()
    {

    }

    void Awake()
    {
        Instance = this;
        //DontDestroyOnLoad(gameObject);
    }
    public static CameraShake Instance { get; private set; }

    private void OnShake(float duration, float strenght)
    {
        transform.DOShakePosition(duration, strenght);
        transform.DOShakePosition(duration, strenght);
        //transform.position = Vector3.zero;
    }

    public static void Shake(float duration, float strenght) => Instance.OnShake(duration, strenght);
}
