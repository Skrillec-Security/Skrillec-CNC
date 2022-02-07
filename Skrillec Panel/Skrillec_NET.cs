using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using Skrillec_Panel;


class Buffer
{
    public static string data;
    public static string cmd;
    public static string[] cmd_args;

    public static void cmd_parser(string cmd)
    {
        if(cmd.Contains(" "))
        {
            Buffer.data = cmd;
            Buffer.cmd_args = cmd.Split(' ');
            Buffer.cmd = Buffer.cmd_args[0];
        } else
        {
            Buffer.data = cmd;
            Buffer.cmd = cmd;
            Array.Resize(ref Buffer.cmd_args, (Buffer.cmd_args.Length+1));
            Buffer.cmd_args[Buffer.cmd_args.Length] = (cmd);
        }
    }
}
class Skrillec_NET
{
    public static TcpListener server;
    public static IPAddress server_ip = IPAddress.Parse("127.0.0.1");
    public static Int32 port;
    public static bool server_on = false;
    public static int tid = 0;
    public static string server_logs = "";

    public static void start_skrillec()
    {
        try
        {
            // TcpListener server = new TcpListener(port);
            Skrillec_NET.server = new TcpListener(Skrillec_NET.server_ip, Skrillec_NET.port);

            // Start listening for client requests.
            Skrillec_NET.server_logs += "Server started\n";
            Skrillec_NET.server.Start();
            Skrillec_NET.server_on = true;
            Skrillec_NET.connection_handler();

        }
        catch (SocketException e)
        {
            Skrillec_NET.server_logs += "SocketException: " + e.ToString() + "\n";
        }
        finally
        {
            // Stop listening for new clients.
            Skrillec_NET.server.Stop();
        }
    }

    public static void connection_handler()
    {

        // Enter the listening loop.
        while (true)
        {
            Skrillec_NET.server_logs += "Waiting for a connection... \n";

            // Perform a blocking call to accept requests.
            // You could also use server.AcceptSocket() here.
            TcpClient client = Skrillec_NET.server.AcceptTcpClient();
            Skrillec_NET.server_logs += "Connected!\n";

            Skrillec_NET.cmd_handler(client);
        }
    }

    public static void cmd_handler(TcpClient socket)
    {
        Byte[] bytes = new Byte[256];
        String data = null;
        data = null;

        NetworkStream stream = socket.GetStream();
        int i;

        stream.Write(System.Text.Encoding.ASCII.GetBytes(">>> "), 0, ">>> ".Length);
        while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
        {
            data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
            Skrillec_NET.server_logs += "Received: " + data + "\n";

            if (data == "help" || data == "?")
            {

            }
            // Convert Message to byte then send
            //byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);
            //stream.Write(msg, 0, msg.Length);
        }
    }
}