using System.Collections.Generic;
using Sirenix.OdinInspector;
using Targeting;
using UnityEngine;

public class Repository<T> : ScriptableObject where T : IRepositoryItem
{
    [ShowInInspector]
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
