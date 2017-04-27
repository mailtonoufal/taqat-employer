using ArabWaha.Models.Search;

namespace ArabWaha.Models
{
    public static class TmpObject
    {
        public static Program Program { get; set; } = new Program();
		public static EnumGlobal.Program ProgramPreviousPage { get; set; } = EnumGlobal.Program.MyProgram;
        public static Announcement Announcement { get; set; } = new Announcement();
		public static ObligationContainer ObligationContainer = new ObligationContainer();
		public static bool LoadMyPrograms { get; set; } = false;
		public static ProgramListRoot ProgramListRoot { get; set; } = new ProgramListRoot();
        //public static SearchResults SearchResults { get; set; } = new SearchResults();
    }
}
