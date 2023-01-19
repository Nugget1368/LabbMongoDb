
using MongoDB.Bson;

namespace LabbMongoDB
{
    interface DAO
    {
        void Create(int id, string name, string[] abilities, string[] types, double height, double weight, string backStory);
        public BsonDocument GetFighter(int id);
        string ReadOne(int id);
        List<BsonDocument> ReadAll();
        void PrintAllFighters();
        void UpdateAbility(int id, int index, string update);
        bool Delete(int id);
    }
}
