using UnityEngine;
using System;
using System.Collections.Generic;
using TMPro;

public class JSONParser : MonoBehaviour
{
    public GameObject educationResearchFieldNode;
    public GameObject vrResearchFieldNode;
    public GameObject llmResearchFieldNode;

    public GameObject EducationText;
    public GameObject VRText;
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

    private string paper1title = "";
    private string paper2title = "";
    private string paper3title = "";
    

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
            foreach (Connection connection in connectionsRoot.new_connection) //checking for the field research nodes
            {
                Debug.Log($"Node1: {connection.node1}, Node2: {connection.node2}, Edge Explanation: {connection.edge_exp}");

                if (connection.node1 == "Education")
                {
                    educationResearchFieldNode.SetActive(true);
                    EducationText.SetActive(true);

                    //if (paper1title == "")
                    //{
                    //    paper1title = connection.node2;
                    //    p1Education.SetActive(true);
                    //    Paper1Text.SetActive(true);
                    //    TextMeshPro paper1NodeText = Paper1Text.GetComponent<TextMeshPro>();
                    //    paper1NodeText.text = paper1title;
                    //    paper1Node.SetActive(true);

                    //}
                    //else if (paper2title == "")
                    //{
                    //    paper2title = connection.node2;
                    //    p2Education.SetActive(true);
                    //    Paper2Text.SetActive(true);
                    //    TextMeshPro paper2NodeText = Paper2Text.GetComponent<TextMeshPro>();
                    //    paper2NodeText.text = paper2title;
                    //    paper2Node.SetActive(true);
                    //}
                    //else if (paper3title == "") {
                    //    paper3title = connection.node2;
                    //    p3Education.SetActive(true);
                    //    Paper3Text.SetActive(true);
                    //    TextMeshPro paper3NodeText = Paper3Text.GetComponent<TextMeshPro>();
                    //    paper3NodeText.text = paper3title;
                    //    paper3Node.SetActive(true);
                    //}
                }
                else if (connection.node1 == "VR")
                {
                    vrResearchFieldNode.SetActive(true);
                    VRText.SetActive(true);


                    //if (paper1title == "")
                    //{
                    //    paper1title = connection.node2;
                    //    p1VR.SetActive(true);
                    //    Paper1Text.SetActive(true);
                    //    TextMeshPro paper1NodeText = Paper1Text.GetComponent<TextMeshPro>();
                    //    paper1NodeText.text = paper1title;
                    //    paper1Node.SetActive(true);

                    //}
                    //else if (paper2title == "")
                    //{
                    //    paper2title = connection.node2;
                    //    p2VR.SetActive(true);
                    //    Paper2Text.SetActive(true);
                    //    TextMeshPro paper2NodeText = Paper2Text.GetComponent<TextMeshPro>();
                    //    paper2NodeText.text = paper2title;
                    //    paper2Node.SetActive(true);
                    //}
                    //else if (paper3title == "")
                    //{
                    //    paper3title = connection.node2;
                    //    p3LLM.SetActive(true);
                    //    Paper3Text.SetActive(true);
                    //    TextMeshPro paper3NodeText = Paper3Text.GetComponent<TextMeshPro>();
                    //    paper3NodeText.text = paper3title;
                    //    paper3Node.SetActive(true);
                    //}


                }
                else if (connection.node1 == "LLM")
                {
                    llmResearchFieldNode.SetActive(true);
                    LLMText.SetActive(true);
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
}
