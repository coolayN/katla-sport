using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KatlaSport.Services.ImageManagement
{
    public interface IMyImageServise
    {
        IEnumerable<MyImage> GetAll();

        MyImage GetById(int id);

        CloudBlobContainer GetBlobContainer(string connection, string containerName);

        Task SetImage(string title, Uri uri);

        void UpdateImage(MyImage changeImage);

        void DeleteImage(MyImage imageToDelete);
    }
}
