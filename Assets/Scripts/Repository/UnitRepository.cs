using System.Collections.Generic;
using Configurations;
using Sirenix.Serialization;
using UnityEngine;

namespace Targeting
{
    [CreateAssetMenu(fileName = "new UnitRepository", menuName = "Repository/Unit Repository", order = 0)]
    public class UnitRepository : Repository<UnitConfiguration>
    {
    }
    
}