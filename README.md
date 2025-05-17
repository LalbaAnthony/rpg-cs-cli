# bsi-cs-rpg

RPG en lignes de commande fait en C# et réalisé dans le cadre de mon Bachelor SI

## Présentation

Ce projet a été réalisé dans le cadre de mon Bachelor à Limayrac.
Il s'agit d'un RPG en lignes de commande réalisé en C# avec Visual Studio.

L'histoire du RPG est largement inspiré de la série de roman de "Fleurs Captives" (Flowers in the Attic) de V.C. Andrews.

## Installation

Ouvrir le projet avec Visual Studio et selectionner le fichier `rpg_cs_cli.sln` pour ouvrir le projet.

## Structure du projet

Le projet est divisé en plusieurs fichiers :

- `rpg_cs_cli.csproj` : Contient les informations du projet
- `Program.cs` : Contient le point d'entrée du programme, c'est la ou se situe la boucle principale du jeu, etc
- `NPC.cs` : Contient la classe NPC qui permet de créer des personnages non-joueurs
- `Room.cs` : Contient la classe Room qui permet de créer des salles
- `Item.cs` : Contient la classe Item qui permet de créer des objets
- `Map.cs` : Contient la classe Map qui permet de créer une carte, de la remplir de salles, etc. Elle est pensé pour être dupliqué/changé/reutilisé pour d'autre topologie de carte.
- `Dialogs.cs` : Contient les dialogues du jeu, les textes, etc. Ne contient pas les dialogues des personnages non-joueurs.
- `Printers.cs` : Contient les fonctions d'affichage primaires du jeu
- `Helpers.cs` : Contient les fonctions utilitaires du jeu
