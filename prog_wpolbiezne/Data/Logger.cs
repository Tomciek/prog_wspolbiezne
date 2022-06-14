using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    internal class Logger : IDisposable
    {

        private Logger()
        {
            this.file = new($"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName}" +
                $"/ballsData.yaml", append: true);
        }
        private StreamWriter file;
        private static Logger _instance;

        public static Logger GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Logger();
            }
            return _instance;
        }

        public void SaveDataAsYaml(CircleInformation obj)
        {

            file.Write(obj.ToString());
        }

        public void Dispose()
        {
            file.Close();
        }
    }
}
