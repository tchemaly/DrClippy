using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Net;
using System.Threading;
using System.IO;
using TMPro;

public class SimpleHttpServer : MonoBehaviour
{
    private HttpListener listener;
    private Thread listenerThread;
    public GameObject selectMode;
    public GameObject level1;
    public GameObject level2;
    private string postData = "default";

    void Start()
    {
        listener = new HttpListener();
        listener.Prefixes.Add("http://*:8080/");
        listener.Start();
        listenerThread = new Thread(StartListener);
        listenerThread.Start();
        Debug.Log("Server started.");
        TextMeshPro poptext = selectMode.GetComponent<TextMeshPro>();
        poptext.text = postData;


    }

    private void StartListener()
    {
        while (listener.IsListening)
        {
            try
            {
                var context = listener.GetContext();
                var request = context.Request;
                var response = context.Response;

                // Check if the request is a POST method
                //if (request.HttpMethod == "POST")
                //{
                // Process POST data
                //string postData;
                using (var reader = new StreamReader(request.InputStream, request.ContentEncoding))
                {
                    postData = reader.ReadToEnd();
                    TextMeshPro poptext = selectMode.GetComponent<TextMeshPro>();

                    if (postData != null)
                    {
                        poptext.text = postData;
                        level1.SetActive(true);
                    }
                    else
                    {
                        poptext.text = "no data";
                    }


                }

                // Customize response to include the POST data received
                string responseString = $"<HTML><BODY>Your request was: {System.Net.WebUtility.HtmlEncode(postData)}</BODY></HTML>";
                var buffer = System.Text.Encoding.UTF8.GetBytes(responseString);

                response.ContentLength64 = buffer.Length;
                Stream output = response.OutputStream;
                output.Write(buffer, 0, buffer.Length);
                output.Close();
                /**}
                else
                {
                    // Handle other types of requests or send a 405 Method Not Allowed response
                    response.StatusCode = 405; // Method Not Allowed
                    response.OutputStream.Close();
                }*/
            }
            catch (Exception ex)
            {
                Debug.LogError($"Error: {ex.Message}");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnApplicationQuit()
    {
        // Stop the HTTP server on quit
        if (listener != null)
        {
            listener.Stop();
            listener.Close();
        }
    }

    private bool IsAllowedIP(string ipAddress)
    {
        var allowedIPs = new List<string> { "127.0.0.1", "your_allowed_ip_here" };
        return allowedIPs.Contains(ipAddress);
    }
    void StartServer()
    {
        if (listener == null || !listener.IsListening)
        {
            listener = new HttpListener();
            listener.Prefixes.Add("http://*:8080/");
            try
            {
                listener.Start();
                listenerThread = new Thread(StartListener);
                listenerThread.Start();
                Debug.Log("Server restarted successfully.");
            }
            catch (Exception ex)
            {
                Debug.LogError($"Failed to start server: {ex.Message}");
            }
        }
    }
}
