using RenTaxi.LIB.AdminModule;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace RenTaxi.LIB
{

    public class ServicesXml
    {
        public string path { get; }
        public ServicesXml()
        {

        }
        public ServicesXml(string path)
        {
            this.path = path;
        }
        public XmlDocument GetDocument()
        {
            XmlDocument xdoc = new XmlDocument();

            //1. Проверить есть ли документ 
            FileInfo info = new FileInfo(path);
            //2. Если есть, загрузить и вернуть
            if (info.Exists)
                xdoc.Load(path);
            else
            {
                //3. Если нет, создать
                XmlElement root = xdoc.CreateElement("Users");
                //3.1. Создать корневой элемент и вернуть
                xdoc.AppendChild(root);
                xdoc.Save(path);
            }
            return xdoc;
        }
        public bool GetUser(string login, string password)
        {
            return true;
        }
        public bool AddUser(Tbl_User user, out string message)
        {
            try
            {
                XmlSerializer formatter = new XmlSerializer(typeof(Tbl_User));

                using (FileStream fs = new FileStream("users/" + user.UserName +
                                                      ".xml", FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, user);
                }
                message = "Пользователь добавлен";
                return true;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }
        }

        public List<Tbl_User> getUser()
        {
            List<Tbl_User> users = new List<Tbl_User>();
            DirectoryInfo di = new DirectoryInfo("users");

            XmlSerializer formatter = new XmlSerializer(typeof(Tbl_User));

            foreach (FileInfo item in di.GetFiles())
            {
                using (FileStream fs = new FileStream(item.FullName, FileMode.Open))
                {
                    users.Add((Tbl_User)formatter.Deserialize(fs));
                }
            }

            return users;
        }
    }
}
