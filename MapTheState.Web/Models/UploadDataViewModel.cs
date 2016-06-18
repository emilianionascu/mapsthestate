using System.ComponentModel.DataAnnotations;
using System.Web;

namespace MapTheState.Web.Models
{
    public class UploadDataViewModel
    {
        [Required]
        public HttpPostedFileBase File { get; set; }
    }
}