

public class BtnOpenPlayScene : BaseButton
{
    protected override void OnClick()
    {
        SceneLoader.Instance.LoadScene("MainGame");
    }
}
