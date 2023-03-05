using System;
using TakeArms.Configurations;
using UnityEngine;

namespace TakeArms.Repository
{
    [Serializable]
    [CreateAssetMenu(fileName = "new ActionCard Repository", menuName = "Repository/Action Card Repository", order = 0)]
    public class ActionCardRepository : Repository<ActionCardConfiguration>
    {

    }
}
