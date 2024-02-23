using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace BMW.Assessment.ReplicateForm.Logic
{
    public class Directories
    {

        public void CompareFile(string file, string destinationDir, bool donotdeletedirectoriesfiles, StringBuilder logBuilder)
        {
            string destFile = Path.Combine(destinationDir, Path.GetFileName(file));
            if (donotdeletedirectoriesfiles || !File.Exists(destFile) || File.GetLastWriteTime(file) != File.GetLastWriteTime(destFile) || new FileInfo(file).Length != new FileInfo(destFile).Length)
            {
                File.Copy(file, destFile, true);
                new EventLog().Log($"Copied {file} to {Path.Combine(destinationDir, Path.GetFileName(file))} @ {DateTime.Now}", logBuilder);
            }
        }

        public void CreateDirectoryIfNotExist(string destDir, string dir, StringBuilder logBuilder)
        {
            if (!Directory.Exists(destDir))
            {
                Directory.CreateDirectory(destDir);
                new EventLog().Log($"Created directory: {destDir} @ {DateTime.Now}", logBuilder);
            }
        }

        public void DeleteNoneExistFile(string file, string destinationDir, StringBuilder logBuilder)
        {
            string filePath = Path.Combine(destinationDir, file);
            File.Delete(filePath);
            new EventLog().Log($"None Exist File Deleted: {file} from: {Path.Combine(destinationDir, file)} @: {DateTime.Now}", logBuilder);
        }

    }
}
