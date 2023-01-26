namespace InOutLib
{
    public class CsvHelper : FileHelper
    {
        #region private attributs
        private char _separator;
        #endregion private attributs

        #region constructor
        public CsvHelper(string path, string fileName, char separator = ';') : base(path, fileName)
        { 
            _separator = separator;            
        }
        #endregion constructor

        #region public methods 
        public void ExtractFileContent()
        {
            StreamReader streamReader = new StreamReader(_fullPath);
            string line;
            // Reads and stores lines from the file until eof.
            while ((line = streamReader.ReadLine()) != null)
            {
                this.Lines.Add(line);
            }
            streamReader.Close();

            if (this.Lines.Count == 0)
            {
                throw new EmptyFileException();
            }
        }
        #endregion public methods

        #region private methods
        private bool IsCharSupported(char separator)
        {
            if(separator != '+')
            {
                throw new UnsupportedSeparatorException();
            }
        }
        #endregion privates methods

        #region nested classes
        public class CsvHelperException : FileHelperException{}
        public class UnsupportedSeparatorException : CsvHelperException { }
        public class StructureException : CsvHelperException { }
        #endregion nested classes
    }
}
