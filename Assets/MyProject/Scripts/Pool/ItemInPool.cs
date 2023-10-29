using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInPool : MonoBehaviour,IItemInPool
{

    public void InstantinatePoolObj()
    {
        //при первом заполнении пула
        gameObject.transform.position = Vector3.zero;
        gameObject.SetActive(false);

    }
    public void InstantinatePoolObj(string addName)
    {
        gameObject.name += addName;
        InstantinatePoolObj();
    }

    public void EntryToPool()
    {
        //возвращение в пул
        gameObject.transform.position = Vector3.zero;
        gameObject.SetActive(false);
    }


    public void ExitFromPool()
    {
        //вместо спавна обьекта
        gameObject.SetActive(true);
    }
    public void ExitFromPool(Vector3 coordSpawn)
    {
        gameObject.transform.position = coordSpawn;
        ExitFromPool();
    }

    public GameObject GetGameObject()
    {
        return gameObject;
    }
}

public interface IItemInPool
{

    public GameObject GetGameObject();

    /// <summary>
    /// при генерации пула
    /// и при добавлении новых(если существующих будет нехватать)
    /// </summary>
    public void InstantinatePoolObj();

    /// <summary>
    /// возвращение в пул
    /// вместо Destroy
    /// </summary>
    public void EntryToPool();


    /// <summary>
    /// достаём из пула
    /// вместо Instantinate обьекта
    /// </summary>
    public void ExitFromPool();
}
