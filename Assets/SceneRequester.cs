using UnityEngine;

public class SceneRequester : MonoBehaviour
{
    public string SceneToRequest;
    public StringChannel requestLoadNewSceneChannel;

    public void Request()
    {
        requestLoadNewSceneChannel.Raise(SceneToRequest);
    }
}
