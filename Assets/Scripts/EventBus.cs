using System;

public class EventBus
{
    public Action<string> OnCallLoadScene;
    public Action<string> OnStartLoadScene;
    public Action<string> OnLoadScene;
    public Action OnClickNextButton;
    public Action OnClickRestartButton;
    public Action OnClickSettingsButton;
    public Action OnClickCloseSettingButton;
}
