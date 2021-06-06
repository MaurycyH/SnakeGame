using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace SnakeSense.Helpers
{
    /// <summary>
    /// Class which contains method for downloading image from list and path to this file
    /// </summary>
    public class DownloadImageHelper
    {
        private readonly List<Uri> mImageList;
        private DirectoryHelper mDirectoryHelper;
        public string PathToNewImage;

        /// <summary>
        /// Constructor which initialize and populates list with links
        /// </summary>
        public DownloadImageHelper()
        {
            mDirectoryHelper = new DirectoryHelper();
            mImageList = new List<Uri>
            {
                new Uri("https://cdn.pixabay.com/photo/2013/07/13/13/42/snake-161424_960_720.png"),
                new Uri("https://cdn.pixabay.com/photo/2013/10/15/10/04/snake-195917_960_720.jpg"),
                new Uri("https://cdn.pixabay.com/photo/2017/02/01/11/02/animal-2029654_960_720.png"),
                new Uri("https://cdn.pixabay.com/photo/2016/04/01/08/40/animal-1298878_960_720.png"),
                new Uri("https://cdn.pixabay.com/photo/2013/07/12/12/30/snake-145808_960_720.png")
            };
        }
        /// <summary>
        /// Async Task which download image from private list and sets path to it
        /// </summary>
        /// <returns>Nothing</returns>
        public async Task GetImageAsync()
        {
            Random random = new Random();
            int rand = random.Next(4);
            using (WebClient webClient = new WebClient())
            {
                byte[] data = await webClient.DownloadDataTaskAsync(mImageList[rand]);
                using (MemoryStream mem = new MemoryStream(data))
                {
                    using (System.Drawing.Image image = System.Drawing.Image.FromStream(mem))
                    {
                        ResizeImageHelper.ResizeImage(image, 825, 450).Save(Path.Combine(mDirectoryHelper.PathToAppData, "Snake", $"SnakePhoto{rand}.png"), ImageFormat.Png);
                        PathToNewImage = Path.Combine(mDirectoryHelper.PathToAppData, "Snake", $"SnakePhoto{rand}.png");
                    }
                }
            }
        }
    }
}
