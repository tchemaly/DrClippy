using UnityEngine;
using System;
using System.Collections.Generic;
using TMPro;

public class JSONParserEdit : MonoBehaviour
{

    public GameObject ParentModel;
    public GameObject educationResearchFieldNode;
    public GameObject vrResearchFieldNode;
    public GameObject llmResearchFieldNode;

    public GameObject EducationText;
    public GameObject VRText;
    public GameObject LLMText;

    public GameObject prefabToInstantiate;
    public GameObject connectionPrefab;
    private Transform spawnPoint;

    private float a=0;
    private float b=0;
    private float c=0;

    private GameObject[] spheres = new GameObject[2];
    private GameObject connectionInstance;

    private Dictionary<string, Vector3> papersDictionary = new Dictionary<string, Vector3>();

    private Vector3 sphere1pos=new Vector3(0f,0f,0f);

    [Serializable]
    public class ConnectionsRoot
    {
        public Connection[] new_connection;
    }

    [Serializable]
    public class Connection
    {
        public string node1;
        public string node2;
        public string edge_exp;
        public string type;
    }

    // The JSON string to parse
    private string jsonString =

    @"{
    ""new_connection"": [
        {
            ""node1"": ""LLM"",
            ""node2"": ""Large Language Models: A Comprehensive Survey of its Applications, Challenges, Limitations, and Future Prospects"",
            ""edge_exp"": ""VR in enhancing remote and medical education"",
            ""type"": ""p2f""
        },
        {
            ""node1"": ""LLM"",
            ""node2"": ""Theory of Mind May Have Spontaneously Emerged in Large Language Models"",
            ""edge_exp"": ""VR technology enhancing remote higher education experiences"",
            ""type"": ""p2f""
        },
        {
            ""node1"": ""LLM"",
            ""node2"": ""The Future Landscape of Large Language Models in Medicine"",
            ""edge_exp"": ""VR technology enhancing remote higher education engagement"",
            ""type"": ""p2f""
        },
        {
            ""node1"": ""Education"",
            ""node2"": ""Analyzing augmented reality (AR) and virtual reality (VR) recent development in education"",
            ""edge_exp"": ""VR technology enhancing remote higher education experiences"",
            ""type"": ""p2f""
        },
        {
            ""node1"": ""Education"",
            ""node2"": ""Augmented reality and virtual reality displays: emerging technologies and future perspectives"",
            ""edge_exp"": ""VR technology enhancing remote higher education."",
            ""type"": ""p2f""
        },
        {
            ""node1"": ""Education"",
            ""node2"": ""Augmented Reality in Education: An Overview of Twenty-Five Years of Research"",
            ""edge_exp"": ""VR technology enhancing remote higher education learning experiences"",
            ""type"": ""p2f""
        },
        {
            ""node1"": ""VR"",
            ""node2"": ""Augmented Reality and Virtual Reality Displays: Emerging Technologies and Future Perspectives"",
            ""edge_exp"": ""Enhancing remote education through VR technology"",
            ""type"": ""p2f""
        },
        {
            ""node1"": ""VR"",
            ""node2"": ""A Review of the Application of Virtual Reality Technology in Higher Education"",
            ""edge_exp"": ""Enhancing remote education through VR innovations"",
            ""type"": ""p2f""
        },
        {
            ""node1"": ""VR"",
            ""node2"": ""Research Into Improved Distance Learning Using VR Technology"",
            ""edge_exp"": ""VR technology enhancing remote and medical education."",
            ""type"": ""p2f""
        },
        {
            ""node1"": ""VR"",
            ""node2"": ""Analyzing augmented reality (AR) and virtual reality (VR) recent development in education"",
            ""edge_exp"": ""VR technology enhancing remote higher education."",
            ""type"": ""p2f""
        },
        {
            ""node1"": ""VR"",
            ""node2"": ""Augmented reality and virtual reality displays: emerging technologies and future perspectives"",
            ""edge_exp"": ""VR technology enhancing remote higher education experiences"",
            ""type"": ""p2f""
        },
        {
            ""node1"": ""VR"",
            ""node2"": ""Augmented Reality in Education: An Overview of Twenty-Five Years of Research"",
            ""edge_exp"": ""VR technology enhancing remote higher education experiences."",
            ""type"": ""p2f""
        },
        {
            ""node1"": ""Large Language Models: A Comprehensive Survey of its Applications, Challenges, Limitations, and Future Prospects"",
            ""node2"": ""The Future Landscape of Large Language Models in Medicine"",
            ""edge_exp"": ""VR technology enhancing remote higher education experiences"",
            ""type"": ""p2p""
        },
        {
            ""node1"": ""Analyzing augmented reality (AR) and virtual reality (VR) recent development in education"",
            ""node2"": ""Augmented reality and virtual reality displays: emerging technologies and future perspectives"",
            ""edge_exp"": ""VR technology enhancing remote higher education experiences"",
            ""type"": ""p2p""
        },
        {
            ""node1"": ""Analyzing augmented reality (AR) and virtual reality (VR) recent development in education"",
            ""node2"": ""Augmented Reality in Education: An Overview of Twenty-Five Years of Research"",
            ""edge_exp"": ""Enhancing remote education through VR technology"",
            ""type"": ""p2p""
        },
        {
            ""node1"": ""Analyzing augmented reality (AR) and virtual reality (VR) recent development in education"",
            ""node2"": ""A Review of the Application of Virtual Reality Technology in Higher Education"",
            ""edge_exp"": ""Enhancing remote education through VR immersion"",
            ""type"": ""p2p""
        },
        {
            ""node1"": ""Analyzing augmented reality (AR) and virtual reality (VR) recent development in education"",
            ""node2"": ""Research Into Improved Distance Learning Using VR Technology"",
            ""edge_exp"": ""VR enhancing remote and higher education experiences"",
            ""type"": ""p2p""
        },
        {
            ""node1"": ""Augmented reality and virtual reality displays: emerging technologies and future perspectives"",
            ""node2"": ""Augmented Reality in Education: An Overview of Twenty-Five Years of Research"",
            ""edge_exp"": ""VR enhancing distance and higher education experiences"",
            ""type"": ""p2p""
        },
        {
            ""node1"": ""Augmented reality and virtual reality displays: emerging technologies and future perspectives"",
            ""node2"": ""Augmented Reality and Virtual Reality Displays: Emerging Technologies and Future Perspectives"",
            ""edge_exp"": ""Leveraging VR for enhanced remote higher education"",
            ""type"": ""p2p""
        },
        {
            ""node1"": ""Augmented reality and virtual reality displays: emerging technologies and future perspectives"",
            ""node2"": ""Research Into Improved Distance Learning Using VR Technology"",
            ""edge_exp"": ""VR technology enhancing remote higher education experiences"",
            ""type"": ""p2p""
        },
        {
            ""node1"": ""A Review of the Application of Virtual Reality Technology in Higher Education"",
            ""node2"": ""Research Into Improved Distance Learning Using VR Technology"",
            ""edge_exp"": ""VR technology enhancing remote higher education experiences"",
            ""type"": ""p2p""
        }
    ]
}";

    void Start()
    {
        ParseJSON(jsonString);
    }

    void ParseJSON(string json)
    {
        // Ensure the correct JSON structure is being used for deserialization
        ConnectionsRoot connectionsRoot = JsonUtility.FromJson<ConnectionsRoot>(json);
        if (connectionsRoot != null && connectionsRoot.new_connection != null)
        {
            foreach (Connection connection in connectionsRoot.new_connection) //checking for the field research nodes
            {
                Debug.Log($"Node1: {connection.node1}, Node2: {connection.node2}, Edge Explanation: {connection.edge_exp}, Type: {connection.type}");

                if(connection.type=="p2f"){
                  // activate field
                  if (connection.node1 == "Education")
                  {
                      educationResearchFieldNode.SetActive(true);
                      EducationText.SetActive(true);
                      sphere1pos=educationResearchFieldNode.transform.position;

                  }
                  else if (connection.node1 == "VR")
                  {
                      vrResearchFieldNode.SetActive(true);
                      VRText.SetActive(true);
                      sphere1pos=vrResearchFieldNode.transform.position;

                  }
                  else if (connection.node1 == "LLM")
                  {
                      llmResearchFieldNode.SetActive(true);
                      LLMText.SetActive(true);
                      sphere1pos=llmResearchFieldNode.transform.position;
                      Debug.Log(sphere1pos);
                  }

                  // check if paper exists
                  // if paper exists just create connection
                  if (papersDictionary.ContainsKey(connection.node2))
                  {
                      Vector3 sphere2pos = papersDictionary[connection.node2];
                      InstantiateConnection(sphere1pos,sphere2pos);
                  }

                  // if paper does not exist create node and connection
                  else
                  {
                      Debug.Log(sphere1pos);
                      Vector3 sphere2pos = InstantiateSphere(sphere1pos);
                      InstantiateConnection(sphere1pos,sphere2pos);
                  }
                }
                else if(connection.type=="p2p"){
                  // paper definitely exists
                  // just create connection
                  Vector3 sphere1pos = papersDictionary[connection.node1];
                  Vector3 sphere2pos = papersDictionary[connection.node2];
                  InstantiateConnection(sphere1pos,sphere2pos);
                }

            }

            //foreach (Connection connection in connectionsRoot.new_connection) //checking for
            //{




            //}
        }
        else
        {
            Debug.LogError("Failed to parse JSON.");
        }
    }

    Vector3 InstantiateSphere(Vector3 spawnPointPosition)
    {
        // Update the spawn point
        // Randomly choose between positive and negative for 'a'
        if (UnityEngine.Random.Range(0, 2) == 0) {
            // Generate random float between 0.5 and 1
            a = UnityEngine.Random.Range(0.5f, 1f);
        } else {
            // Generate random float between -1 and -0.5
            a = UnityEngine.Random.Range(-1f, -0.5f);
        }

        // Randomly choose between positive and negative for 'b'
        if (UnityEngine.Random.Range(0, 2) == 0) {
            // Generate random float between 0.5 and 1
            b = UnityEngine.Random.Range(0.5f, 1f);
        } else {
            // Generate random float between -1 and -0.5
            b = UnityEngine.Random.Range(-1f, -0.5f);
        }

        // Randomly choose between positive and negative for 'c'
        if (UnityEngine.Random.Range(0, 2) == 0) {
            // Generate random float between 0.5 and 1
            c = UnityEngine.Random.Range(0.5f, 1f);
        } else {
            // Generate random float between -1 and -0.5
            c = UnityEngine.Random.Range(-1f, -0.5f);
        }
        // Update the spawn point position
        Vector3 newPosition = spawnPointPosition + new Vector3(a, b, c);

        // Instantiate a sphere
        GameObject sphere = Instantiate(prefabToInstantiate, newPosition, Quaternion.identity);

        sphere.transform.parent = ParentModel.transform;

        Debug.Log(spawnPointPosition);
        Debug.Log(newPosition);
        Debug.Log(a);
        Debug.Log(b);
        Debug.Log(c);

        return newPosition;
    }

    void InstantiateConnection(Vector3 position1, Vector3 position2)
    {
        Debug.Log(position1);
        Debug.Log(position2);

        // Create the connection instance
        GameObject connectionInstance = Instantiate(connectionPrefab);

        // Position the connection at the midpoint between the spheres
        Vector3 midpoint = (position1 + position2) / 2f;
        connectionInstance.transform.position = midpoint;

        // Calculate the direction between the spheres
        Vector3 direction = position2 - position1;

        // Rotate the connection to align with the direction
        Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);

        // Adjust the rotation by 90 degrees in the x-axis
        rotation *= Quaternion.Euler(90, 0, 0);

        // Apply the rotation to the connection
        connectionInstance.transform.rotation = rotation;

        // Scale the connection to fit the distance between the spheres
        float distance = Vector3.Distance(position1, position2);
        connectionInstance.transform.localScale = new Vector3(connectionInstance.transform.localScale.x, distance / 2f, connectionInstance.transform.localScale.z);
        connectionInstance.transform.parent = ParentModel.transform;
    }
}
