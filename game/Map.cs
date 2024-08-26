using System.Drawing;
using static System.Net.Mime.MediaTypeNames;

public static class Map
{
    public static Room CurrentRoom = null;

    public static void Initialize()
    {
        // Create NPCs
        NPC grandma = new NPC(1, "Grandma");
        grandma.AddDialogue("Hello, my dear!", 0.6);
        grandma.AddDialogue("Have you seen my glasses?", 0.3);
        grandma.AddDialogue("It's a bit chilly today, isn't it?", 0.1);
        NPC cory = new NPC(2, "Cory");
        cory.AddDialogue("Hey, what's up?", 0.1);
        cory.AddDialogue("I'm busy right now, come back later.", 0.1);
        cory.AddDialogue("I'm reading a book, please don't disturb me.", 0.8);
        NPC carrie = new NPC(3, "Carrie");
        carrie.AddDialogue("Hi, how are you?", 0.5);
        carrie.AddDialogue("I'm reading a book, please don't disturb me.", 0.5);
        NPC chris = new NPC(4, "Chris");
        chris.AddDialogue("Hey, what's up?", 0.5);
        chris.AddDialogue("I'm busy right now, come back later.", 0.5);
        NPC mom = new NPC(5, "Mom");
        mom.AddDialogue("you better clean your room or ...", 0.5);
        mom.AddDialogue("I'm busy right now, come back later.", 0.5);

        // Create rooms
        Room coryAndCarrieRoom = new Room(
            1,
            "Cory and Carrie's Room",
            null,
            new Dictionary<string, Room>(),
            new List<NPC>() { cory, carrie }
        );
        Room cathysRoom = new Room(
            2,
            "Cathy's Room (Yours)",
            null,
            new Dictionary<string, Room>(),
            new List<NPC>()
        );
        Room chrisRoom = new Room(
            3,
            "Chris's Room",
            null,
            new Dictionary<string, Room>(),
            new List<NPC>() { chris }
        );
        Room firstFloorCorridor = new Room(
            4,
            "First Floor Corridor",
            null,
            new Dictionary<string, Room>(),
            new List<NPC>()
        );

        Room firstFloorStairs = new Room(
            5,
            "First Floor Stairs",
            null,
            new Dictionary<string, Room>(),
            new List<NPC>()
        );
        Room grandmasRoom = new Room(
            6,
            "Grandma's Room",
            new Item(4, "Glasses"),
            new Dictionary<string, Room>(),
            new List<NPC>() { grandma }
        );
        Room groundFloorCorridor = new Room(
            7,
            "Ground Floor Corridor",
            null,
            new Dictionary<string, Room>(),
            new List<NPC>()
        );
        Room bathroom = new Room(
            8,
            "Bathroom",
            null,
            new Dictionary<string, Room>(),
            new List<NPC>()
        );
        Room parentsRoom = new Room(
            9,
            "Parents Room",
            null,
            new Dictionary<string, Room>(),
            new List<NPC>()
        );
        Room toilets1 = new Room(
            10,
            "Toilets",
            null,
            new Dictionary<string, Room>(),
            new List<NPC>()
        );
        Room diningRoom = new Room(
            11,
            "Dining Room",
            null,
            new Dictionary<string, Room>(),
            new List<NPC>()
        );
        Room livingRoom = new Room(
            12,
            "Living Room",
            null,
            new Dictionary<string, Room>(),
            new List<NPC>()
        );
        Room garageStairs = new Room(
            13,
            "Garage Stairs",
            null,
            new Dictionary<string, Room>(),
            new List<NPC>()
        );
        Room entrance = new Room(
            14,
            "Entrance",
            null,
            new Dictionary<string, Room>(),
            new List<NPC>()
        );
        Room kitchen = new Room(
            15,
            "Kitchen",
            null,
            new Dictionary<string, Room>(),
            new List<NPC>() { mom }
        );
        Room storeroom = new Room(
            16,
            "Storeroom",
            null,
            new Dictionary<string, Room>(),
            new List<NPC>()
        );
        Room toilets2 = new Room(
            17,
            "Toilets",
            null,
            new Dictionary<string, Room>(),
            new List<NPC>()
        );

        Room office = new Room(18, "Office", null, new Dictionary<string, Room>(), new List<NPC>());
        Room cave = new Room(
            19,
            "Cave",
            new Item(4, "Front Door Key"),
            new Dictionary<string, Room>(),
            new List<NPC>()
        );

        // Link rooms together
        firstFloorCorridor.addAdjacentRoom("left", coryAndCarrieRoom);
        firstFloorCorridor.addAdjacentRoom("right", cathysRoom);
        firstFloorCorridor.addAdjacentRoom("front", chrisRoom);
        firstFloorCorridor.addAdjacentRoom("bottom", firstFloorStairs);

        coryAndCarrieRoom.addAdjacentRoom("right", firstFloorCorridor);
        cathysRoom.addAdjacentRoom("left", firstFloorCorridor);
        chrisRoom.addAdjacentRoom("behind", firstFloorCorridor);

        firstFloorStairs.addAdjacentRoom("right", grandmasRoom);
        firstFloorStairs.addAdjacentRoom("bottom", groundFloorCorridor);
        firstFloorStairs.addAdjacentRoom("top", firstFloorCorridor);

        grandmasRoom.addAdjacentRoom("left", firstFloorStairs);

        groundFloorCorridor.addAdjacentRoom("left", parentsRoom);
        groundFloorCorridor.addAdjacentRoom("right", kitchen);
        groundFloorCorridor.addAdjacentRoom("front", firstFloorStairs);
        groundFloorCorridor.addAdjacentRoom("behind", garageStairs);

        parentsRoom.addAdjacentRoom("behind", toilets1);
        parentsRoom.addAdjacentRoom("front", bathroom);
        parentsRoom.addAdjacentRoom("right", groundFloorCorridor);

        bathroom.addAdjacentRoom("behind", parentsRoom);
        toilets1.addAdjacentRoom("front", parentsRoom);

        kitchen.addAdjacentRoom("front", entrance);
        kitchen.addAdjacentRoom("left", groundFloorCorridor);
        kitchen.addAdjacentRoom("behind", storeroom);

        entrance.addAdjacentRoom("behind", kitchen);

        storeroom.addAdjacentRoom("front", kitchen);
        storeroom.addAdjacentRoom("right", toilets2);
        storeroom.addAdjacentRoom("left", garageStairs);

        toilets2.addAdjacentRoom("left", storeroom);

        garageStairs.addAdjacentRoom("right", storeroom);
        garageStairs.addAdjacentRoom("front", groundFloorCorridor);
        garageStairs.addAdjacentRoom("left", livingRoom);
        garageStairs.addAdjacentRoom("bottom", cave);

        livingRoom.addAdjacentRoom("right", garageStairs);
        livingRoom.addAdjacentRoom("front", diningRoom);

        diningRoom.addAdjacentRoom("behind", livingRoom);

        cave.addAdjacentRoom("top", garageStairs);
        cave.addAdjacentRoom("left", office);

        office.addAdjacentRoom("right", cave);

        // Set the starting room
        CurrentRoom = grandmasRoom;
    }
}
