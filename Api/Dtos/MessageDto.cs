using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Dtos
{
	public class MessageDto
	{
		[Required]
		public String From { get; set; }
		public String To { get; set; }
		[Required]
		public String Content { get; set; }
	}
}

