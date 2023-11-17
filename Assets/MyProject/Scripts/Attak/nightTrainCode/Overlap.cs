using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class Overlap
{
    [SerializeField] private LayerMask _searchMask;
    [SerializeField] private Transform _overlapPoint;

    //[SerializeField] private string _overlaptype;
    //[SerializeField] private Vector3 _boxSize = Vector3.one;
    [SerializeField] private float _sphereRadius = 0.5f;

    [SerializeField] private Vector3 _positionOffset;

    //[SerializeField] private bool _considerObscales;
    //[SerializeField] private LayerMask _obscalehMask;

    [SerializeField] public int Size;

    public Collider[] OverlapResulits = new Collider[32];

    public LayerMask LayerMask => _searchMask;

    public void SetRadius(float radius) { _sphereRadius = radius; }

    public List<Collider> TryFind()
    {
        Size = OverlapSphere(_overlapPoint.TransformPoint(_positionOffset));
        if (Size > 0)
        {
            var answer = OverlapResulits.ToList();
            return answer;
        }
        return null;
    }


    public int OverlapSphere(Vector3 position)
    {
        //побочный эффект - запись коллайдеров в массив
        return Physics.OverlapSphereNonAlloc(position, _sphereRadius, OverlapResulits, _searchMask.value);
    }
}
