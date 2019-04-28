using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Ghost.Props.Interactable
{
    public class LevelPortal : BaseInteractableObject
    {
        [Header("Level portal")]
        public string targetLevel;

        public override void Interact()
        {
            Debug.Log($"Changing level: from {gameObject.scene.name} to {targetLevel}.");
            StartCoroutine(DoChangeLevel());
        }

        IEnumerator DoChangeLevel()
        {
            yield return SceneManager.LoadSceneAsync(targetLevel, LoadSceneMode.Additive);
            SceneManager.UnloadSceneAsync(gameObject.scene);
        }
    }
}