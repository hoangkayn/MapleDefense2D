using UnityEngine;


public abstract class SpawnerCtrl : BaseMonoBehaviour
{
    [SerializeField] protected Transform spawnPoint;
    public Transform SpawnPoint => spawnPoint;
    [SerializeField] protected Spawner spawner;
    public Spawner Spawner => spawner;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawnPoint();
        this.LoadSpawner();
    }
    protected abstract void LoadSpawnPoint();
   
    protected virtual void LoadSpawner()
    {
        if (spawner != null) return;
        spawner = transform.GetComponent<Spawner>();
    }
}
