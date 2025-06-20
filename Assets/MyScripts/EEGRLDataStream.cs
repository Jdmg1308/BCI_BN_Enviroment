// EEGDataStream.cs
using System;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;
using System.Text;
using UnityEngine.UI;
using Interaxon.Libmuse;

public class EEGDataStream : MonoBehaviour
{
    private EEGFullPacket currentPacket = new EEGFullPacket();
    private HashSet<string> receivedBands = new HashSet<string>();
    private TcpClient client;
    private NetworkStream stream;
    public Button TCPStart;

    private void Start()
    {

    }

    public void startStreaming()
    {
        try
        {
            client = new TcpClient("127.0.0.1", 5000); // Adjust port as needed
            stream = client.GetStream();
        }
        catch (Exception e)
        {
            Debug.LogError("TCP connection failed: " + e.Message);
        }
    }

    public void AddBandValue(MuseDataPacketType bandType, float value)
    {
        if (stream.CanWrite)
        {
            string type = bandType.ToString();
            switch (type)
            {
                case "ALPHA_ABSOLUTE": currentPacket.alpha = value; break;
                case "BETA_ABSOLUTE": currentPacket.beta = value; break;
                case "DELTA_ABSOLUTE": currentPacket.delta = value; break;
                case "THETA_ABSOLUTE": currentPacket.theta = value; break;
                case "GAMMA_ABSOLUTE": currentPacket.gamma = value; break;
                default:
                    Debug.LogWarning("Unknown band type: " + bandType);
                    return;
            }

            receivedBands.Add(type);

            if (receivedBands.Count == 5)
            {
                currentPacket.timestamp = Time.time;
                SendPacket(currentPacket);
                receivedBands.Clear();
                currentPacket = new EEGFullPacket();
            }
        }
    }

    private void SendPacket(EEGFullPacket packet)
    {
        if (stream == null) return;

        try
        {
            string json = JsonUtility.ToJson(packet) + "\n";
            byte[] data = Encoding.UTF8.GetBytes(json);
            stream.Write(data, 0, data.Length);
        }
        catch (Exception e)
        {
            Debug.LogError("Failed to send packet: " + e.Message);
        }
    }

    private void OnApplicationQuit()
    {
        stream?.Close();
        client?.Close();
    }
}

[System.Serializable]
public class EEGFullPacket
{
    public float alpha;
    public float beta;
    public float delta;
    public float theta;
    public float gamma;
    public float timestamp;
}

