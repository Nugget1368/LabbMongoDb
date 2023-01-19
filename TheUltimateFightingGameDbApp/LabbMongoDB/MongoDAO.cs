using MongoDB.Driver;
using MongoDB.Bson;

namespace LabbMongoDB
{
    internal class MongoDAO : DAO
    {
        MongoClient client;
        IMongoDatabase database;
        IMongoCollection<BsonDocument> collection;
        public MongoDAO(string database, string collection,string connectionString)
        {
            client = new MongoClient(connectionString);
            this.database = client.GetDatabase(database);
            this.collection = this.database.GetCollection<BsonDocument>(collection);
        }
        public void Create(int id, string name, string[] abilities, string[] types, double height, double weight, string backStory)
        {           
            var doc = new BsonDocument
            {
                {"_id", id},
                {"name", name},
                {"abilities", new BsonArray(abilities)},
                {"types", new BsonArray(types)},
                {"height (centimeters)", Math.Round(height, 3)},
                {"weight (Kg)", Math.Round(weight, 3)},
                {"backstory", backStory}
            };

            collection.InsertOne(doc);
            
        }
        public BsonDocument GetFighter(int id)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", id);
            var document = collection.Find(filter).FirstOrDefault();

            return document.ToBsonDocument();
        }

        public List<BsonDocument> ReadAll()
        {
            var document = collection.Find(new BsonDocument());
            return document.ToList();
        }

        public void PrintAllFighters()
        {
            //Skapa lista
            List<BsonDocument> fighters = ReadAll();
            fighters.Sort();
            //Skriv ut
            Console.ForegroundColor = ConsoleColor.Yellow;
            for (int x = 0; x < fighters.Count; x++)
            {
                //Console.WriteLine($"{x + 1}. {fighters[x].ElementAtOrDefault(1).ToString().Substring(5)}");

                Console.WriteLine($"{fighters[x].ElementAtOrDefault(0).ToString().Substring(4)}. {fighters[x].ElementAtOrDefault(1).ToString().Substring(5)}");
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        public string ReadOne(int id)
        {
            string result = "";
            var filter = Builders<BsonDocument>.Filter.Eq("_id", id);
            var document = collection.Find(filter).FirstOrDefault();
            for (int x = 0; x < document.Count(); x++)
            {
                result += document.ElementAtOrDefault(x).ToString() + "\n";
            }
            return result.Replace('=', ':').Replace('[', ' ').Replace(']', ' ');
        }

        public void UpdateAbility(int id, int index, string update)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", id);
            var arrayUpdate = Builders<BsonDocument>.Update.Set($"abilities.{index}", update);  ///Uppdater specifik ability

            collection.UpdateOne(filter, arrayUpdate);

        }
        public bool Delete(int id)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", id);            
            if (collection.Find(filter).Any())
            {
                collection.DeleteOne(filter);
                return true;
            }
            return false;
        }

    }
}
