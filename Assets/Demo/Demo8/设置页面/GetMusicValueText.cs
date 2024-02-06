public class GetMusicValueText : GetUITextValue
{
    protected override void SetTextValue()
    {
        text.text = MusicManager.Instance.GetMusicValue();
    }
}