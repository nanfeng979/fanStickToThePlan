public class GetSoundValueText : GetUITextValue
{
    protected override void SetTextValue()
    {
        text.text = SoundManager.Instance.GetSoundValue().ToString();
    }
}
