using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMW.Assessment.ReplicateForm.Models
{
    public class SourceFileModel
    {
        public string FileName { get; set; }
        public string DirectoryName { get; set; }
        public string FullName { get; set; }
        public double FileSize { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime LastAccessTime { get; set; }
        public DateTime LastUpdateTime { get; set; }
        public bool IsReadOnly { get; set; }
        public string FileExtension { get; set; }
        
    }
}
