using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{

    [SerializeField]
    private float _Speed = 10f;
    [SerializeField]
    private float _Th;

    private void Start()
    {
        _Speed = Random.Range(-20f,20f);
    }
    // Update is called once per frame
    void Update()
    {
        UpdateTransform();
    }

    private void UpdateTransform()
    {
        _Th = (_Th + Time.deltaTime * _Speed) % 360f;
        this.transform.rotation = Quaternion.Euler(0, 0, _Th);

    }
}
