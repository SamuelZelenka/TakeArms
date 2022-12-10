using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using TakeArms.Services;

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

    private Dictionary<int, PlayerUI> _playerUIs = new Dictionary<int, PlayerUI>();

    private void Start()
    {
        GameSystemService.PlayerSystem.OnPlayerRemoved += RemovePlayerUI;
    }

    public void AddPlayerUI(int playerID)
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
