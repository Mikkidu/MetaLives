using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InputNamePanelUI : MonoBehaviour
{
    [SerializeField] private TMP_InputField _inputText;

    public delegate void  OnNameAccepted(string name);
    public OnNameAccepted OnNameAcceptedEvent;

    public Button _acceptButton;


    public void OnButtonClick()
    {
        if (OnNameAcceptedEvent != null)
            OnNameAcceptedEvent.Invoke(_inputText.text);
    }

    public void CheckInputField(string name)
    {
        if (string.IsNullOrEmpty(name) == _acceptButton.interactable)
        {
            _acceptButton.interactable = !_acceptButton.interactable;
        }
    }
}
