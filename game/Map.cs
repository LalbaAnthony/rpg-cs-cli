using static System.Net.Mime.MediaTypeNames;
using System.Drawing;

public class Map
{
    public static Room CurrentRoom = null;

    public static void Initialize()
    {
        // Create rooms
        Room coryAndCarrieRoom = new Room("Cory and Carrie's Room", "toy", new Dictionary<string, Room>(), new List<NPC>());
        Room cathysRoom = new Room("Cathy's Room (Yours)", "diary", new Dictionary<string, Room>(), new List<NPC>());
        Room chrisRoom = new Room("Chris's Room", "book", new Dictionary<string, Room>(), new List<NPC>());
        Room firstFloorCorridor = new Room("First Floor Corridor", null, new Dictionary<string, Room>(), new List<NPC>());

        Room firstFloorStairs = new Room("First Floor Stairs", null, new Dictionary<string, Room>(), new List<NPC>());
        Room grandmasRoom = new Room("Grandma's Room", "glasses", new Dictionary<string, Room>(), new List<NPC>());
        Room groundFloorCorridor = new Room("Ground Floor Corridor", null, new Dictionary<string, Room>(), new List<NPC>());
        Room bathroom = new Room("Bathroom", "soap", new Dictionary<string, Room>(), new List<NPC>());
        Room parentsRoom = new Room("Parents Room", "photo", new Dictionary<string, Room>(), new List<NPC>());
        Room toilets1 = new Room("Toilets", "tissue", new Dictionary<string, Room>(), new List<NPC>());
        Room diningRoom = new Room("Dining Room", "fork", new Dictionary<string, Room>(), new List<NPC>());
        Room livingRoom = new Room("Living Room", "remote", new Dictionary<string, Room>(), new List<NPC>());
        Room garageStairs = new Room("Garage Stairs", null, new Dictionary<string, Room>(), new List<NPC>());
        Room entrance = new Room("Entrance", "mat", new Dictionary<string, Room>(), new List<NPC>());
        Room kitchen = new Room("Kitchen", "knife", new Dictionary<string, Room>(), new List<NPC>());
        Room storeroom = new Room("Storeroom", "broom", new Dictionary<string, Room>(), new List<NPC>());
        Room toilets2 = new Room("Toilets", "tissue", new Dictionary<string, Room>(), new List<NPC>());

        Room office = new Room("Office", "pen", new Dictionary<string, Room>(), new List<NPC>());
        Room cave = new Room("Cave", "lamp", new Dictionary<string, Room>(), new List<NPC>());

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

        // Set the starting room
        CurrentRoom = grandmasRoom;
    }
}
