using Microsoft.AspNetCore.Http;

namespace WriteMe.Data.ViewModels
{
    public class UploadFileViewModel
    {
        public string FromUserEmail { get; set; }
        public string ToUserEmail { get; set; }
        public IFormFile File { get; set; }
    }
}
