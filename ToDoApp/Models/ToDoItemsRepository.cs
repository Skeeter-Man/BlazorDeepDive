using Microsoft.AspNetCore.Hosting.ToDoItem;

namespace ToDoApp.Models
{
    public class ToDoItemsRepository
    {
        private static List<ToDoItem> toDoItems = new List<ToDoItem>()
        {
            new ToDoItem {Id = 1, Name = "Item 1"}
        };

        public static void AddToDoItem(ToDoItem ToDoItem)
        {
            var maxId = 1;
            if (ToDoItems.Count > 0)
                maxId = servers.Max(s => s.Id);

            server.Id = maxId + 1;
            servers.Add(server);
        }

        public static List<ToDoItem> GetToDoItems() => servers;

        public static List<ToDoItem> GetToDoItemsByCity(string cityName)
        {
            return servers.Where(s => s.City.Equals(cityName, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public static ToDoItem? GetToDoItemById(int id)
        {
            var server = servers.FirstOrDefault(s => s.Id == id);
            if (server != null)
            {
                return new ToDoItem
                {
                    Id = server.Id,
                    Name = server.Name,
                    City = server.City,
                    IsOnline = server.IsOnline
                };
            }
            return null;
        }

        public static void UpdateToDoItem(int serverId, ToDoItem server)
        {
            if (serverId != server.Id) return;

            var serverToUpdate = servers.FirstOrDefault(s => s.Id == serverId);
            if (serverToUpdate != null)
            {
                serverToUpdate.IsOnline = server.IsOnline;
                serverToUpdate.Name = server.Name;
                serverToUpdate.City = server.City;
            }
        }

        public static void DeleteToDoItem(int serverId)
        {
            var server = servers.FirstOrDefault(s => s.Id == serverId);
            if (server != null)
            {
                servers.Remove(server);
            }
        }

        public static List<ToDoItem> SearchToDoItems(string serverFilter)
        {
            return servers.Where(s => s.Name.Contains(serverFilter, StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
}
