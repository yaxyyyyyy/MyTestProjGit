using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Pool;

public class Pool : MonoBehaviour, IPool
{
    [SerializeField] private int _size;
    [SerializeField] private ItemInPool _prefab;
    [SerializeField] private Transform _container;

    private List<ItemInPool> _pool;

    public void CreatePool(int size)
    {
        _size = size;
        _pool = new List<ItemInPool>(_size);
        for (int i = 0; i < _size; i++) { CreateObjectInPool(i); }
    }

    public IItemInPool CreateObjectInPool(int numberName)
    {
        var newObj = GameObject.Instantiate(_prefab.GetGameObject(), _container);
        var answer = newObj.GetComponent<ItemInPool>();
        answer.InstantinatePoolObj("_" + numberName);
        _pool.Add(answer);
        return answer;
    }

    public IItemInPool GetPoolObj()
    {
        var answer = _pool.Where(x => !x.GetGameObject().activeSelf).FirstOrDefault();
        if (answer == null)
        {
            _size++;
            answer = (ItemInPool)CreateObjectInPool(_size++);
        }
        return answer;
    }

    private void Start()
    {
        CreatePool(_size);
    }



    public void TestBtnGetPoolObj()
    {
        ((ItemInPool)GetPoolObj()).ExitFromPool(Vector3.up);
        //GetPoolObj().ExitFromPool();
    }
}

public interface IPool
{

    void CreatePool(int size);

    IItemInPool CreateObjectInPool(int numberName);

    IItemInPool GetPoolObj();

    private void Start()
    {
        CreatePool(0);
    }

    //public void TestBtnGetPoolObj()
    //{
    //    //GetPoolObj().ExitFromPool(Vector3.up);
    //    GetPoolObj().ExitFromPool();
    //}
}

