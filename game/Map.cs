using static System.Net.Mime.MediaTypeNames;
using System.Drawing;

public class Map
{
    public static Room CurrentRoom = null;
    public Dictionary<string, Room> AdjacentRooms { get; set; }

    public static void Initialize()
    {
        // Create rooms
        Room coryAndCarrieRoom = new Room("Cory and Carrie's Room", null, new Dictionary<string, Room>(), new List<NPC>());
        Room cathysRoom = new Room("Cathy's Room (Yours)", null, new Dictionary<string, Room>(), new List<NPC>());
        Room chrisRoom = new Room("Chris's Room", null, new Dictionary<string, Room>(), new List<NPC>());
        Room firstFloorCorridor = new Room("First Floor Corridor", null, new Dictionary<string, Room>(), new List<NPC>());

        Room firstFloorStairs = new Room("First Floor Stairs", null, new Dictionary<string, Room>(), new List<NPC>());
        Room grandmasRoom = new Room("Grandma's Room", null, new Dictionary<string, Room>(), new List<NPC>());
        Room groundFloorCorridor = new Room("Ground Floor Corridor", null, new Dictionary<string, Room>(), new List<NPC>());
        Room bathroom = new Room("Bathroom", null, new Dictionary<string, Room>(), new List<NPC>());
        Room parentsRoom = new Room("Parents Room", null, new Dictionary<string, Room>(), new List<NPC>());
        Room toilets1 = new Room("Toilets", null, new Dictionary<string, Room>(), new List<NPC>());
        Room diningRoom = new Room("Dining Room", null, new Dictionary<string, Room>(), new List<NPC>());
        Room livingRoom = new Room("Living Room", null, new Dictionary<string, Room>(), new List<NPC>());
        Room garageStairs = new Room("Garage Stairs", null, new Dictionary<string, Room>(), new List<NPC>());
        Room entrance = new Room("Entrance", null, new Dictionary<string, Room>(), new List<NPC>());
        Room kitchen = new Room("Kitchen", null, new Dictionary<string, Room>(), new List<NPC>());
        Room storeroom = new Room("Storeroom", null, new Dictionary<string, Room>(), new List<NPC>());
        Room toilets2 = new Room("Toilets", null, new Dictionary<string, Room>(), new List<NPC>());

        Room office = new Room("Office", null, new Dictionary<string, Room>(), new List<NPC>());
        Room cave = new Room("Cave", null, new Dictionary<string, Room>(), new List<NPC>());

        // Link rooms together
        firstFloorCorridor.AdjacentRooms["left"] = coryAndCarrieRoom;
        firstFloorCorridor.AdjacentRooms["right"] = cathysRoom;
        firstFloorCorridor.AdjacentRooms["front"] = chrisRoom;
        firstFloorCorridor.AdjacentRooms["bottom"] = firstFloorStairs;

        coryAndCarrieRoom.AdjacentRooms["right"] = firstFloorCorridor;
        cathysRoom.AdjacentRooms["left"] = firstFloorCorridor;
        chrisRoom.AdjacentRooms["behind"] = firstFloorCorridor;

        firstFloorStairs.AdjacentRooms["right"] = grandmasRoom;
        firstFloorStairs.AdjacentRooms["bottom"] = groundFloorCorridor;
        firstFloorStairs.AdjacentRooms["top"] = firstFloorCorridor;

        grandmasRoom.AdjacentRooms["left"] = firstFloorStairs;

        groundFloorCorridor.AdjacentRooms["left"] = parentsRoom;
        groundFloorCorridor.AdjacentRooms["right"] = kitchen;
        groundFloorCorridor.AdjacentRooms["front"] = firstFloorStairs;
        groundFloorCorridor.AdjacentRooms["behind"] = garageStairs;

        parentsRoom.AdjacentRooms["behind"] = toilets1;
        parentsRoom.AdjacentRooms["front"] = bathroom;
        parentsRoom.AdjacentRooms["right"] = groundFloorCorridor;

        bathroom.AdjacentRooms["behind"] = parentsRoom;
        toilets1.AdjacentRooms["front"] = parentsRoom;

        kitchen.AdjacentRooms["front"] = entrance;
        kitchen.AdjacentRooms["left"] = groundFloorCorridor;
        kitchen.AdjacentRooms["behind"] = storeroom;

        entrance.AdjacentRooms["behind"] = kitchen;

        storeroom.AdjacentRooms["front"] = kitchen;
        storeroom.AdjacentRooms["right"] = toilets2;
        storeroom.AdjacentRooms["left"] = garageStairs;

        toilets2.AdjacentRooms["left"] = storeroom;

        garageStairs.AdjacentRooms["right"] = storeroom;
        garageStairs.AdjacentRooms["front"] = groundFloorCorridor;
        garageStairs.AdjacentRooms["left"] = livingRoom;
        garageStairs.AdjacentRooms["bottom"] = cave;

        livingRoom.AdjacentRooms["right"] = garageStairs;
        livingRoom.AdjacentRooms["front"] = diningRoom;

        diningRoom.AdjacentRooms["behind"] = livingRoom;

        cave.AdjacentRooms["top"] = garageStairs;
        cave.AdjacentRooms["left"] = office;

        office.AdjacentRooms["right"] = cave;

        // Create NPCs
        NPC grandma = new NPC("Grandma");
        grandma.AddDialogue("Hello, my dear!", 0.6);
        grandma.AddDialogue("Have you seen my glasses?", 0.3);
        grandma.AddDialogue("It's a bit chilly today, isn't it?", 0.1);

        // Add NPCs to rooms
        grandmasRoom.NPCs.Add(grandma);

        // Add items to rooms
        coryAndCarrieRoom.Item = new Item("Toy");
        cathysRoom.Item = new Item("Diary");
        chrisRoom.Item = new Item("Book");
        grandmasRoom.Item = new Item("Glasses");
        bathroom.Item = new Item("Soap");
        parentsRoom.Item = new Item("Photo");
        toilets1.Item = new Item("Tissue");
        diningRoom.Item = new Item("Fork");
        livingRoom.Item = new Item("Remote");
        entrance.Item = new Item("Mat");
        kitchen.Item = new Item("Knife");
        storeroom.Item = new Item("Broom");
        toilets2.Item = new Item("Tissue");
        office.Item = new Item("Pen");
        cave.Item = new Item("Lamp");

        // Set the starting room
        CurrentRoom = grandmasRoom;
    }
}
