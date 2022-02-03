using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

class Skrillec_NET
{
    public static TcpListener server;
    public static IPAddress server_ip = IPAddress.Parse("127.0.0.1");
    public static Int32 port;

    public static void start_skrillec()
    {
        try
        {
            // TcpListener server = new TcpListener(port);
            Skrillec_NET.server = new TcpListener(Skrillec_NET.server_ip, Skrillec_NET.port);

            // Start listening for client requests.
            Skrillec_NET.server.Start();

        }
        catch (SocketException e)
        {
            Console.WriteLine("SocketException: {0}", e);
        }
        finally
        {
            // Stop listening for new clients.
            Skrillec_NET.server.Stop();
        }

        Console.WriteLine("\nHit enter to continue...");
        Console.Read();
    }

    public static void connection_handler(TcpClient socketn)
    {
        // Buffer for reading data
        Byte[] bytes = new Byte[256];
        String data = null;

        // Enter the listening loop.
        while (true)
        {
            Console.Write("Waiting for a connection... ");

            // Perform a blocking call to accept requests.
            // You could also use server.AcceptSocket() here.
            TcpClient client = Skrillec_NET.server.AcceptTcpClient();
            Console.WriteLine("Connected!");

            data = null;

            // Get a stream object for reading and writing
            NetworkStream stream = client.GetStream();

            int i;

            stream.Write(System.Text.Encoding.ASCII.GetBytes(">>> "), 0, ">>> ".Length);
            // Loop to receive all the data sent by the client.
            while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
            {
                // Translate data bytes to a ASCII string.
                data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                Console.WriteLine("Received: {0}", data);

                // Process the data sent by the client.
                data = data.ToUpper();

                byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);

                // Send back a response.
                stream.Write(msg, 0, msg.Length);
                Console.WriteLine("Sent: {0}", data);
            }

            // Shutdown and end connection
            client.Close();
        }
    }

    public static void cmd_handler(TcpClient socket)
    {

    }
}