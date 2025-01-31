using UnityEngine;
using UnityEngine.Events;

public class SceneSetupManager : MonoBehaviour
{
    [SerializeField] bool changeGameModeOnSceneStart = true;
    [SerializeField] StringChannel onChangeGameModeChannel;
    [SerializeField] string gameModeToChangeToOnSetup;
    [SerializeField] bool changeSongOnSceneStart = true;
    [SerializeField] SongChannel requestJumpToSongChannel;
    [SerializeField] SongData songToJumpTo;
    
    [SerializeField] bool triggerOnStart = true;
    public UnityEvent onSetup;

    public void Start()
    {
        if(triggerOnStart) Setup();
    }

    public void Setup()
    {
        if(changeGameModeOnSceneStart) onChangeGameModeChannel.Raise(gameModeToChangeToOnSetup);
        if(changeSongOnSceneStart) requestJumpToSongChannel.Raise(songToJumpTo);
        onSetup.Invoke();

        // Add code here
    }
}
