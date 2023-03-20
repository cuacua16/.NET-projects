﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinQSnippets {
	public class Comment {
		public int Id { get; set; }
		public string Content { get; set; } = string.Empty;
		public string Title { get; set; } = string.Empty;
		public DateTime Created { get; set; }
	}
}