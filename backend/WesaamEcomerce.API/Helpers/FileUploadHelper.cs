namespace WesaamEcomerce.API.Helpers
{
    public static class FileUploadHelper
    {
        public static async Task<List<string>> UploadFiles(List<IFormFile> files)
        {
            long size = files.Sum(f => f.Length);

            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    var filePath = Path.GetTempFileName();

                    using (var stream = File.Create(filePath))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                }
            }

            // Process uploaded files to Google Cloud
            return new List<string>();
        }
    }
}