using UnityEngine;
using UnityEngine.UI;

public class AudioButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [Space]
    [SerializeField] private Color _enableColor;
    [SerializeField] private Color _disableColor;
    [Space]
    [SerializeField] private Image _icon;
    [Space]
    [SerializeField] private Sprite _enableSprite;
    [SerializeField] private Sprite _disableSprite;
    private bool _isEnable;

    public void SetState (bool value)
    {
        _isEnable = value;
        Changed();
    }

    public void Change()
    {
        _isEnable = !_isEnable;
        Changed();
    }
    private void Changed()
    {
        _button.image.color = _isEnable ? _enableColor : _disableColor;
        _icon.sprite = _isEnable ? _enableSprite : _disableSprite;

    }
}
