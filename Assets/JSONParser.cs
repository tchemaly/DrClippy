using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;




public class JSONParser : MonoBehaviour
{
    // Start is called before the first frame update

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


    private string jsonString = @"{
        ""new_connection"": [
            {
                ""node1"": ""Topic: Topics in Large Language Models (LLM)"",
                ""node2"": ""Title: A Survey of Large Language Models"",
                ""edge_exp"": ""Reviewing advancements and applications in LLMs.""
            },
            {
                ""node1"": ""Topic: Topics in Large Language Models (LLM)"",
                ""node2"": ""Title: A Survey of Large Language Models"",
                ""edge_exp"": ""Summarizing advancements and applications of LLMs""
            },
            {
                ""node1"": ""Topic: Topics in Large Language Models (LLM)"",
                ""node2"": ""Title: Theory of Mind May Have Spontaneously Emerged in Large Language Models\n"",
                ""edge_exp"": ""LLMs developing Theory of Mind capabilities""
            }
        ]
    }";

    void Start()
    {
        parseJSON(jsonString);
    }

    void parseJSON(string json)
    {
        ConnectionsRoot connectionsRoot = JsonUtility.FromJson<ConnectionsRoot>("{\"new_connection\":" + json + "}");
        foreach (Connection connection in connectionsRoot.new_connection)
        {
            Debug.Log($"Node1: {connection.node1}, Node2: {connection.node2}, Edge Explanation: {connection.edge_exp}");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
