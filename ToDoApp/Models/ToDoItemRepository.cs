namespace ToDoApp.Models
{
    public class ToDoItemRepository
    {
        private static List<ToDoItem> _toDoItems = new List<ToDoItem>()
        {
            new ToDoItem {  Id = 1, Name = "Item 1" },
            new ToDoItem {  Id = 2, Name = "Item 2" },
            new ToDoItem {  Id = 3, Name = "Item 3" },
            new ToDoItem {  Id = 4, Name = "Item 4" },
        };

        public static void AddItem(ToDoItem item)
        {
            var maxId = 1;
            if (_toDoItems.Count > 0)
                maxId = _toDoItems.Max(s => s.Id);

            item.Id = maxId + 1;
            _toDoItems.Add(item);
        }

        public static List<ToDoItem> GetItems() => _toDoItems
            .OrderBy(x => x.IsComplete)
            .ThenByDescending(x => x.Id)
            .ToList();

        public static ToDoItem? GetItemById(int id)
        {
            var item = _toDoItems.FirstOrDefault(s => s.Id == id);
            if (item != null)
            {
                return new ToDoItem
                {
                    Id = item.Id,
                    Name = item.Name,
                    IsComplete = item.IsComplete,
                    DateCompleted = item.DateCompleted
                };
            }

            return null;
        }

        public static void UpdateItem(int itemId, ToDoItem item)
        {
            if (itemId != item.Id) return;

            var itemToUpdate = _toDoItems.FirstOrDefault(s => s.Id == itemId);
            if (itemToUpdate != null)
            {
                itemToUpdate.Name = item.Name;
                itemToUpdate.IsComplete = item.IsComplete;
                itemToUpdate.DateCompleted = item.DateCompleted;
            }
        }

        public static void DeleteItem(int itemId)
        {
            var item = _toDoItems.FirstOrDefault(s => s.Id == itemId);
            if (item != null)
            {
                _toDoItems.Remove(item);
            }
        }

        public static List<ToDoItem> SearchItems(string itemFilter)
        {
            return _toDoItems.Where(s => s.Name.Contains(itemFilter, StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
}
