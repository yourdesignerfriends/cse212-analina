using System.Text.Json;

public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two character 
    /// words (lower case, no duplicates). Using sets, find an O(n) 
    /// solution for returning all symmetric pairs of words.  
    ///
    /// For example, if words was: [am, at, ma, if, fi], we would return :
    ///
    /// ["am & ma", "if & fi"]
    ///
    /// The order of the array does not matter, nor does the order of the specific words in each string in the array.
    /// at would not be returned because ta is not in the list of words.
    ///
    /// As a special case, if the letters are the same (example: 'aa') then
    /// it would not match anything else (remember the assumption above
    /// that there were no duplicates) and therefore should not be returned.
    /// </summary>
    /// <param name="words">An array of 2-character words (lowercase, no duplicates)</param>
    public static string[] FindPairs(string[] words)
    {
        // TODO Problem 1 - ADD YOUR CODE HERE

        // I use a HashSet so I can check for a word's reverse in constant time (O(1)). 
        // This keeps the whole algorithm running in O(n), which is exactly what the problem requires.
        var set = new HashSet<string>(words);

        // This will be the list where the pairs that are found will be stored
        var result = new List<string>();

        // Then here we loop through each word a single time.
        foreach (var word in words)
        {
            // Here we create a special case: if both letters are the same, for example 'aa', 
            // it cannot form a valid symmetric pair.
            if (word[0] == word[1])
                continue;
            
            // Here we build the reverse of the word. Example: am - ma
            string reversed = new string(new char[] { word[1], word[0] });

            // Here we check if the reversed word exists in the set
            if (set.Contains(reversed))
            {
                // To avoid duplicates, we only add the pair if the original word is smaller than its reverse
                if (string.Compare(word, reversed) < 0)
                {
                    result.Add($"{word} & {reversed}");
                }
            }
        }

        // Finally, we convert the list to an array and return it
        return result.ToArray();
    }

    /// <summary>
    /// Read a census file and summarize the degrees (education)
    /// earned by those contained in the file.  The summary
    /// should be stored in a dictionary where the key is the
    /// degree earned and the value is the number of people that 
    /// have earned that degree.  The degree information is in
    /// the 4th column of the file.  There is no header row in the
    /// file.
    /// </summary>
    /// <param name="filename">The name of the file to read</param>
    /// <returns>A dictionary with each degree and how many times it appears</returns>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();
        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");
            // TODO Problem 2 - ADD YOUR CODE HERE
            // To solve this problem, I will read the file line by line, split each line 
            // by commas, extract column 4, trim spaces, and update the dictionary 
            // by increasing the count for each degree.

            // The degree is in column 4 (index 3), so we take it and remove extra spaces
            var degree = fields[3].Trim();

            // If the degree already exists in the dictionary, we increase the count
            if (degrees.ContainsKey(degree))
            {
                degrees[degree]++;
            }
            else
            {
                // If it's the first time we see this degree, we start the count at 1
                degrees[degree] = 1;
            }
        }
        // Finally, we return the dictionary with all the degrees and their counts
        return degrees;
    }

    /// <summary>
    /// Determine if 'word1' and 'word2' are anagrams.  An anagram
    /// is when the same letters in a word are re-organized into a 
    /// new word.  A dictionary is used to solve the problem.
    /// 
    /// Examples:
    /// is_anagram("CAT","ACT") would return true
    /// is_anagram("DOG","GOOD") would return false because GOOD has 2 O's
    /// 
    /// Important Note: When determining if two words are anagrams, you
    /// should ignore any spaces.  You should also ignore cases.  For 
    /// example, 'Ab' and 'Ba' should be considered anagrams
    /// 
    /// Reminder: You can access a letter by index in a string by 
    /// using the [] notation.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        // TODO Problem 3 - ADD YOUR CODE HERE
        // To solve this problem, I will first normalize both words by converting them, to lowercase 
        // and removing any spaces. Then I will use a dictionary to count how many times each letter 
        // appears in the first word. After that, I will go through the second word and decrease 
        // the counts. If a letter is not found in the dictionary or any count becomes negative, 
        // then they are not anagrams. Finally, if all counts end at zero, the two words are anagrams.

        // Normalize both words: lowercase and remove spaces
        var normalizeWord1 = word1.ToLower().Replace(" ", "");
        var normalizeWord2 = word2.ToLower().Replace(" ", "");
        // If the cleaned words don't have the same length, they can't be anagrams
        if (normalizeWord1.Length != normalizeWord2.Length)
        {
            return false;
        }
        // Dictionary to store how many times each letter appears in normalizeWord1
        var letterCounts = new Dictionary<char, int>();
        // Count letters from the first word
        foreach (var letter in normalizeWord1)
        {
            if (letterCounts.ContainsKey(letter))
            {
                letterCounts[letter]++;
            }
            else
            {
                letterCounts[letter] = 1;
            }
        }
        // Subtract counts using the second word
        foreach (var letter in normalizeWord2)
        {
            // If the letter doesn't exist, they are not anagrams
            if (!letterCounts.ContainsKey(letter))
            {
                return false;
            }
            letterCounts[letter]--;
            // If the count goes negative, normalizeWord2 has extra letters
            if (letterCounts[letter] < 0)
            {
                return false;
            }
        }
        // If all counts are zero, they are anagrams
        return true;
    }

    /// <summary>
    /// This function will read JSON (Javascript Object Notation) data from the 
    /// United States Geological Service (USGS) consisting of earthquake data.
    /// The data will include all earthquakes in the current day.
    /// 
    /// JSON data is organized into a dictionary. After reading the data using
    /// the built-in HTTP client library, this function will return a list of all
    /// earthquake locations ('place' attribute) and magnitudes ('mag' attribute).
    /// Additional information about the format of the JSON data can be found 
    /// at this website:  
    /// 
    /// https://earthquake.usgs.gov/earthquakes/feed/v1.0/geojson.php
    /// 
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        // TODO Problem 5:
        // 1. Add code in FeatureCollection.cs to describe the JSON using classes and properties 
        // on those classes so that the call to Deserialize above works properly.
        // 2. Add code below to create a string out each place a earthquake has happened today and its magitude.
        // 3. Return an array of these string descriptions.
        
        // Step 1: Create a list where I will store each formatted earthquake description.
        var earthquakeSummaries = new List<string>();
        // Step 2: Loop through each earthquake event inside the 'features' list.
        foreach (var singleEvent in featureCollection.features)
        {
            // Step 3: Extract the place and magnitude from the event's properties.
            var eventLocation = singleEvent.properties.place;
            var eventMagnitude = singleEvent.properties.mag;
            // Step 4: Format the string exactly as required.
            string summaryLine = $"{eventLocation} - Mag {eventMagnitude}";
            // Step 5: Add the formatted string to my list.
            earthquakeSummaries.Add(summaryLine);
        }
        // Step 6: Convert the list to an array and return it.
        return earthquakeSummaries.ToArray();
    }
}