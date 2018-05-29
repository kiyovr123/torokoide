using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torokoide : MonoBehaviour
{

    [SerializeField]
    private LineRenderer _LR;

    private Vector3[] _Vert;

    private void Start()
    {
        InitLineRenderer();
        InitVertex();
        Create(5, 3, 5);
        SetVertex();
    }

    private void InitLineRenderer()
    {
        this._LR = this.GetComponent<LineRenderer>();
    }

    private void InitVertex()
    {
        _Vert = new Vector3[1440];
    }

    private void Create(float rc, float rm, float rd)
    {
        float th = Mathf.PI / 45f;
        float r1 = rc - rm;
        float r2 = r1 / rm;

        for (int i = 0; i < _Vert.Length; i++)
        {
            float x = r1 * Mathf.Cos(th * i) + rd * Mathf.Cos(r2 * th * i);
            float y = r1 * Mathf.Sin(th * i) - rd * Mathf.Sin(r2 * th * i);
            _Vert[i] = new Vector3(x, y, 0);

        }
    }

    private void SetVertex()
    {
        _LR.positionCount = this._Vert.Length;
        _LR.SetPositions(_Vert);
    }

    private void Change()
    {
        Create(Random.Range(1f,7f), Random.Range(1f, 7f), Random.Range(1f, 7f));
        SetVertex();
        _LR.startColor = new Color(Random.Range(0.3f, 1f), Random.Range(0.3f, 1f), Random.Range(0.3f, 1f),0.5f);
        _LR.endColor = _LR.startColor;

    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Change();
        }
    }
}
