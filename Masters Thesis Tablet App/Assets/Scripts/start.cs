using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Net;
using System.Linq;
using System.Threading;
using System.Net.Sockets;
using System.IO;
using System;

public class start : MonoBehaviour
{
    public GameObject nextPage;
    public GameObject previousPage;
    public int port = 50000;
    internal bool socket_ready = false;
    internal string input_buffer = "";

    TcpClient tcp_socket;
    NetworkStream net_stream;

    StreamWriter socket_writer;
    StreamReader socket_reader;
    // Start is called before the first frame update
    void Start()
    {
        //setupSocket();
    }

    // Update is called once per frame
    void Update()
    {
        if (setupSocket())
        {
                previousPage.SetActive(false);
                nextPage.SetActive(true);
        }
    }

    // Helper methods for:
    //...setting up the communication
    public bool setupSocket()
    {
        //string host = SceneChange.networkID;
        string host = "192.168.72.1";
        Debug.Log("Connecting to " + host);
        try
        {
                   
            tcp_socket = new TcpClient(host, port);
            net_stream = tcp_socket.GetStream();
            socket_writer = new StreamWriter(net_stream);
            socket_reader = new StreamReader(net_stream);
            Debug.Log("connected");
            return true;
        }
        catch (Exception e)
        {
            // Something went wrong
            Debug.Log("Socket error: " + e);
        }
        Debug.Log("trying to connect to " + host);
        return false;
    }
  
}
