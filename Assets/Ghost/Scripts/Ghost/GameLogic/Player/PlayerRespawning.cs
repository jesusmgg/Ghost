using System.Collections;
using System.Linq;
using Ghost.Props;
using Ghost.Stats;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Ghost.GameLogic.Player
{
    public class PlayerRespawning : MonoBehaviour
    {
        public ParticleSystem deathParticles;
        public ParticleSystem spawnParticles;
        
        PlayerActions playerActions;
        PlayerStats stats;
        
        public UnityEvent onRespawn = new UnityEvent();

        void Start()
        {
            playerActions = GetComponent<PlayerActions>();
            stats = GetComponent<PlayerStats>();
            
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        void Update()
        {
            if (stats.isDead)
            {
                StartCoroutine(Respawn());
            }
        }
        
        void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
        {
            PlayerSpawn playerSpawn = FindObjectsOfType<PlayerSpawn>().FirstOrDefault(x =>
                x.gameObject.scene == scene && x.portalDirection == stats.GetOppositeDirection());

            if (playerSpawn == null)
            {
                playerSpawn = FindObjectsOfType<PlayerSpawn>().FirstOrDefault(x => x.gameObject.scene == scene);
            }
            
            if (playerSpawn != null)
            {
                transform.position = playerSpawn.transform.position;
            }
        }

        IEnumerator Respawn()
        {
            Vector2 respawnPosition = Vector2.zero;
            
            if (playerActions.currentCheckpoint != null)
            {
                respawnPosition = playerActions.currentCheckpoint.transform.position;
            }
            
            else
            {
                PlayerSpawn playerSpawn = FindObjectsOfType<PlayerSpawn>()
                    .FirstOrDefault(x => x.portalDirection == stats.GetOppositeDirection());
                
                if (playerSpawn == null)
                {
                    playerSpawn = FindObjectsOfType<PlayerSpawn>().FirstOrDefault();        
                }
                
                if (playerSpawn != null)
                {
                    respawnPosition = playerSpawn.transform.position;
                }
            }
            
            deathParticles.Play();
            yield return new WaitForSeconds(0.5f);
            transform.position = respawnPosition;
            spawnParticles.Play();
                
            onRespawn.Invoke();
        }
    }
}