using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using TakeArms.Actions;
using TakeArms.Repository;

namespace TakeArms.Configurations
{
    public class ActionCardConfiguration : SerializedScriptableObject, IRepositoryItem
    {
        private string _description;
        public string Description => _description;
        private string _cardName;
        public string CardName => _cardName;
        private Sprite _carSprite;
        public Sprite CardSprite => _carSprite;
        private ActionEvent _action;
        public ActionEvent Action => _action;

        public string Id => _cardName;
    }
}
