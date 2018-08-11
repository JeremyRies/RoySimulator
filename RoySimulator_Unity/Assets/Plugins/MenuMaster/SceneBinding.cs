using UnityEngine.SceneManagement;

[System.Serializable]
public struct SceneBinding
{
    public bool Unload;
    public LoadSceneMode SceneLoadingMode;
    public string buttonSignature;
    public int sceneId;
}