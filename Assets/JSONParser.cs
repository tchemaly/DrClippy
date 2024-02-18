using UnityEngine;
using System;

public class JSONParser : MonoBehaviour
{
    public GameObject educationResearchFieldNode;
    public GameObject vrResearchFieldNode;
    public GameObject llmResearchFieldNode;

    public GameObject VRText;
    public GameObject EducationText;
    public GameObject LLMText;

    public GameObject paper1Node;
    public GameObject p1Education;
    public GameObject p1VR;
    public GameObject p1LLM;

    public GameObject paper2Node;
    public GameObject p2Education;
    public GameObject p2VR;
    public GameObject p2LLM;

    public GameObject paper3Node;
    public GameObject p3Education;
    public GameObject p3VR;
    public GameObject p3LLM;

    public GameObject Paper1Text;
    public GameObject Paper2Text;
    public GameObject Paper3Text;

    

    

    

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
    }

    // The JSON string to parse
    private string jsonString =
    //    @"{
    //    ""new_connection"": [
    //        {
    //            ""node1"": ""Topic: Topics in Large Language Models (LLM)"",
    //            ""node2"": ""Title: A Survey of Large Language Models"",
    //            ""edge_exp"": ""Reviewing advancements and applications in LLMs.""
    //        },
    //        {
    //            ""node1"": ""Topic: Topics in Large Language Models (LLM)"",
    //            ""node2"": ""Title: A Survey of Large Language Models"",
    //            ""edge_exp"": ""Summarizing advancements and applications of LLMs""
    //        },
    //        {
    //            ""node1"": ""Topic: Topics in Large Language Models (LLM)"",
    //            ""node2"": ""Title: Theory of Mind May Have Spontaneously Emerged in Large Language Models\n"",
    //            ""edge_exp"": ""LLMs developing Theory of Mind capabilities""
    //        }
    //    ]
    //}";

    @"{
        ""new_connection"": [
            {
                ""node1"": ""LLM"",
                ""node2"": ""A Survey of Large Language Models"",
                ""edge_exp"": ""Reviewing advancements and applications in LLMs.""
            },
            {
                ""node1"": ""VR"",
                ""node2"": ""A Survey of VR"",
                ""edge_exp"": ""Summarizing advancements and applications of VR""
            },
            {
                ""node1"": ""Education"",
                ""node2"": ""Theory of Mind May Have Spontaneously Emerged in Education\n"",
                ""edge_exp"": ""LLMs developing Theory of Mind capabilities""
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
            foreach (Connection connection in connectionsRoot.new_connection)
            {
                Debug.Log($"Node1: {connection.node1}, Node2: {connection.node2}, Edge Explanation: {connection.edge_exp}");


            }
        }
        else
        {
            Debug.LogError("Failed to parse JSON.");
        }
    }
}
