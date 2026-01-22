/*
 * CSE 212 Lesson 6C 
 * 
 * This code will analyze the NBA basketball data and create a table showing
 * the players with the top 10 career points.
 * 
 * Note about columns:
 * - Player ID is in column 0
 * - Points is in column 8
 * 
 * Each row represents the player's stats for a single season with a single team.
 */

using Microsoft.VisualBasic.FileIO;

public class Basketball
{
    public static void Run()
    {
        var players = new Dictionary<string, int>();

        using var reader = new TextFieldParser("basketball.csv");
        reader.TextFieldType = FieldType.Delimited;
        reader.SetDelimiters(",");
        reader.ReadFields(); // ignore header row

        while (!reader.EndOfData) {
            var fields = reader.ReadFields()!;
            var playerId = fields[0];
            var points = int.Parse(fields[8]);

            // TODO 1: Accumulate points for each player
            if (players.ContainsKey(playerId)) {
                players[playerId] += points;
            } else {
                players[playerId] = points;
            }
        }
        
        // Convert dictionary to array so we can sort it
        var topPlayers = players.ToArray();

        // TODO 2: Sort players by points in descending order
        Array.Sort(topPlayers, (p1, p2) => p2.Value - p1.Value);

        // TODO 3: Print the top 10 players
        Console.WriteLine();
        Console.WriteLine("Top 10 NBA Career Points Leaders");
        for (var i = 0; i < 10; ++i)
        {
            Console.WriteLine(topPlayers[i]);
        }
    }
}

// EXPLANATION:
// I can use a Dictionary where the key is the playerId and the value is the total points 
// that player has scored across all years. As I read each line of the CSV, I extract 
// the playerId and the points for that year. If the playerId is already in the Dictionary, 
// I add the new points to their total. If it’s not in the Dictionary yet, I create a new 
// entry starting with those points. After processing the whole file, I convert the Dictionary 
// to a list, sort it by total points in descending order, and print the top 10 players.