using TakeArms.GameData;
using TakeArms.Repository;

using Sirenix.OdinInspector;
using UnityEngine;

namespace TakeArms.Configurations
{
    [CreateAssetMenu(fileName = "new UnitConfig", menuName = "Configurations/Unit/Default", order = 0)]
    public class UnitConfiguration : SerializedScriptableObject, IRepositoryItem
    {
        public ulong id;
        [ShowInInspector]
        public UnitData data = new UnitData();

        public GameObject prefab;

        public ulong ID => id;

        public virtual void InitObject(Transform parentObject)
        {
            Instantiate(prefab, parentObject);
        }
    }
}