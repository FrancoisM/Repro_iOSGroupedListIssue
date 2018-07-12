using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace ReproiOSGroupedListIssuer.Shared
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private IEnumerable<BookGroup> _books;
        public IEnumerable<BookGroup> Books
        {
            get => _books;
            private set
            {
                _books = value;
                OnPropertyChanged(nameof(Books));
            }
        }

        public MainPageViewModel()
        {
            var books = new List<BookCellViewModel>
            {
                new BookCellViewModel("Book A", "this is book A", "Shelve 1"),
                new BookCellViewModel("Book A", "this is book B", "Shelve 1"),
                new BookCellViewModel("Book A", "this is book C", "Shelve 1"),
                new BookCellViewModel("Book A", "this is book D", "Shelve 1"),
                new BookCellViewModel("Book E", "this is book E", "Shelve 2"),
                new BookCellViewModel("Book F", "this is book F", "Shelve 2"),
            };

            Books = books
                .GroupBy(book => book.Shelve)
                .Select(g => new BookGroup(g.Key, g))
                .ToList();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public class BookCellViewModel
    {
        public string Title { get; }
        public string Description { get; }
        public string Shelve { get; }

        public BookCellViewModel(string title, string description, string shelve)
        {
            Title = title;
            Description = description;
            Shelve = shelve;
        }
    }


    public class BookGroup : Group<string, BookCellViewModel>
    {
        public BookGroup(string shelve, IEnumerable<BookCellViewModel> items) : base(shelve, items) {}
    }

    public abstract class Group<TKey, TElement> : IGrouping<TKey, TElement>
    {
        private readonly List<TElement> _group;

        protected Group(TKey key, IEnumerable<TElement> items)
        {
            Key = key;
            _group = new List<TElement>(items);
        }

        public TKey Key { get; }

        public IEnumerator<TElement> GetEnumerator() => _group.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _group.GetEnumerator();
    }
}
