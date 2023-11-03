using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Pool;

public class Pool : MonoBehaviour, IPool
{
    [SerializeField] protected int _size;
    [SerializeField] private ItemInPool _prefab;
    [SerializeField] private Transform _container;

    protected List<ItemInPool> _pool;

    public void CreatePool(int size)
    {
        _size = size;
        _pool = new List<ItemInPool>(_size);
        for (int i = 0; i < _size; i++) { CreateItemInPool(i); }
    }

    public IItemInPool CreateItemInPool(int numberName)
    {
        _container = _container == null ? gameObject.transform : _container;

        var newObj = GameObject.Instantiate(_prefab.GetGameObject(), _container);
        var answer = newObj.GetComponent<ItemInPool>();
        answer.InstantinatePoolObj("_" + numberName);
        _pool.Add(answer);
        answer.EntryToPool();
        return answer;
    }

    public IItemInPool GetItemInPool()
    {
        var answer = _pool.Where(x => !x.GetGameObject().activeSelf).FirstOrDefault();
        if (answer == null)
        {
            _size++;
            answer = (ItemInPool)CreateItemInPool(_size++);
        }
        return answer;
    }
    public ItemInPool GetRealItemInPool() => (ItemInPool)GetItemInPool();

    private void Start()
    {
        CreatePool(_size);
    }



    public void TestBtnGetPoolObj()
    {
        ((ItemInPool)GetItemInPool()).ExitFromPool(Vector3.up);
    }
}

public interface IPool
{

    void CreatePool(int size);

    IItemInPool CreateItemInPool(int numberName);

    IItemInPool GetItemInPool();

    private void Start()
    {
        CreatePool(0);
    }

}

