public class GetLanguageType : GetUITextValue
{
    protected override void SetTextValue()
    {
        text.text = LanguageManager.Instance.GetLanguageTypeName();
    }
}