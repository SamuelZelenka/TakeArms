using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using TakeArms.Services;
using TakeArms.Gameplay;
using TakeArms.UI;

namespace TakeArms.Systems
{
    public class GameUISystem : MonoBehaviour
    {
        [BoxGroup("Prefab")]
        [SerializeField]
        private PlayerUI _uiPrefab;

        [BoxGroup("Canvas references")]
        [SerializeField]
        private GameObject _gameCanvas;

        public GameObject gameCanvas => _gameCanvas;

        [BoxGroup("Canvas references")]
        [SerializeField]
        private CardSelection _cardSelection;
        public CardSelection CardSelection => _cardSelection;

        private Dictionary<ulong, PlayerUI> _playerUIs = new Dictionary<ulong, PlayerUI>();

        private void Start()
        {
            GameSystemService.PlayerSystem.OnPlayerRemoved += RemovePlayerUI;
        }

        public void AddPlayerUI(ulong playerID)
        {
            var playerUI = Instantiate(_uiPrefab, _gameCanvas.transform);
            _playerUIs.Add(playerID, playerUI);
        }

        public void RemovePlayerUI(Player player)
        {
            Destroy(_playerUIs[player.PlayerID].gameObject);
            _playerUIs.Remove(player.PlayerID);
        }
    }
}
