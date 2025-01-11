using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// Добавляем пространства имен для работы сокетов
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Security.Cryptography;
using System.IO;
using System.Text.RegularExpressions;

namespace TCPSocketServer
{
    // исх код
    public partial class Form1 : Form
    {
        // Раздел глобальных переменных
        private static Socket Server; // Создаем объект сокета-сервера
        private static Socket Handler; // Создаем объект вспомогательного сокета
        private static IPHostEntry ipHost; // Класс для сведений об адресе веб-узла
        private static IPAddress ipAddr; // Предоставляет IP-адрес
        private static IPEndPoint ipEndPoint; // Локальная конечная точка
        private static Thread socketThread; // Создаем поток для поддержки потока
        private static Thread WaitingForMessage; // Создаем поток для приёма сообщений

        private static bool keyGenerated = false;
        private static bool synK = false;
        private static bool IV = false;


        //Создаём UnicodeEncoder для перевода информации между массивом байт и строкой.
        private static UnicodeEncoding ByteConverter = new UnicodeEncoding();
        // Создаем объект класса RSACryptoServiceProvider для работы с библиотекой шифрования
        // Инициализирует новый экземпляр класса RSACryptoServiceProvider с созданной случайным образом
        // парой ключей указанного размера.
        private static RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();

        private static Aes myAes = Aes.Create();
        // Функция ToXmlString выгружает ключ текущего объекта
        // false, чтобы экспортировать информацию об открытом ключе или передать
        // true для экспорта информации об открытом и закрытом ключах.
        private static string publicKeyXml;
        private static string privateKeyXml;

        public Form1()
        {
            InitializeComponent();
        }

        // Алгоритм шифрования от Microsoft
        static byte[] EncryptStringToBytes_Aes(string plainText, byte[] Key, byte[] IV)
        {
            // Пооверка входящих переменных на валидность
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encrypted;
            // Создается экземпляр класса Aes для использования ключа и IV
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key; //
                aesAlg.IV = IV;
                // Работа производится с использованием потоков
                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key,
               aesAlg.IV);
                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt,
                   encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }
            // Возвращаем зашифрованные данные.
            return encrypted;
        }
        // Алгоритм расшифровки от Microsoft
        static string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] Key, byte[] IV)
        {
            // Пооверка входящих переменных на валидность
            if (cipherText == null ||  cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            // Строка для формирования расшифрованного текста
            string plaintext = null;
            // Создается экземпляр класса Aes для использования ключа и IV
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;
                // Работа производится с использованием потоков
                // Create a decryptor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key,
               aesAlg.IV);
                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt,
                   decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
            // Возвращаем расшифрованные данные.
            return plaintext;
        }

        // Функция запуска сокета
        private void startSocket()
        {
            // IP-адрес сервера, для подключения
            string HostName = "0.0.0.0";
            // Порт подключения
            string Port = tbPort.Text;
            // Разрешает DNS-имя узла или IP-адрес в экземпляр IPHostEntry.
            ipHost = Dns.Resolve(HostName);
            // Получаем из списка адресов первый (адресов может быть много)
            ipAddr = ipHost.AddressList[0];
            // Создаем конечную локальную точку подключения на каком-то порту
            ipEndPoint = new IPEndPoint(ipAddr, int.Parse(Port));
            try
            {
                // Создаем сокет сервера на текущей машине
                Server = new Socket(
                    AddressFamily.InterNetwork,
                SocketType.Stream,
                ProtocolType.Tcp
                );
            }
            catch (SocketException error)
            {
                // 10061 — порт подключения занят/закрыт
                if (error.ErrorCode == 10061)
                {
                    MessageBox.Show("Порт подключения закрыт!");
                    Application.Exit();
                }
            }
            // Ждем подключений
            try
            {
                // Связываем удаленную точку с сокетом
                Server.Bind(ipEndPoint);
                // Не более 10 подключения на сокет
                Server.Listen(10);
                // Начинаем "прослушивать" подключения
                while (true)
                {
                    Handler = Server.Accept();
                    if (Handler.Connected)
                    {
                        // Позеленим кнопочку для красоты, чтобы пользователь знал, что соединение установлено
                        bConnect.Invoke(new Action(() => bConnect.Text = "Клиент подключен"));
                        bConnect.Invoke(new Action(() => bConnect.BackColor =
                        Color.Green));
                        // Создаем новый поток, указываем на ф-цию получения сообщений в классе Worker
                        WaitingForMessage = new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(GetMessages));
                        // Запускаем, в параметрах передаем листбокс (история чата)
                        WaitingForMessage.Start(new Object[] { lbHistory });
                    }
                    break;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Проблемы с подключением");
            }
        }
        // Ф-ция, работающая в новом потоке: получение новых сообщений ————
        public static void GetMessages(Object obj)
        {
            // Получаем объект истории чата (лист бокс)
            Object[] Temp = (Object[])obj;System.Windows.Forms.ListBox ChatListBox =
           (System.Windows.Forms.ListBox)Temp[0];
            // В бесконечном цикле получаем сообщения
            while (true)
            {
                // Ставим паузу, чтобы на время освобождать порт для отправки сообщений
                Thread.Sleep(50);
                try
                {
                    // Получаем сообщение от клиента
                    string Message = GetDataFromClient();

                    // Добавляем в историю + текущее время                                      
                    //if (keyGenerated && Message!=String.Empty)
                    if (keyGenerated && Message != String.Empty)
                    {
                            ChatListBox.Invoke(new Action(() => ChatListBox.Items.Add(DateTime.Now.ToShortTimeString() + " Client: " + Message)));
                    }
                    else
                    {
                        string askkeypattern = @"^OpenKeyRequest$";
                        if (Regex.IsMatch(Message, askkeypattern))
                        {
                            // Функция ToXmlString выгружает ключ текущего объекта
                            // false, чтобы экспортировать информацию об открытом ключе или передать
                            // true для экспорта информации об открытом и закрытом ключах.
                            publicKeyXml = RSA.ToXmlString(false);
                            privateKeyXml = RSA.ToXmlString(true);
                            // Функция FromXmlString загружает ключ в текущий объект
                            RSA.FromXmlString(publicKeyXml);
                            RSA.FromXmlString(privateKeyXml);
                            keyGenerated = true;
                            SendDataToClient(publicKeyXml);
                        }
                    }

                }
                catch
                {

                }

            }
        }
        // Получение информации от клиента
        public static string GetDataFromClient()
        {
            string GetInformation = String.Empty;
            byte[] GetBytes;
            if (!synK)
                GetBytes = new byte[128];
            else
                GetBytes = new byte[1024];
            int BytesRec = Handler.Receive(GetBytes);

            if (keyGenerated)
            {
                if (!IV)
                {
                    myAes.IV = RSA.Decrypt(GetBytes, false);
                    byte[] gIV = myAes.IV;
                    IV = true;
                }
                else if (!synK)
                {
                    myAes.Key = RSA.Decrypt(GetBytes, false);
                    byte[] gKey = myAes.Key;
                    synK = true;
                }
                else
                {
                    byte[] transformed = new byte[BytesRec];
                    for (int i = 0; i < BytesRec; i++)
                        transformed[i] = GetBytes[i];
                    GetInformation = DecryptStringFromBytes_Aes(transformed, myAes.Key, myAes.IV);

                }
            }
            else
                GetInformation = Encoding.Unicode.GetString(GetBytes, 0, BytesRec);
                return GetInformation;
        }
        // Отправка информации на клиент
        public static void SendDataToClient(string Data)
        {
            byte[] SendMsg;
            if (synK)
                SendMsg = EncryptStringToBytes_Aes(Data, myAes.Key, myAes.IV);
            else
                SendMsg = Encoding.Unicode.GetBytes(Data);
            Handler.Send(SendMsg);
        }

        private void bConnect_Click(object sender, EventArgs e)
        {
            socketThread = new Thread(new ThreadStart(startSocket));
            socketThread.IsBackground = true;
            socketThread.Start();
            bConnect.Enabled = false;
            bConnect.Text = "Ожидание подключения";
            bConnect.BackColor = Color.Yellow;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Посылаем клиенту новое сообщение
            SendDataToClient(tbMessage.Text);
            // Добавляем в историю свое же сообщение + ник + время написания
            lbHistory.Items.Add(DateTime.Now.ToShortTimeString() + " Server: " + tbMessage.Text.ToString());
            // Автопрокрутка истории чата
            lbHistory.TopIndex = lbHistory.Items.Count - 1;
            // Убираем текст из поля ввода
            tbMessage.Text = "";
        }

        private void bConnect_Click_1(object sender, EventArgs e)
        {
            socketThread = new Thread(new ThreadStart(startSocket));
            socketThread.IsBackground = true;
            socketThread.Start();
            bConnect.Enabled = false;
            bConnect.Text = "Ожидание подключения";
            bConnect.BackColor = Color.Yellow;
        }
    }
}
