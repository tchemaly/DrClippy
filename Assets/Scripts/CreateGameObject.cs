using UnityEngine;

public class CreateGameObject : MonoBehaviour
{
    public GameObject prefabToInstantiate;
    public GameObject connectionPrefab;
    public Transform spawnPoint;

    private float a=0;
    private float b=0;
    private float c=0;

    private GameObject[] spheres = new GameObject[2];
    private GameObject connectionInstance;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            InstantiateSphere();
        }

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            if (spheres[0] != null && spheres[1] != null)
            {
                InstantiateConnection();
            }
        }
    }

    void InstantiateSphere()
    {
        // Instantiate a sphere
        GameObject sphere = Instantiate(prefabToInstantiate, spawnPoint.position, Quaternion.identity);

        // Update the array of spheres with the new one
        spheres[0] = spheres[1];
        spheres[1] = sphere;

        // Update the spawn point
        // Randomly choose between positive and negative for 'a'
        if (Random.Range(0, 2) == 0) {
            // Generate random float between 0.5 and 1
            a = Random.Range(0.5f, 1f);
        } else {
            // Generate random float between -1 and -0.5
            a = Random.Range(-1f, -0.5f);
        }

        // Randomly choose between positive and negative for 'b'
        if (Random.Range(0, 2) == 0) {
            // Generate random float between 0.5 and 1
            b = Random.Range(0.5f, 1f);
        } else {
            // Generate random float between -1 and -0.5
            b = Random.Range(-1f, -0.5f);
        }

        // Randomly choose between positive and negative for 'c'
        if (Random.Range(0, 2) == 0) {
            // Generate random float between 0.5 and 1
            c = Random.Range(0.5f, 1f);
        } else {
            // Generate random float between -1 and -0.5
            c = Random.Range(-1f, -0.5f);
        }
        spawnPoint.position += new Vector3(a, b, c);
    }

    void InstantiateConnection()
    {
        // Create the connection instance
        connectionInstance = Instantiate(connectionPrefab);

        // Position the connection at the midpoint between the spheres
        Vector3 midpoint = (spheres[0].transform.position + spheres[1].transform.position) / 2f;
        connectionInstance.transform.position = midpoint;

        // Calculate the direction between the spheres
        Vector3 direction = spheres[1].transform.position - spheres[0].transform.position;

        // Rotate the connection to align with the direction
        Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);

        // Adjust the rotation by 90 degrees in the x-axis
        rotation *= Quaternion.Euler(90, 0, 0);

        // Apply the rotation to the connection
        connectionInstance.transform.rotation = rotation;

        // Scale the connection to fit the distance between the spheres
        float distance = Vector3.Distance(spheres[0].transform.position, spheres[1].transform.position);
        connectionInstance.transform.localScale = new Vector3(connectionInstance.transform.localScale.x, distance / 2f, connectionInstance.transform.localScale.z);
    }
}
