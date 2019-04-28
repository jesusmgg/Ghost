using System.Linq;
using Ghost.Input;
using Ghost.Props;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Ghost.Mechanics.Player
{
    public class Teleporter : MonoBehaviour
    {
        public GameObject teleportMarkerPrefab;

        public GameObject currentMarker;
        
        PlayerInput playerInput;
        
        void Start()
        {
            playerInput = GetComponent<PlayerInput>();
            
            SceneManager.sceneLoaded += OnSceneLoaded;

            currentMarker = null;
        }

        void Update()
        {
            if (playerInput.GetButtonDown("Fire1") && Mathf.Abs(playerInput.Direction.y) < Mathf.Epsilon)
            {
                if (currentMarker == null)
                {
                    currentMarker = Instantiate(teleportMarkerPrefab, transform.position, transform.rotation);
                }
                else
                {
                    transform.position = currentMarker.transform.position;
                    Destroy(currentMarker);
                }
            }
        }
        
        void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
        {
            Destroy(currentMarker);
            currentMarker = null;
        }
    }
}