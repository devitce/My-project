using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerFactory : MonoBehaviour
{
    [SerializeField]
    private Raycaster raycaster;
    [SerializeField]
    private Player playerPrefab;
    [SerializeField]
    private Enemy enemyPrefab;
    [SerializeField]
    private Transform spawnTarget;
    [SerializeField]
    private LayerMask groundLayer;
    

    private Player player;
    private List<Enemy> enemies = new List<Enemy>();

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SpawnPlayer(2, spawnTarget.position, groundLayer);
        }
    }

    public Player GetPlayer()
    {
        return player;
    }

    public void DeletePlayer()
    {
        Destroy(player.gameObject);
    }

    public void SpawnPlayer(float delay, Vector3 position, LayerMask areaMask)
    {
        if (player != null) DeletePlayer();
        IEnumerator govno()
        {
            yield return new WaitForSeconds(delay);

            player = Spawn(position, areaMask, playerPrefab);
            player.SetRaycaster(raycaster);
        }
        StartCoroutine(govno());
    }

    private T Spawn<T>(Vector3 position, LayerMask areaMask, T unitPrefab) where T: Unit 
    {
        T unit = Instantiate(unitPrefab); 
        NavMesh.SamplePosition(position, out NavMeshHit navMeshHit, Mathf.Infinity, areaMask);
        unit.MeshAgent.Warp(navMeshHit.position);
        return unit;
    }

    public void SpawnEnemy(Vector3 position, LayerMask areaMask)
    {
        enemies.Add(Spawn(position, areaMask, enemyPrefab));
    }
}