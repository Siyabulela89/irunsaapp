using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace irunsaapp.Models
{
	public class AttachmentUploadModel
	{
		public IFormFile? File { get; set; }
		public int EntityTypeId { get; set; }
		public int EntityId { get; set; }
		public int AttachmentGroupId { get; set; }
		public int AttachmentTypeId { get; set; }
		public string? CreatedByUserId { get; set; }
	}
}
