using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SnakeSense.Helpers
{
    public class DownloadImageHelper
    {
        private List<Uri> mImageList;
        private DirectoryHelper mDirectoryHelper;
        public string PathToNewImage;

        public DownloadImageHelper()
        {
            mDirectoryHelper = new DirectoryHelper();
            mImageList = new List<Uri>();
            mImageList.Add(new Uri("https://cdn.pixabay.com/photo/2013/07/13/13/42/snake-161424_960_720.png"));
            mImageList.Add(new Uri("https://cdn.pixabay.com/photo/2013/10/15/10/04/snake-195917_960_720.jpg"));
            mImageList.Add(new Uri("https://cdn.pixabay.com/photo/2017/02/01/11/02/animal-2029654_960_720.png"));
            mImageList.Add(new Uri("https://cdn.pixabay.com/photo/2016/04/01/08/40/animal-1298878_960_720.png"));
            mImageList.Add(new Uri("https://cdn.pixabay.com/photo/2013/07/12/12/30/snake-145808_960_720.png"));
        }
        public async Task GetImageAsync(CancellationToken cancellationToken)
        {
            Random random = new Random();
            int rand = random.Next(4);
            Uri imageUri = mImageList[rand];
            using (WebClient webClient = new WebClient())
            {
                byte[] data = await webClient.DownloadDataTaskAsync(mImageList[rand]);
                using (MemoryStream mem = new MemoryStream(data))
                {
                    using (System.Drawing.Image image = System.Drawing.Image.FromStream(mem))
                    {
                        ResizeImageHelper.ResizeImage(image, 800, 650).Save(Path.Combine(mDirectoryHelper.PathToAppData, "Snake", $"SnakePhoto{rand}.png"), ImageFormat.Png);
                        PathToNewImage = Path.Combine(mDirectoryHelper.PathToAppData, "Snake", $"SnakePhoto{rand}.png");
                    }
                }
            }
        }
    }
}
