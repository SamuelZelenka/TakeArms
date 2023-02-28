using TakeArms.Configurations;

using UnityEngine;

namespace TakeArms.Targeting
{
    [CreateAssetMenu(fileName = "new UnitRepository", menuName = "Repository/Unit Repository", order = 0)]
    public class UnitRepository : Repository<UnitConfiguration>
    {
    }
    
}