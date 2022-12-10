using TakeArms.Repository;

using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

public class Repository<T> : SerializedScriptableObject where T : IRepositoryItem
{
    [ShowInInspector]
    [OdinSerialize]
    protected Dictionary<int, T> items;

    public virtual T GetItem(int id)
    {
        T item = items[id];
        Debug.LogError($"ID: {id} was not found. Returning DEFAULT");
        return default;
    }
}
