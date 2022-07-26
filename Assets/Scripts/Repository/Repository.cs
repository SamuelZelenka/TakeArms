using System.Collections.Generic;
using UnityEngine;

public class Repository<T> : ScriptableObject
{
    [SerializeField] protected T[] serializedConfigurations;
    protected Dictionary<ulong, T> configurations;

    protected virtual T GetConfiguration(ulong id)
    {
        if (configurations?.Count == 0)
        {
            for(ulong i = 0; i < (ulong)serializedConfigurations.Length; i++)
            {
                configurations.Add(GenerateUniqueID(), serializedConfigurations[i]);
            }
        }

        T config;
        configurations.TryGetValue(id, out config);
        return config;
    }
    
    private ulong GenerateUniqueID()
    {
        for (ulong i = 0; i < ulong.MaxValue; i++)
        {
            if (!configurations.ContainsKey(i))
                return i;
        }
        Debug.LogError("Should not run out of ID's");
        return ulong.MaxValue; 
    }
}
