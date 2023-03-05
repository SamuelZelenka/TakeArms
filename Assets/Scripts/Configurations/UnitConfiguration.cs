using TakeArms.Repository;
using Sirenix.OdinInspector;
using UnityEngine;

namespace TakeArms.Configurations
{
    [CreateAssetMenu(fileName = "new UnitConfig", menuName = "Configurations/Unit/Default", order = 0)]
    public class UnitConfiguration : SerializedScriptableObject, IRepositoryItem
    {
        public string id;

        [ShowInInspector]
        //public UnitData data = new UnitData();

        public GameObject prefab;

        public string Id => id;

        public virtual void InitObject(Transform parentObject)
        {
            Instantiate(prefab, parentObject);
        }
    }
}
