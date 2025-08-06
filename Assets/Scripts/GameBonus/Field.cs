using UnityEngine;

public class Field : Bonus, IRemovable
{
    private GlassField _glassField;

    private void OnEnable()
    {
        if (_glassField == null)
        {
            _glassField = FindFirstObjectByType<GlassField>();
        }
    }
    public override void Apply()
    {
        _glassField.SetActive(true);
        StartTimer();
    }

    public void Remove()
    {
        _glassField.SetActive(false);
    }

}
