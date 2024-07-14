using static System.Net.Mime.MediaTypeNames;
using System.Drawing;

public class Map
{
    public static Room CurrentRoom = null;

    public static void Initialize()
    {
        // Create rooms
        Room coryAndCarrieRoom = new Room("Cory and Carrie's Room", "toy", new Dictionary<string, Room>());
        Room cathysRoom = new Room("Cathy's Room (Yours)", "diary", new Dictionary<string, Room>());
        Room chrisRoom = new Room("Chris's Room", "book", new Dictionary<string, Room>());
        Room firstFloorCorridor = new Room("First Floor Corridor", null, new Dictionary<string, Room>());

        Room firstFloorStairs = new Room("First Floor Stairs", null, new Dictionary<string, Room>());
        Room bathroom = new Room("Bathroom", "soap", new Dictionary<string, Room>());
        Room parentsRoom = new Room("Parents Room", "photo", new Dictionary<string, Room>());
        Room toilets1 = new Room("Toilets", "tissue", new Dictionary<string, Room>());
        Room diningRoom = new Room("Dining Room", "fork", new Dictionary<string, Room>());
        Room livingRoom = new Room("Living Room", "remote", new Dictionary<string, Room>());
        Room groundFloorCorridor = new Room("Ground Floor Corridor", null, new Dictionary<string, Room>());
        Room entrance = new Room("Entrance", "mat", new Dictionary<string, Room>());
        Room kitchen = new Room("Kitchen", "knife", new Dictionary<string, Room>());
        Room storeroom = new Room("Storeroom", "broom", new Dictionary<string, Room>());
        Room toilets2 = new Room("Toilets", "tissue", new Dictionary<string, Room>());
        Room garageStairs = new Room("Garage Stairs", null, new Dictionary<string, Room>());
        Room grandmasRoom = new Room("Grandma's Room", "glasses", new Dictionary<string, Room>());

        Room office = new Room("Office", "pen", new Dictionary<string, Room>());
        Room cave = new Room("Cave", "lamp", new Dictionary<string, Room>());

        // Link rooms together
        firstFloorCorridor.AdjacentRooms["left"] = coryAndCarrieRoom;
        firstFloorCorridor.AdjacentRooms["right"] = cathysRoom;
        firstFloorCorridor.AdjacentRooms["front"] = chrisRoom;
        coryAndCarrieRoom.AdjacentRooms["right"] = firstFloorCorridor;
        cathysRoom.AdjacentRooms["left"] = firstFloorCorridor;
        chrisRoom.AdjacentRooms["behind"] = firstFloorCorridor;
        firstFloorCorridor.AdjacentRooms["bottom"] = firstFloorStairs;

        grandmasRoom.AdjacentRooms["left"] = firstFloorStairs;
        firstFloorStairs.AdjacentRooms["right"] = grandmasRoom;
        firstFloorStairs.AdjacentRooms["bottom"] = groundFloorCorridor;
        firstFloorStairs.AdjacentRooms["top"] = firstFloorCorridor;


        //firstFloorStairs.AdjacentRooms["behind"] = groundFloorCorridor;

        //firstFloorStairs.AdjacentRooms["left"] = bathroom;
        //groundFloorCorridor.AdjacentRooms["left"] = parentsRoom;
        //groundFloorCorridor.AdjacentRooms["right"] = entrance;
        //groundFloorCorridor.AdjacentRooms["behind"] = diningRoom;
        //groundFloorCorridor.AdjacentRooms["front"] = firstFloorStairs;
        //groundFloorCorridor.AdjacentRooms["down"] = garageStairs;

        //parentsRoom.AdjacentRooms["left"] = toilets1;
        //diningRoom.AdjacentRooms["left"] = livingRoom;

        //entrance.AdjacentRooms["left"] = kitchen;
        //kitchen.AdjacentRooms["right"] = entrance;
        //kitchen.AdjacentRooms["front"] = storeroom;
        //storeroom.AdjacentRooms["behind"] = kitchen;
        //storeroom.AdjacentRooms["right"] = toilets2;

        //garageStairs.AdjacentRooms["down"] = cave;
        //cave.AdjacentRooms["front"] = office;

        CurrentRoom = cathysRoom;
    }
}
