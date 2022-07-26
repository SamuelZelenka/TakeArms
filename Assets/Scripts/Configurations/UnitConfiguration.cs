using UnityEngine;
using Sirenix.OdinInspector;
using Targeting;

namespace Configurations
{
    [CreateAssetMenu(fileName = "new UnitConfig", menuName = "Configurations/Unit/Default", order = 0)]
    public class UnitConfiguration : ScriptableObject, IRepositoryItem
    {
        public ulong id;
        [ShowInInspector]
        public UnitData data = new UnitData();

        public ulong ID
        {
            get { return id; }
        }
    }
}