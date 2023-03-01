using TakeArms.Repository;

using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

public class Repository<T> : SerializedScriptableObject where T : IRepositoryItem
{
    [ShowInInspector]
    [OdinSerialize]
    protected Dictionary<string, T> items;

    public virtual T GetItem(string id)
    {
        return items[id];
    }
}
