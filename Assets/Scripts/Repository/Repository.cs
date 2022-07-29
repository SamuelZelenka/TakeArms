using TakeArms.Repository;

using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

public class Repository<T> : SerializedScriptableObject where T : IRepositoryItem
{
    [ShowInInspector]
    [OdinSerialize]
    protected List<T> items;

    public virtual T GetItem(ulong id)
    {
        foreach (T item in items)
        {
            if (item.ID == id)
            {
                return item;
            }
        }
        Debug.LogError($"ID: {id} was not found. Returning DEFAULT");
        return default;
    }
}
