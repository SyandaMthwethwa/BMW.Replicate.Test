using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMW.Assement.ReplicateForm.Models
{
    public class DestinationFileModel
    {
        public double FileSize { get; set; }
        public DateTime CreationTime { get; set; }
        public string FileName { get; set; }
        public string DirectoryName { get; set; }
        public DateTime LastAccessTime { get; set; }
        public DateTime LastUpdateTime { get; set; }
        public bool IsReadOnly { get; set; }
        public string FileExtension { get; set; }
        public string FullName { get; set; }

    }
}
