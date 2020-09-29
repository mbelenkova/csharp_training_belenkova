using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace mantis_tests
{
  public  class FtpHelper: HelperBase
    {
        public FtpHelper(ApplicationManager manager) : base(manager) { }

        public void BackUpFile(String path)//чтобы временно припрятать существующий конфигурационный файл
        {

        }
        public void RestoreBackupFile(String path)//восстанавливает файл из резервной копии
        {

        }

        public void Upload(String path,File localFile)
        {

        }
    }
}
