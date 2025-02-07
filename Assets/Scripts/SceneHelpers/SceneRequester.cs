using UnityEngine;

public class SceneRequester : MonoBehaviour
{
    public SceneData sceneData;
    public SceneChannel requestLoadNewSceneChannel;

    public void Request()
    {
        requestLoadNewSceneChannel.Raise(sceneData);
    }
}
