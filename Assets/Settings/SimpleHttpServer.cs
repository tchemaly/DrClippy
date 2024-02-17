using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Net;
using System.Threading;
using System.IO;

public class SimpleHttpServer : MonoBehaviour
{
    private HttpListener listener;
    private Thread listenerThread;

    void Start()
    {
        listener = new HttpListener();
        listener.Prefixes.Add("http://*:8080/");
        listener.Start();
        listenerThread = new Thread(StartListener);
        listenerThread.Start();
        Debug.Log("Server started.");
    }

    private void StartListener()
    {
        while (listener.IsListening)
        {
            try
            {
                var context = listener.GetContext();
                var response = context.Response;

                /** AUTHENTICATION
                var requestIP = context.Request.RemoteEndPoint.Address.ToString();
                if (!IsAllowedIP(requestIP))
                {
                    context.Response.StatusCode = 403; // Forbidden
                    context.Response.OutputStream.Close();
                    continue;
                } */

                string responseString = "<HTML><BODY> Hello world!</BODY></HTML>";
                var buffer = System.Text.Encoding.UTF8.GetBytes(responseString);

                response.ContentLength64 = buffer.Length;
                Stream output = response.OutputStream;
                output.Write(buffer, 0, buffer.Length);

                output.Close();
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
        //TODO implement later
    }
    void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            // App is suspended, stop the server
            if (listener != null)
            {
                listener.Stop();
                listener.Close();
            }
        }
        else
        {
            // App is resumed, restart the server
            StartServer();
        }
    }

    void OnApplicationFocus(bool hasFocus)
    {
        if (hasFocus)
        {
            // App has regained focus, restart the server if it's not already running
            StartServer();
        }
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
