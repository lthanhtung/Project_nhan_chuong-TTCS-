using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NhanChuong
{

   
    public partial class Sever : Form
    {
       
        public Sever()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            Connect();

            //Gắn sự kiện đếm ngược vào button start
            Start.Click += Start_Click;
           dem = new System.Windows.Forms.Timer();
            dem.Interval = 1000;
            dem.Tick += timer1_Tick;
            

        }

        //Gủi tin cho tất cả client
        private void Chuong_Click(object sender, EventArgs e)
        {
            foreach (Socket item in CLientList)
            {
                Send(item);
            }
            AddMessage(BoxName.Text);
            BoxName.Clear();
        }

        IPEndPoint IP; // Tạo ip để biết phần mền nào truyền tin đến
        Socket sever;
        List<Socket> CLientList; // tạo danh sách lưu các client kết nối

        //Kết nối sever
        void Connect()
        {
            CLientList = new List<Socket>();
            //IP: địa chỉ sever
            IP = new IPEndPoint(IPAddress.Any, 9999);
            sever = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);

            sever.Bind(IP);

            Thread Listen = new Thread(() =>
            {
                try
                {


                    while (true)
                    {

                        sever.Listen(100);// đợi lắng nghe nghe hàng đợi kết nối (100 là hàng đợi tối đa 100 Client)
                        Socket client = sever.Accept();
                        CLientList.Add(client);

                        Thread reveive = new Thread(Receive);
                        reveive.IsBackground = true;
                        reveive.Start(client);
                    }
                }
                catch // nếu Cố gắng lắng nghe không được thì 
                {
                    IP = new IPEndPoint(IPAddress.Any, 9999);
                    sever = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
                }
            });
            Listen.IsBackground = true;
            Listen.Start();
        }

        //Đóng kết nối
        void close()
        {
            sever.Close();
        }

        //Gủi tin
        void Send(Socket client)
        {
            string Tinkichhoat;

            if (BoxName.Text != string.Empty)
            {
                client.Send(Serialize(BoxName.Text));
            }
            else
            {
                Tinkichhoat = "kichhoat";
                client.Send(Serialize(Tinkichhoat));
            }
        }

        //Nhận tin
        void Receive(object obj)
        {
            Socket client = obj as Socket;
            try
            {
                while (true)
                {


                    byte[] data = new byte[1024 * 5000];
                    client.Receive(data);
                    string message = (string)Deserialize(data);

                    AddMessage(message);
                }
            }
            catch
            {
                CLientList.Remove(client);
                client.Close();
            }
        }

        //add tin lên text box
        void AddMessage(string message)
        {
            DanhsachNhanChuong.Items.Add(new ListViewItem() { Text = message });

        }

        //Phân mảnh (Chuyển các ký tự thành mảng byte để truyền tin đi

        byte[] Serialize(object obj)
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, obj); // phân mảnh tin
            return stream.ToArray(); // trả về 1 mảng byte
        }

        //Gom mảnh (Gom mảng byte lại để xử lý gửi và nhận tin)
        object Deserialize(byte[] data)
        {

            MemoryStream stream = new MemoryStream(data);
            BinaryFormatter formatter = new BinaryFormatter();
            return formatter.Deserialize(stream);
        }


        //Đóng kết nối khi đóng form
        private void Sever_FormClosed(object sender, FormClosedEventArgs e)
        {
            close();
        }

        //Nút bắt đầu đếm ngược thời gian
        private System.Windows.Forms.Timer dem;
        private int demnguoc = 10;
        private void Start_Click(object sender, EventArgs e)
        {
            //Gủi tin nhắn đặt biệt để bắt đầu đếm ngược trên phía client
            foreach (Socket item in CLientList)
            {
                Send(item);
            }
           label1.Text = demnguoc.ToString();
           dem.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            demnguoc--;
            
          
            if (demnguoc == 0)
            {
                dem.Stop();
                demnguoc = 10;
            }
            
            
               
            
            label1.Text = demnguoc.ToString();
        }
    }
}
