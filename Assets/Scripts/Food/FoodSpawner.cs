using DefaultNamespace;
using UnityEngine;
using Random = UnityEngine.Random;

public class FoodSpawner : MonoBehaviour
{
    [Header("Food")]
    [SerializeField] private Transform foodParent;
    [SerializeField] private GameObject foodPrefab;
    [SerializeField] private Vector2 foodCountRange;
    [SerializeField] private Planet planet;
    
    [Header("Planet")]
    [SerializeField] private Transform planetTransform;
    private Vector3 _planetSize;
    private Bounds _planetBounds;
    [SerializeField] private SphereCollider _sphereCollider;
    private float _radius;
     
    private void Awake()
    {
        _planetBounds = planetTransform.GetComponent<MeshCollider>().bounds;
        _planetSize = _planetBounds.size;
        
        var randomCount = Random.Range(foodCountRange.x, foodCountRange.y);
        
        for (int i = 0; i < randomCount; i++) RandomSpawn();
        _radius = _sphereCollider.radius;
    }

    public void RandomSpawn()
    {
        if (!foodPrefab) return;
        
        
        var prefab = Instantiate(foodPrefab, foodParent, true);
        prefab.GetComponent<GravityBody>().attractorPlanet = planet;
        prefab.transform.position = GetRandomPointOnSphereSurface(_radius);
        
    }

    public static Vector3 GetRandomPointOnSphereSurface(float radius)
    {
        // Generate random spherical coordinates (azimuth and polar angle)
        float azimuth = Random.Range(0f, 2f * Mathf.PI);
        float polar = Random.Range(0f, Mathf.PI);

        // Convert spherical coordinates to Cartesian coordinates
        float x = radius * Mathf.Sin(polar) * Mathf.Cos(azimuth);
        float y = radius * Mathf.Sin(polar) * Mathf.Sin(azimuth);
        float z = radius * Mathf.Cos(polar);

        return new Vector3(x, y, z);
    }
}
