namespace Diretorios
{
    class Diretorios {
        public void printDiretorios(string raiz){
            IEnumerable<string> listOfDirectories = Directory.EnumerateDirectories(raiz);

            foreach (var dir in listOfDirectories) {
                Console.WriteLine(dir);
            }
        }

        public void printArquivos(string raiz){
            IEnumerable<string> listOfDirectories = Directory.EnumerateFiles(raiz);

            foreach (var dir in listOfDirectories) {
                Console.WriteLine(dir);
            }
        }

        public void searchTextos(string raiz){
            IEnumerable<string> allFilesInAllFolders = Directory.EnumerateFiles(raiz, "*.txt", SearchOption.AllDirectories);

            foreach (var file in allFilesInAllFolders){
                Console.WriteLine(file);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Diretorios dir = new Diretorios();
            dir.printDiretorios("stores");
            dir.printArquivos("stores");
            dir.searchTextos("stores");
        }
    }
}