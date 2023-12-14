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

namespace Client
{
    public partial class Client : Form
    {
        public Client()
        {
            InitializeComponent();

            Connect();
            CheckForIllegalCrossThreadCalls = false;
        }
        //Gủi tin đi
        bool Start_click = false;
        private void Chuong_Click(object sender, EventArgs e)
        {
            if (Start_click == true)
            {
                Send();
                AddMessage(textBox1.Text);
            }
            
            
               
              
        }


        /*Cần:
         * Socket
         * IP để gửi và nhận tin
         */


        IPEndPoint IP; // tạo IP để sever biết là phầm mền nào truyền tin đến
        Socket client;
        //Kết nối đến sever
        void Connect()
        {
            //IP: địa chỉ sever
            IP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9999);
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);

            try
            {
                client.Connect(IP);

            }
            catch
            {
                MessageBox.Show("Không thể kết nối sever!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //tạo luồng ngồi lắng nghe
            Thread listen = new Thread(Receive);
            listen.IsBackground = true;
            listen.Start();

        }

        //Đóng kết nối
        void close()
        {
            client.Close();
        }

        //Gủi tin
        void Send()
        {
            if (textBox1.Text != string.Empty)
            {
                client.Send(Serialize(textBox1.Text));
            }
        }

        //Nhận tin
        private int demnguoc = 10; 
        void Receive()
        {

            try
            {
                while (true)
                {


                    byte[] data = new byte[1024 * 5000];
                    client.Receive(data);
                    string message = (string)Deserialize(data);
                    if (message == "kichhoat") 
                    {
                        //bắt đầu đếm ngược
        
                        label1.Text = demnguoc.ToString();
                        //tạo 1 luồng đếm ngược
                        Thread DemnguocThread = new Thread(Kichhoat);
                        DemnguocThread.IsBackground = true;
                        DemnguocThread.Start();
                    }
                    else
                    {
                        AddMessage(message);
                    }
                    
                }
            }
            catch
            {
                close();
            }
        }

        //hàm kích hoạt đếm ngược

        //hàm đếm ngược
        private void Kichhoat()
        {
            int thoigian = demnguoc; // Lấy giá trị demnguoc
           
            while (thoigian > 0 )
            {
                
                if (  thoigian > 0 && thoigian <= 10)
                {


                    label1.Text = thoigian.ToString(); // Cập nhật Label với số giây còn lại
                    Thread.Sleep(1000); // Đợi 1 giây

                    thoigian--; // Giảm số giây
                    Start_click = true;
                    Chuong.Enabled = true;
                }
                   

            }
            if (thoigian == 0)
            {
                Chuong.Enabled = false;
                Start_click = false;

            }

            label1.Text = demnguoc.ToString(); // Hiển thị giá trị ban đầu của demnguoc
        }


        //add tin lên text box
        void AddMessage(string message)
        {
           



            Danhsach.Items.Add(new ListViewItem() { Text = message + " " + "đã nhấn chuông vào giây thứ:" + label1.Text});
            
            
                
            

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





        //Đóng kết nối khi form đóng
        private void Client_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }


        
    }
}
