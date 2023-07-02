using UnityEngine;
using TMPro;

public class LobbyUI : MonoBehaviour
{
    [Space]
    [SerializeField] private LobbyManager _launcher;
    [Header("Input Panels")]
    [SerializeField] private InputNamePanelUI _playerNameInput;
    [SerializeField] private InputNamePanelUI _newGameNameInput;
    [SerializeField] private InputNamePanelUI _joinGameNameInput;

    [Header("Titles")]
    [SerializeField] private TextMeshProUGUI _playerNameText;

    private void Start()
    {
        _playerNameInput.OnNameAcceptedEvent += _launcher.SaveNickName;
        _newGameNameInput.OnNameAcceptedEvent += _launcher.CreateRoom;
        _joinGameNameInput.OnNameAcceptedEvent += _launcher.JoinRoom;

        _launcher.OnNickNameChangeEvent += UpdateNickName;
    }

    private void UpdateNickName(string name)
    {
        _playerNameText.text = name;
    }

    


}
