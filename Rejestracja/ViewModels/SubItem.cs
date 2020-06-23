namespace Rejestracja.ViewModels
{
    public class SubItem
    {
        public int IdSubItem;
        public string Name { get; }

        public SubItem(string name, int _idSubItem)
        {
            Name = name;
            IdSubItem = _idSubItem;
        }
    }
}
